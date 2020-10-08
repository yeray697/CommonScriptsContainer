using CommonScripts.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonScripts.Model
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
