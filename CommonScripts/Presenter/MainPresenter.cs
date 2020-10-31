using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Presenter.Interfaces;
using CommonScripts.Model.Service.Interfaces;
using CommonScripts.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CommonScripts.Model.Service;
using System.Threading.Tasks;

namespace CommonScripts.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        private IMainView _view;
        private ISettingsService _settingsService;
        private IRunScriptService _runScriptService;
        private List<ScriptAbs> Scripts;
        private ListenKeysService _listenKeysService;

        public MainPresenter(IMainView view, ISettingsService settingsService, IRunScriptService runScriptService)
        {
            _view = view;
            _view.Presenter = this; // Poor Man's DI
            _settingsService = settingsService;
            _runScriptService = runScriptService;

            _listenKeysService = ListenKeysService.GetInstance();
            _listenKeysService.KeyUpClicked += ListenKeysService_KeyUpClicked;
        }

        public void LoadSettings()
        {
            Scripts = _settingsService.GetScripts();
            CheckScriptStatus();
            _view.ShowScripts(Scripts);
        }

        public bool AddScript(ScriptAbs script)
        {
            script.Id = Guid.NewGuid().ToString();
            Scripts.Add(script);
            _settingsService.SaveScripts(Scripts);
            return true;
        }

        public bool EditScript(ScriptAbs script)
        {
            bool successful = false;

            if (RemoveScript(script.Id, false))
            {
                Scripts.Add(script);
                successful = _settingsService.SaveScripts(Scripts);
            }

            return successful;
        }
        

        public bool RemoveScript(string scriptId)
        {
            return RemoveScript(scriptId, true);
        }

        public async Task<ScriptStatus> ChangeScriptStatus(ScriptAbs script)
        {
            ScriptStatus newStatus = ScriptStatus.Undefined;
            switch (script.ScriptStatus)
            {
                case ScriptStatus.Running:
                case ScriptStatus.Resuming:
                    if (script is ScriptListenKey && !IsListenKeyServiceNecessary())
                    {
                        _listenKeysService.Stop();
                    }
                    else
                    {
                        await _runScriptService.StopScript(script);
                    }
                    newStatus = ScriptStatus.Stopped;
                    break;
                case ScriptStatus.Undefined:
                case ScriptStatus.Stopped:
                    if (script is ScriptListenKey)
                    {
                        _listenKeysService.Run();
                    }
                    else
                    {
                        await _runScriptService.RunScript(script);
                    }
                    newStatus = ScriptStatus.Running;
                    break;
                default:
                    break;
            }
            _settingsService.SaveScripts(Scripts);//ToDo better
            return newStatus;
        }

        private bool IsListenKeyServiceNecessary()
        {
            return GetScriptListenKeyScripts()?.Any(s => s.ScriptStatus == ScriptStatus.Running) ?? false;
        }

        private IEnumerable<ScriptListenKey> GetScriptListenKeyScripts()
        {
            return Scripts?.OfType<ScriptListenKey>();
        }

        private bool RemoveScript(string scriptId, bool save)
        {
            bool successful = false;
            int originalCount = Scripts.Count;
            Scripts = Scripts.Where(s => s.Id != scriptId).ToList();

            if (originalCount > Scripts.Count)
            {
                successful = save ? _settingsService.SaveScripts(Scripts) : true;
            }

            return successful;
        }

        private void ListenKeysService_KeyUpClicked(KeyPressed keyPressed)
        {
            foreach (ScriptListenKey item in GetScriptListenKeyScripts())
            {
                if (item.ScriptStatus == ScriptStatus.Running && (item.TriggerKey?.Equals(keyPressed) ?? false))
                {
                    _runScriptService.RunScript(item);
                }

            }
        }

        private void CheckScriptStatus()
        {
            bool areScriptsScheduled = false;
            bool shouldListenForKeys = false;
            if (Scripts != null) {
                
                foreach (var script in Scripts.Where(s => s.ScriptStatus == ScriptStatus.Running))
                {
                    if (script is ScriptScheduled)
                    {
                        areScriptsScheduled = true;
                        _runScriptService.Run();
                        _runScriptService.RunScript(script);
                    } else if (script is ScriptListenKey)
                    {
                        shouldListenForKeys = true;
                        _listenKeysService.Run();
                    }
                }
            }

            if (!areScriptsScheduled)
            {
                _runScriptService.Stop();
            }

            if (!shouldListenForKeys)
            {
                _listenKeysService.Stop();
            }

        }
    }
}
