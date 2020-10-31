using CommonScripts.Model.Pojo.Base;
using System.Threading.Tasks;

namespace CommonScripts.Model.Service.Interfaces
{
    public interface IRunScriptService
    {
        Task Run();
        Task RunScript(ScriptAbs script);
        Task StopScript(ScriptAbs script);
        Task Stop();
    }
}
