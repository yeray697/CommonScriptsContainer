using CommonScripts.Settings;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace CommonScripts.Logging
{
    public static class LogManager
    {
        private const string LOG_PATH = @"logs\CommonScripts.log";
        private const string QUARTZ_SERILOG = "Quartz";
        private const string MICROSOFT_SERILOG = "Microsoft";
        private static LoggingLevelSwitch _levelSwitch;
        private static LogSink _consoleLogSink;

        public static void InstanceLogger()
        {
            _consoleLogSink = new LogSink();
            _levelSwitch = new LoggingLevelSwitch(AppSettingsManager.GetFileMinLogLevel());
            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(_levelSwitch)
                .MinimumLevel.Override(QUARTZ_SERILOG, LogEventLevel.Warning)
                .MinimumLevel.Override(MICROSOFT_SERILOG, LogEventLevel.Warning);

            loggerConfiguration
                .WriteTo.Console()
                .WriteTo.File(LOG_PATH)
                .WriteTo.Sink(_consoleLogSink);

            Log.Logger = loggerConfiguration.CreateLogger();
        }
        public static void ChangeMinLoggingLevel(LogEventLevel newLogLevel)
        {
            _levelSwitch.MinimumLevel = newLogLevel;
        }
        internal static LogSink GetConsoleSink()
        {
            return _consoleLogSink;
        }
    }
}
