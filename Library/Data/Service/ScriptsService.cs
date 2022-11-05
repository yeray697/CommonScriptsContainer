using Contracts.Scripts.Base;
using Data.Repository.Interfaces;
using Data.Service.Interfaces;

namespace Data.Service
{
    public class ScriptsService : IScriptsService
    {
        private readonly IScriptsRepository _scriptsRepository;

        public ScriptsService(IScriptsRepository scriptsRepository)
        {
            _scriptsRepository = scriptsRepository;
        }

        public void AddScript(ScriptAbs script)
            => _scriptsRepository.AddScript(script);

        public void DeleteScript(string scriptId)
            => _scriptsRepository.DeleteScript(scriptId);

        public List<ScriptAbs> GetScripts()
            => _scriptsRepository.GetScripts();

        public void UpdateScript(ScriptAbs script)
            => _scriptsRepository.UpdateScript(script);
    }
}
