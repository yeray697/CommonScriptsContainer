using CommonScripts.Model.Base;
using CommonScripts.Repository.Interfaces;
using CommonScripts.Service.Interfaces;
using System.Collections.Generic;

namespace CommonScripts.Service
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
            return _repository.GetScripts();
        }

        public bool SaveScripts(List<ScriptAbs> scripts)
        {
            return _repository.SaveScripts(scripts);
        }
    }
}
