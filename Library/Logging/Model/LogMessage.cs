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

        public LogLevel Level { get; private set; }
        public string Text { get; private set; }
        public string TimeStamp { get; private set; }
        public Exception? Exception { get; private set; }

        public LogMessage(LogLevel level, string text, string timeStamp, Exception? exception)
        {
            Level = level;
            Text = text;
            TimeStamp = timeStamp;
            Exception = exception;
        }

        public override string ToString()
        {
            string text = TimeStamp + " " + LevelToSeverity(Level) + " " + Text;

            if (Level == LogLevel.Error && Exception != null)
                text += Environment.NewLine + Exception;

            return text;
        }
        private static string LevelToSeverity(LogLevel level)
        {
            return level switch
            {
                LogLevel.Debug => DEBUG_STRING,
                LogLevel.Error => ERROR_STRING,
                LogLevel.Fatal => FATAL_STRING,
                LogLevel.Verbose => VERBOSE_STRING,
                LogLevel.Warning => WARNING_STRING,
                _ => INFO_STRING,
            };
        }
    }
}
