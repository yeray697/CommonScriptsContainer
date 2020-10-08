using CommonScripts.Model;
using CommonScripts.Model.Base;
using CommonScripts.Presenter.Interfaces;
using CommonScripts.Repository.Interfaces;
using CommonScripts.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonScripts.Presenter
{
    public class MainPresenter : IMainPresenter
    {
        private IMainView _view { get; set; }
        private ISettingsRepository _settingsRepository { get; set; }

        public MainPresenter(IMainView view, ISettingsRepository settingsRepository)
        {
            _view = view;
            _view.Presenter = this; // Poor Man's DI
            _settingsRepository = settingsRepository;
        }

        public void LoadSettings()
        {
            var scripts = new List<ScriptAbs>();
            scripts.Add(new ScriptOneOff() { Id = 1, ScriptName = "asdf1", ScriptStatus = ScriptStatus.Running});
            scripts.Add(new ScriptOneOff() { Id = 2, ScriptName = "asdf2", ScriptStatus = ScriptStatus.Running});
            scripts.Add(new ScriptOneOff() { Id = 3, ScriptName = "asdf3", ScriptStatus = ScriptStatus.Running});
            scripts.Add(new ScriptOneOff() { Id = 4, ScriptName = "asdf4", ScriptStatus = ScriptStatus.Running});
            scripts.Add(new ScriptOneOff() { Id = 5, ScriptName = "asdf5", ScriptStatus = ScriptStatus.Running});
            scripts.Add(new ScriptOneOff() { Id = 6, ScriptName = "asdf6", ScriptStatus = ScriptStatus.Running});
            scripts.Add(new ScriptOneOff() { Id = 7, ScriptName = "asdf7", ScriptStatus = ScriptStatus.Running});
            scripts.Add(new ScriptOneOff() { Id = 8, ScriptName = "asdf8", ScriptStatus = ScriptStatus.Running});
            scripts.Add(new ScriptOneOff() { Id = 9, ScriptName = "asdf9", ScriptStatus = ScriptStatus.Running});
            scripts.Add(new ScriptOneOff() { Id = 10, ScriptName = "asdf10", ScriptStatus = ScriptStatus.Running});
            scripts.Add(new ScriptOneOff() { Id = 11, ScriptName = "asdf11", ScriptStatus = ScriptStatus.Running});
            scripts.Add(new ScriptOneOff() { Id = 12, ScriptName = "asdf12", ScriptStatus = ScriptStatus.Running});
            scripts.Add(new ScriptOneOff() { Id = 13, ScriptName = "asdf13", ScriptStatus = ScriptStatus.Running});
            _view.ShowScripts(scripts);
        }

        public bool AddScript(ScriptAbs script)
        {
            return true;
        }

        public bool EditScript(ScriptAbs script)
        {
            return true;
        }

        public bool RemoveScript(int scriptId)
        {
            return true;
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
    }
}
