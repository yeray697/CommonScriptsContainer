using CommonScripts.Model.Pojo.Base;
using Quartz;
using System;
using System.Threading.Tasks;

namespace CommonScripts.Model.Service.Job
{
    public class RunScriptJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var script = GetScript(context);
            await Console.Out.WriteLineAsync("Executing " + script.ScriptName); //ToDo
        }

        private ScriptAbs GetScript(IJobExecutionContext context)
        {
            var dataMap = context.MergedJobDataMap;
            return (ScriptAbs)dataMap["script"];
        }
    }
}
