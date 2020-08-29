using CommonScripts.Model;
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
            var scripts = new List<Script>();
            scripts.Add(new Script() { Id = 1, ScriptName = "asdf1", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            scripts.Add(new Script() { Id = 2, ScriptName = "asdf2", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            scripts.Add(new Script() { Id = 3, ScriptName = "asdf3", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            scripts.Add(new Script() { Id = 4, ScriptName = "asdf4", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            scripts.Add(new Script() { Id = 5, ScriptName = "asdf5", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            scripts.Add(new Script() { Id = 6, ScriptName = "asdf6", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            scripts.Add(new Script() { Id = 6, ScriptName = "asdf6", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            scripts.Add(new Script() { Id = 6, ScriptName = "asdf6", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            scripts.Add(new Script() { Id = 6, ScriptName = "asdf6", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            scripts.Add(new Script() { Id = 6, ScriptName = "asdf6", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            scripts.Add(new Script() { Id = 6, ScriptName = "asdf6", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            scripts.Add(new Script() { Id = 6, ScriptName = "asdf6", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            scripts.Add(new Script() { Id = 6, ScriptName = "asdf6", ScriptStatus = Script.Status.Running, ScriptType = Script.Type.Daemon});
            _view.ShowScripts(scripts);
        }
    }
}
