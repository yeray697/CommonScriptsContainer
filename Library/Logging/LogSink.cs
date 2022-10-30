using Logging.Model;
using Serilog.Core;
using Serilog.Events;

namespace Logging
{
    public class LogSink : ILogEventSink
    {
        public delegate void LogHandler(LogMessage log);
        public event LogHandler? LogEmitted;

        private readonly LogEventLevel _minLoggingLevel;

        public LogSink(LogEventLevel minLoggingLevel)
        {
            _minLoggingLevel = minLoggingLevel;
        }

        public void Emit(LogEvent logEvent)
        {
            if (logEvent.Level >= _minLoggingLevel)
            {
                var t = logEvent.Timestamp;
                LogMessage msg = new((LogLevel)logEvent.Level,
                                     logEvent.RenderMessage(),
                                     DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + " -" + t.Offset.ToString(@"hh\:mm"),
                                     logEvent.Exception);

                LogEmitted?.Invoke(msg);
            }
        }
    }
}
