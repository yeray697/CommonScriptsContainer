using CommonScripts.Settings;
using Serilog.Core;
using Serilog.Events;
using System;

namespace CommonScripts.Logging
{
    public class LogSink : ILogEventSink
    {
        public delegate void LogHandler(LogMessage log);
        public event LogHandler LogEmitted;

        public void Emit(LogEvent logEvent)
        {
            if (logEvent.Level >= AppSettingsManager.GetConsoleMinLogLevel())
            {
                var t = logEvent.Timestamp;
                LogMessage msg = new LogMessage()
                {
                    Text = logEvent.RenderMessage(),
                    Lvl = logEvent.Level,
                    TimeStamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + " -" + t.Offset.ToString(@"hh\:mm"),
                    Exception = logEvent.Exception
                };

                LogEmitted?.Invoke(msg);
            }
        }
    }
}
