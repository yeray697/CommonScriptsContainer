namespace CommonScripts.Model
{
    public class Script
    {
        public enum Type { OneOff, Scheduled, Daemon }
        public enum Status { Undefined, Running, Resuming, Stopped }

        public int Id { get; set; }
        public string ScriptName { get; set; }
        public Type ScriptType { get; set; }
        public Status ScriptStatus { get; set; }
        public string ScriptPath { get; set; }
    }
}
