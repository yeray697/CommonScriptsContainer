using CommonScripts.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonScripts.Model
{
    public class ScriptOneOff : ScriptAbs
    {
        public override ScriptType ScriptType => ScriptType.OneOff;

        public ScriptOneOff() : base()
        {

        }

        protected ScriptOneOff(ScriptOneOff script) : base(script)
        {

        }

        public override ScriptAbs Clone() => new ScriptOneOff(this);
    }
}
