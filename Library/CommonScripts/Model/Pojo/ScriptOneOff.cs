using CommonScripts.Model.Pojo.Base;

namespace CommonScripts.Model.Pojo
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
