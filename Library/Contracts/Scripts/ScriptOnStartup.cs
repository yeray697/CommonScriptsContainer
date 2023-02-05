using Contracts.Scripts.Base;

namespace Contracts.Scripts
{
    public class ScriptOnStartup : ScriptAbs
    {
        public override ScriptType ScriptType => ScriptType.OnStartup;

        public ScriptOnStartup() : base()
        {

        }
        protected ScriptOnStartup(ScriptOnStartup script) : base(script)
        {

        }
        public override ScriptAbs Clone() => new ScriptOnStartup(this);
    }
}
