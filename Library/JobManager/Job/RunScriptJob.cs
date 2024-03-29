﻿using Common;
using Contracts.Scripts.Base;
using Quartz;
using Serilog;
using System.Management.Automation;

namespace JobManager.Job
{
    public class RunScriptJob : IJob
    {
        private ScriptAbs? _script;

        public async Task Execute(IJobExecutionContext context)
        {
            GetScript(context);
            await RunScript();
        }
        private void GetScript(IJobExecutionContext context)
        {
            var dataMap = context.MergedJobDataMap;
            _script = (ScriptAbs)dataMap["script"];
        }
        private Task RunScript()
        {
            string realPath = FileUtils.GetAbsolutePath(_script!.ScriptPath);
            try
            {
                if (File.Exists(realPath))
                {
                    Log.Information("Executing {@ScriptName}", _script.ScriptName);
                    string psScript = $"Set-Location \"{Path.GetDirectoryName(realPath)}\"{Environment.NewLine}";
                    psScript += File.ReadAllText(realPath);
                    Log.Verbose("Script content: {ScriptContent}", psScript);
                    using var powerShell = PowerShell.Create();
                    string output = "";
                    var scriptOutput = powerShell
                        .AddScript(psScript)
                        .Invoke();
                    foreach (var line in scriptOutput)
                        output += line + Environment.NewLine;
                    if (string.IsNullOrWhiteSpace(output))
                        output = "(no output)";
                    Log.Debug("Script output: {Output}", output.TrimEnd());
                }
                else
                {
                    Log.Warning("Script {@ScriptName} could not run. Script Path not found {@ScriptPath}", _script.ScriptName, realPath);
                }
                Log.Information("Job {@ScriptName} finished", _script.ScriptName);
            }
            catch (Exception e)
            {
                Log.Error(e, "An error has occurred while executing the script {@ScriptName} ({@ScriptPath})", _script.ScriptName, realPath);
            }

            return Task.CompletedTask;
        }
    }
}
