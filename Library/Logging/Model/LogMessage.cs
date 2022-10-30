using Serilog.Events;

namespace Logging.Model
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
        public Exception Exception;

        public LogMessage(LogEventLevel lvl, string text, string timeStamp, Exception exception)
        {
            Lvl = lvl;
            Text = text;
            TimeStamp = timeStamp;
            Exception = exception;
        }

        public override string ToString()
        {
            string text = TimeStamp + " " + LevelToSeverity() + " " + Text;

            if (Lvl == LogEventLevel.Error && Exception != null)
                text += "\r\n" + Exception;

            return text;
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
