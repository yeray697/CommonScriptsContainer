using Contracts.Scripts.Base;

namespace JobManager.Service
{
    public interface IRunScriptService
    {
        delegate void ScriptExecutedHandler(string scriptId);
        event ScriptExecutedHandler? OneOffScriptExecuted;
        event ScriptExecutedHandler? ScriptStarted;
        Task RunServiceAsync();
        Task RunScriptAsync(ScriptAbs script);
        Task StopScriptAsync(ScriptAbs script);
        Task StopServiceAsync();
    }
}
