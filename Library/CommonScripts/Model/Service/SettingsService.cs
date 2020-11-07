using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Model.Repository.Interfaces;
using CommonScripts.Model.Service.Interfaces;
using Serilog;
using System.Collections.Generic;

namespace CommonScripts.Model.Service
{
    public class SettingsService : ISettingsService
    {
        private ISettingsRepository _repository;

        public SettingsService(ISettingsRepository repository)
        {
            _repository = repository;
        }

        public List<ScriptAbs> GetScripts()
        {
            Log.Debug("Loading Scripts from json file");
            return _repository.GetScripts();
        }

        public bool SaveScripts(List<ScriptAbs> scripts)
        {
            Log.Debug("Saving Scripts into json file");
            return _repository.SaveScripts(scripts);
        }

        public Settings GetSettings()
        {
            Log.Debug("Loading Settings from json file");
            return _repository.GetSettings();
        }

        public bool SaveSettings(Settings settings)
        {
            Log.Debug("Saving Settings into json file");
            return _repository.SaveSettings(settings);
        }
    }
}
