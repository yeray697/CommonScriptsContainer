using Contracts.Scripts.Base;

namespace JobManager.Service
{
    public interface IRunScriptService
    {
        delegate void ScriptExecutedHandler(string scriptId);
        event ScriptExecutedHandler? OneOffScriptExecuted;
        event ScriptExecutedHandler? ScriptStarted;
        event ScriptExecutedHandler? ScriptStopped;
        Task RunServiceAsync();
        Task RunScriptAsync(ScriptAbs script);
        Task StopScriptAsync(ScriptAbs script);
        Task StopServiceAsync();
    }
}
