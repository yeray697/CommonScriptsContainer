namespace Contracts.Scripts.Base
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
        public static ScriptAbs? GetInstance(ScriptAbs? oldScript, ScriptType scriptType)
        {
            bool hasScriptTypeChanged = oldScript != null && HasScriptTypeChanged(oldScript.ScriptType, scriptType);
            ScriptAbs? newScript = null;
            if (oldScript == null || hasScriptTypeChanged)
            {
                newScript = scriptType switch
                {
                    ScriptType.OneOff => new ScriptOneOff(),
                    ScriptType.Scheduled => new ScriptScheduled(),
                    ScriptType.ListenKey => new ScriptListenKey(),
                    ScriptType.OnStartup => new ScriptOnStartup(),
                    ScriptType.OnShutdown => new ScriptOnShutdown(),
                    _ => throw new Exception(),
                };
                if (hasScriptTypeChanged && oldScript != null)
                {
                    newScript!.Id = oldScript.Id;
                }
            }

            return newScript ?? oldScript;
        }
        public static bool HasScriptTypeChanged(ScriptType oldScriptType, ScriptType newScriptType) => oldScriptType != newScriptType;
        public static bool HasScheduledTimeChanged(ScriptAbs script, ScriptAbs editedScript) =>
            script.ScriptType == ScriptType.Scheduled
            && ((ScriptScheduled)script).ScheduledHour != ((ScriptScheduled)editedScript).ScheduledHour;
    }
}
