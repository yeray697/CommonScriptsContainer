using Contracts.Scripts.Base;

namespace Contracts.Scripts
{
    public class ScriptScheduled : ScriptAbs
    {
        public override ScriptType ScriptType => ScriptType.Scheduled;
        public TimeSpan ScheduledHour { get; set; }

        public ScriptScheduled() : base()
        {

        }
        protected ScriptScheduled(ScriptScheduled script) : base(script)
        {
            ScheduledHour = script.ScheduledHour;
        }
        public override ScriptAbs Clone() => new ScriptScheduled(this);
    }
}
