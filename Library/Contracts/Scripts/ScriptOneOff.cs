using Contracts.Scripts.Base;

namespace Contracts.Scripts
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
