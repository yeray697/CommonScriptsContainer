using System;

namespace CommonScripts.Model
{
    public class Script : ICloneable
    {
        public enum Type { OneOff = 0, Scheduled = 1, Daemon = 2}
        public enum Status { Undefined = 0, Running = 1, Resuming = 2, Stopped = 3 }

        public int Id { get; set; }
        public string ScriptName { get; set; }
        public Type ScriptType { get; set; }
        public Status ScriptStatus { get; set; }
        public string ScriptPath { get; set; }

        public Script()
        {
            Id = -1;
            ScriptName = "";
            ScriptType = Type.OneOff;
            ScriptStatus = Status.Undefined;
        }

        public Script Clone()
        {
            Script script = new Script();
            script.Id = this.Id;
            script.ScriptName = this.ScriptName;
            script.ScriptType = this.ScriptType;
            script.ScriptStatus = this.ScriptStatus;
            script.ScriptPath = this.ScriptPath;

            return script;
        }

        object ICloneable.Clone() => Clone();
    }
}
