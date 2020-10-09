using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Presenter.Interfaces;
using CommonScripts.Model.Service.Interfaces;
using CommonScripts.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonScripts.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        private IMainView _view { get; set; }
        private ISettingsService _settingsService { get; set; }
        private List<ScriptAbs> Scripts { get; set; }

        public MainPresenter(IMainView view, ISettingsService settingsService)
        {
            _view = view;
            _view.Presenter = this; // Poor Man's DI
            _settingsService = settingsService;
        }

        public void LoadSettings()
        {
            Scripts = _settingsService.GetScripts();
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

        public ScriptStatus ChangeScriptStatus(ScriptAbs script)
        {
            ScriptStatus newStatus = ScriptStatus.Undefined;
            switch (script.ScriptStatus)
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
    }
}
