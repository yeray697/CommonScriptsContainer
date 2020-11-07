using CommonScripts.Model.Pojo.Base;
using Quartz;
using System.Threading.Tasks;

namespace CommonScripts.Model.Service.Interfaces
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
