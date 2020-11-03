using CommonScripts.Model.Pojo.Base;
using Quartz;
using Serilog;
using System.Diagnostics;
using System.IO;
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
                Log.Information("Executing \"{@ScriptName}\"", _script.ScriptName);
                var process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";
                process.StartInfo.Arguments = "-File \""+ _script.ScriptPath + "\"";

                process.Start();
                process.WaitForExit();
            } else
            {
                Log.Warning("Script \"{@ScriptName}\" could not run. Script Path not found \"{@ScriptPath}\"", _script.ScriptName, _script.ScriptPath);
            }
        }
    }
}
