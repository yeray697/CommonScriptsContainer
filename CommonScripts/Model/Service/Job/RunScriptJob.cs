using CommonScripts.Model.Pojo.Base;
using Quartz;
using Serilog;
using System.IO;
using System.Management.Automation;
using System.Threading.Tasks;

namespace CommonScripts.Model.Service.Job
{
    public class RunScriptJob : IJob
    {
        private ScriptAbs _script;

        public async Task Execute(IJobExecutionContext context)
        {
            GetScript(context);
            RunScript();
        }

        private void GetScript(IJobExecutionContext context)
        {
            var dataMap = context.MergedJobDataMap;
            _script = (ScriptAbs)dataMap["script"];
        }

        private void RunScript()
        {
            if (File.Exists(_script.ScriptPath))
            {
                Log.Information("Executing {@ScriptName}", _script.ScriptName);
                string psScript = File.ReadAllText(_script.ScriptPath);
                var powerShell = PowerShell.Create().AddScript(psScript);
                powerShell.Invoke();
            } else
            {
                Log.Warning("Script {@ScriptName} could not run. Script Path not found {@ScriptPath}", _script.ScriptName, _script.ScriptPath);
            }
            Log.Information("Job {@ScriptName} finished", _script.ScriptName);
        }
    }
}
