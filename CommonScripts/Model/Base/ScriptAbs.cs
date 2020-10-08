using System;

namespace CommonScripts.Model.Base
{
    public abstract class ScriptAbs : ICloneable, IScript
    {

        public string Id { get; set; }
        public string ScriptName { get; set; }
        public abstract ScriptType ScriptType { get; }
        public ScriptStatus ScriptStatus { get; set; }
        public string ScriptPath { get; set; }

        protected ScriptAbs()
        {
            Id = "";
            ScriptName = "";
            ScriptStatus = ScriptStatus.Undefined;
            ScriptPath = "";
        }

        protected ScriptAbs(ScriptAbs script)
        {
            Id = script.Id;
            ScriptName = script.ScriptName;
            ScriptStatus = script.ScriptStatus;
            ScriptPath = script.ScriptPath;
        }

        public abstract ScriptAbs Clone();

        object ICloneable.Clone() => Clone();

        public static ScriptAbs GetInstance(ScriptAbs oldScript, ScriptType scriptType, bool hasScriptTypeChanged)
        {
            ScriptAbs newScript = null;
            if (oldScript == null || hasScriptTypeChanged)
            {
                switch (scriptType)
                {
                    case ScriptType.OneOff:
                        newScript = new ScriptOneOff();
                        break;
                    case ScriptType.Scheduled:
                        newScript = new ScriptScheduled();
                        break;
                    case ScriptType.ListenKey:
                        newScript = new ScriptListenKey();
                        break;
                    default:
                        throw new Exception();
                }
                if (hasScriptTypeChanged)
                {
                    newScript.Id = oldScript.Id;
                }
            }

            return newScript != null ? newScript : oldScript;
        }
    }
}
