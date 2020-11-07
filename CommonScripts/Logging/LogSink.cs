using Serilog.Core;
using Serilog.Events;
using System;

namespace CommonScripts.Logging
{
    public class LogSink : ILogEventSink
    {
        public delegate void LogHandler(LogMsg log);
        public event LogHandler LogEmitted;

        public void Emit(LogEvent logEvent)
        {
            var t = logEvent.Timestamp;
            LogMsg msg = new LogMsg()
            {
                Text = logEvent.RenderMessage(),
                Lvl = logEvent.Level,
                TimeStamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + " -" + t.Offset.ToString(@"hh\:mm"),
            };

            LogEmitted?.Invoke(msg);
        }
    }

    public struct LogMsg
    {
        public LogEventLevel Lvl;
        public string Text;
        public string TimeStamp;

        public override string ToString()
        {
            return TimeStamp + " " + LevelToSeverity() + " " + Text;
        }

        private string LevelToSeverity()
        {
            switch (Lvl)
            {
                case LogEventLevel.Debug:
                    return "[DEBUG]";
                case LogEventLevel.Error:
                    return "[ERROR]";
                case LogEventLevel.Fatal:
                    return "[FATAL]";
                case LogEventLevel.Verbose:
                    return "[VERBOSE]";
                case LogEventLevel.Warning:
                    return "[WARNING]";
                default:
                    return "[INFO]";
            }
        }
    }
}
