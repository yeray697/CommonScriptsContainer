using Contracts.Scripts.Base;
using Quartz;

namespace JobManager.Service
{
    public interface IRunScriptService
    {
        Task Run();
        Task RunScript(ScriptAbs script);
        Task StopScript(ScriptAbs script);
        Task Stop();
        void SetOneOffJobListener(IJobListener jobListener);
    }
}
