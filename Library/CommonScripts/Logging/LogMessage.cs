using Serilog.Events;

namespace CommonScripts.Logging
{
    public class LogMessage
    {
        public const string VERBOSE_STRING = "[VERBOSE]";
        public const string DEBUG_STRING = "[DEBUG]";
        public const string INFO_STRING = "[INFO]";
        public const string WARNING_STRING = "[WARNING]";
        public const string ERROR_STRING = "[ERROR]";
        public const string FATAL_STRING = "[FATAL]";

        public LogEventLevel Lvl;
        public string Text;
        public string TimeStamp;

        public override string ToString()
        {
            return TimeStamp + " " + LevelToSeverity() + " " + Text;
        }
        private string LevelToSeverity()
        {
            return Lvl switch
            {
                LogEventLevel.Debug => DEBUG_STRING,
                LogEventLevel.Error => ERROR_STRING,
                LogEventLevel.Fatal => FATAL_STRING,
                LogEventLevel.Verbose => VERBOSE_STRING,
                LogEventLevel.Warning => WARNING_STRING,
                _ => INFO_STRING,
            };
        }
    }
}
