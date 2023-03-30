using Contracts.Scripts;
using Contracts.Scripts.Base;
using JobManager;

namespace DesktopClient.Mapper
{
    public static class ScriptMapper
    {
        public static ScriptAbs MapGrpcRequestToScript(ScriptRequest scriptRequest)
        {
            ScriptAbs script;

            if (scriptRequest.ScheduledHour == null)
            {
                script = new ScriptOneOff();
            }
            else
            {
                script = new ScriptScheduled();
                var dt = scriptRequest.ScheduledHour.ToDateTime();
                var ts = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                ((ScriptScheduled)script).ScheduledHour = ts;
            }

            script.Id = scriptRequest.Id;
            script.ScriptName = scriptRequest.Name;
            script.ScriptPath = scriptRequest.Path;

            return script;
        }
    }
}
