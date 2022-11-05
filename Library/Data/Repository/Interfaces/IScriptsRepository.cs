using Contracts.Scripts.Base;

namespace Data.Repository.Interfaces
{
    public interface IScriptsRepository
    {
        List<ScriptAbs> GetScripts();
        void DeleteScript(string scriptId);
        void UpdateScript(ScriptAbs script);
        void AddScript(ScriptAbs script);
    }
}
