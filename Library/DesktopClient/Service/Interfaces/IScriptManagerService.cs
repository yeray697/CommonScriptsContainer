using Contracts.Scripts.Base;

namespace DesktopClient.Service.Interfaces
{
    public interface IScriptManagerService
    {
        delegate void ScriptHandler(ScriptAbs script);
        delegate void ScriptEditedHandler(ScriptAbs oldScript, ScriptAbs newScript);
        event ScriptHandler? ScriptAdded;
        event ScriptEditedHandler? ScriptEdited;
        event ScriptHandler? ScriptRemoved;
        event ScriptHandler? ScriptStatusChanged;

        List<ScriptAbs> GetScripts(bool refresh = false);
        void AddScript(ScriptAbs script);
        Task EditScriptAsync(ScriptAbs oldScript, ScriptAbs editedScript);
        void RemoveScript(ScriptAbs script);
        Task RunScriptAsync(ScriptAbs script);
        Task StopScriptAsync(ScriptAbs script);
    }
}
