using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Model.Service;
using CommonScripts.Model.Service.Interfaces;
using CommonScripts.Model.Service.Job;
using CommonScripts.Presenter.Interfaces;
using CommonScripts.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using CommonScripts.Settings;
using CommonScripts.Logging;

namespace CommonScripts.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        private IMainView _view;
        private ISettingsService _settingsService;
        private IRunScriptService _runScriptService;
        private IWindowsRegistryService _windowsRegistryService;
        private List<ScriptAbs> _scripts;
        private ListenKeysService _listenKeysService;
        private JobListener _oneOffJobListener;

        public MainPresenter(IMainView view, ISettingsService settingsService, IRunScriptService runScriptService, IWindowsRegistryService windowsRegistryService)
        {
            _view = view;
            _view.Presenter = this; // Poor Man's DI
            _settingsService = settingsService;
            _runScriptService = runScriptService;
            _windowsRegistryService = windowsRegistryService;

            InitListenKeyService();
            InitOneOffJobListener();
        }

        #region Events
        private void OneOffJobWasExecuted(Quartz.IJobExecutionContext context, Quartz.JobExecutionException jobException)
        {
            string scriptId = context.JobDetail.Key.Name;
            _view.ChangeScriptStatusThreadSafe(GetScriptById(scriptId));
        }
        private void ListenKeysService_KeyUpClicked(KeyPressed keyPressed)
        {
            Log.Debug("MainPresenter: KeyUpClicked event received");
            foreach (ScriptListenKey item in GetScriptListenKeyScripts())
            {
                if (item.ScriptStatus == ScriptStatus.Running && (item.TriggerKey?.Equals(keyPressed) ?? false))
                {
                    Log.Debug("KeyUp matches with a running ScriptListenKey script ({@ScriptName})", item.ScriptName);
                    _runScriptService.RunScript(item);
                }

            }
        }
        #endregion

        #region Private Methods
        private void InitListenKeyService()
        {
            _listenKeysService = ListenKeysService.GetInstance();
            _listenKeysService.KeyUpClicked += ListenKeysService_KeyUpClicked;
        }
        private void InitOneOffJobListener()
        {
            _oneOffJobListener = new JobListener();
            _oneOffJobListener.JobWasExecutedListener += OneOffJobWasExecuted;
            _runScriptService.SetOneOffJobListener(_oneOffJobListener);
        }
        private ScriptAbs GetScriptById(string scriptId)
        {
            return _scripts?.FirstOrDefault(s => s.Id == scriptId);
        }
        private ScriptStatus GetNewScriptStatus(ScriptStatus oldStatus)
        {
            ScriptStatus newStatus = ScriptStatus.Undefined;
            switch (oldStatus)
            {
                case ScriptStatus.Running:
                case ScriptStatus.Resuming:
                    newStatus = ScriptStatus.Stopped;
                    break;
                case ScriptStatus.Undefined:
                case ScriptStatus.Stopped:
                    newStatus = ScriptStatus.Running;
                    break;
                default:
                    break;
            }
            return newStatus;
        }
        private bool IsListenKeyServiceNecessary()
        {
            return GetScriptListenKeyScripts()?.Any(s => s.ScriptStatus == ScriptStatus.Running) ?? false;
        }
        private IEnumerable<ScriptListenKey> GetScriptListenKeyScripts()
        {
            return _scripts?.OfType<ScriptListenKey>();
        }
        private bool RemoveScript(string scriptId, bool save)
        {
            bool successful = false;
            int originalCount = _scripts.Count;
            _scripts = _scripts.Where(s => s.Id != scriptId).ToList();

            if (originalCount > _scripts.Count)
            {
                successful = !save || _settingsService.SaveScripts(_scripts);
            }

            return successful;
        }
        private void CheckScriptStatus()
        {
            bool shouldListenForKeys = false;
            if (_scripts != null)
            {
                var runningScripts = _scripts.Where(s => s.ScriptStatus == ScriptStatus.Running);

                if (runningScripts.Any())
                    _runScriptService.Run();
                else
                    _runScriptService.Stop();

                foreach (var script in runningScripts)
                {
                    if (script is ScriptScheduled)
                    {
                        _runScriptService.RunScript(script);
                    }
                    else if (script is ScriptListenKey)
                    {
                        shouldListenForKeys = true;
                        _listenKeysService.Run();
                    }
                }
            }
            if (shouldListenForKeys)
                _listenKeysService.Run();
            else
                _listenKeysService.Stop();
        }
        #endregion

        #region Public Methods
        public void LoadScripts()
        {
            _scripts = _settingsService.GetScripts();
            CheckScriptStatus();
            _view.ShowScripts(_scripts);
            if (!AppSettingsManager.AskToRunAppAtStartup() && !_windowsRegistryService.IsAppSetToRunAtStartup())
                _view.ShowRunAtStartupDialog();
        }
        public void LoadSettings()
        {
            AppSettingsManager.LoadSettings();
        }
        public bool AddScript(ScriptAbs script)
        {
            Log.Debug("Adding Script {@ScriptName} ({@ScriptType})", script.ScriptName, script.ScriptType);
            script.Id = Guid.NewGuid().ToString();
            _scripts.Add(script);
            return _settingsService.SaveScripts(_scripts);
        }
        public bool EditScript(ScriptAbs script, bool hasScriptTypeChanged)
        {
            Log.Debug("Editing Script {@ScriptName} ({@ScriptType})", script.ScriptName, script.ScriptType);
            bool successful = false;
            if (RemoveScript(script.Id, false)) //ToDo this could be improved
            {
                _scripts.Add(script);
                successful = _settingsService.SaveScripts(_scripts);
                if (successful && script.ScriptStatus == ScriptStatus.Running && hasScriptTypeChanged)
                {
                    _runScriptService.StopScript(script);
                    if (script.ScriptType != ScriptType.OneOff)
                        _runScriptService.RunScript(script);
                    else
                        _view.ChangeScriptStatusThreadSafe(script);
                }
            }
            return successful;
        }
        public bool RemoveScript(string scriptId)
        {
            Log.Debug("Removing ScriptId {@ScriptId}", scriptId);
            return RemoveScript(scriptId, true);
        }
        public async Task<bool> ChangeScriptStatus(ScriptAbs script)
        {
            ScriptStatus oldStatus = script.ScriptStatus;
            script.ScriptStatus = GetNewScriptStatus(oldStatus);

            Log.Debug("Change {@ScriptName} ({@ScriptType}) Script Status from {@OldStatus} to {@NewStatus}", script.ScriptName, script.ScriptType, oldStatus, script.ScriptStatus);
            if (script.ScriptStatus == ScriptStatus.Running)
            {
                if (script is ScriptListenKey)
                    _listenKeysService.Run();
                else
                    await _runScriptService.RunScript(script);
            }
            else
            {
                if (script is ScriptListenKey && !IsListenKeyServiceNecessary())
                    _listenKeysService.Stop();
                else
                    await _runScriptService.StopScript(script);
            }

            _settingsService.SaveScripts(_scripts);

            return script.ScriptStatus != oldStatus;
        }
        public void DoNotAskAgainRunAtStartup()
        {
            AppSettingsManager.SetAskToRunAppAtStartup(true);
        }
        public bool SetAppRunAtStartup()
        {
            return _windowsRegistryService.SetAppToRunAtStartup();
        }
        public bool SaveSettings(AppSettings settings)
        {
            if (settings.FileMinimumLoggingLevel != AppSettingsManager.GetFileMinLogLevel())
                LogManager.ChangeMinLoggingLevel(settings.FileMinimumLoggingLevel);
            AppSettingsManager.SaveSettings(settings);
            return true;
        }
        #endregion
    }
}
