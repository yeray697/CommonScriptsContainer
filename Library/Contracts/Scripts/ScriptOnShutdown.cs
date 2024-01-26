using Contracts.Scripts.Base;

namespace Contracts.Scripts
{
    public class ScriptOnShutdown : ScriptAbs
    {
        public override ScriptType ScriptType => ScriptType.OnShutdown;

        public ScriptOnShutdown() : base()
        {

        }
        protected ScriptOnShutdown(ScriptOnShutdown script) : base(script)
        {

        }
        public override ScriptAbs Clone() => new ScriptOnShutdown(this);
    }
}
