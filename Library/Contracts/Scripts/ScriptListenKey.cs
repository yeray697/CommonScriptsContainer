using Contracts.Key;
using Contracts.Scripts.Base;

namespace Contracts.Scripts
{
    public class ScriptListenKey : ScriptAbs
    {
        public override ScriptType ScriptType => ScriptType.ListenKey;
        public KeyPressed? TriggerKey { get; set; }

        public ScriptListenKey() : base()
        {

        }
        protected ScriptListenKey(ScriptListenKey script) : base(script)
        {
            TriggerKey = script.TriggerKey;
        }
        public override ScriptAbs Clone() => new ScriptListenKey(this);
    }
}
