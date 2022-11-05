using Contracts.Scripts.Base;

namespace Data.Service.Interfaces
{
    public interface IScriptsService
    {
        List<ScriptAbs> GetScripts();
        void DeleteScript(string scriptId);
        void UpdateScript(ScriptAbs script);
        void AddScript(ScriptAbs script);
    }
}
