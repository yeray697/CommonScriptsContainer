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
using Microsoft.Win32;

namespace CommonScripts.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        private Settings _settings;
        private IMainView _view;
        private ISettingsService _settingsService;
        private IRunScriptService _runScriptService;
        private List<ScriptAbs> _scripts;
        private ListenKeysService _listenKeysService;
        private JobListener _oneOffJobListener;

        public MainPresenter(IMainView view, ISettingsService settingsService, IRunScriptService runScriptService)
        {
            _view = view;
            _view.Presenter = this; // Poor Man's DI
            _settingsService = settingsService;
            _runScriptService = runScriptService;

            _listenKeysService = ListenKeysService.GetInstance();
            _listenKeysService.KeyUpClicked += ListenKeysService_KeyUpClicked;

            _oneOffJobListener = new JobListener();
            _oneOffJobListener.JobWasExecutedListener += OneOffJobWasExecuted;
            _runScriptService.SetOneOffJobListener(_oneOffJobListener);
        }

        private void OneOffJobWasExecuted(Quartz.IJobExecutionContext context, Quartz.JobExecutionException jobException)
        {
            string scriptId = context.JobDetail.Key.Name;
            _view.ChangeScriptStatusThreadSafe(GetScriptById(scriptId));
        }

        private ScriptAbs GetScriptById(string scriptId)
        {
            return _scripts?.FirstOrDefault(s => s.Id == scriptId);
        }

        public void LoadSettings()
        {
            _settings = _settingsService.GetSettings();
            _scripts = _settingsService.GetScripts();
            CheckScriptStatus();
            _view.ShowScripts(_scripts);
            if (!_settings.DoNotAskAgainRunStartup && !IsAppRunningAtStartup())
                _view.ShowRunAtStartupDialog();
        }

        public bool AddScript(ScriptAbs script)
        {
            script.Id = Guid.NewGuid().ToString();
            _scripts.Add(script);
            _settingsService.SaveScripts(_scripts);

            Log.Debug("Adding Script {@ScriptName} ({@ScriptType})", script.ScriptName, script.ScriptType);
            return true;
        }

        public bool EditScript(ScriptAbs script)
        {
            bool successful = false;

            if (RemoveScript(script.Id, false))
            {
                _scripts.Add(script);
                successful = _settingsService.SaveScripts(_scripts);
                Log.Debug("Edit Script {@ScriptName} ({@ScriptType})", script.ScriptName, script.ScriptType);
            }

            return successful;
        }
        

        public bool RemoveScript(string scriptId)
        {
            Log.Debug("Remove ScriptId {@ScriptId}", scriptId);
            return RemoveScript(scriptId, true);
        }

        public async Task<bool> ChangeScriptStatus(ScriptAbs script)
        {
            ScriptStatus oldStatus = script.ScriptStatus;
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

            script.ScriptStatus = newStatus;

            Log.Debug("Change {@ScriptName} ({@ScriptType}) Script Status from {@OldStatus} to {@NewStatus}", script.ScriptName, script.ScriptType, oldStatus, newStatus);
            if (newStatus == ScriptStatus.Running)
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

            return newStatus != oldStatus;
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
                successful = save ? _settingsService.SaveScripts(_scripts) : true;
            }

            return successful;
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

        private void CheckScriptStatus()
        {
            bool shouldListenForKeys = false;
            if (_scripts != null) {
                
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
                    } else if (script is ScriptListenKey)
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

        public void DoNotAskAgainRunAtStartup()
        {
            _settings.DoNotAskAgainRunStartup = true;
            _settingsService.SaveSettings(_settings);
        }

        private bool IsAppRunningAtStartup()
        {
            var key = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run",
             "CommonScripts"
             ,null);

            return key != null;
        }
        
        public bool SetAppRunAtStartup()
        {
            string exePath = System.Windows.Forms.Application.StartupPath + "CommonScripts.Exe";
            string args = "-hide";
            bool result = true;
            try
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run",
                 "CommonScripts",
                 exePath + " " + args);
            }
            catch (Exception e)
            {
                Log.Error(e, "Error while saving the windows registry.");
                result = false;
            }

            return result;
        }
    }
}
