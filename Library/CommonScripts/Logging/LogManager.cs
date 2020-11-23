using CommonScripts.Settings;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace CommonScripts.Logging
{
    public static class LogManager
    {
        private const string LOG_PATH = @"logs\CommonScripts.log";
        private static LoggingLevelSwitch _levelSwitch;
        private static LogSink _consoleLogSink;
        public static void InstanceLogger()
        {
            _consoleLogSink = new LogSink();
            _levelSwitch = new LoggingLevelSwitch(AppSettingsManager.GetFileMinLogLevel());
            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(_levelSwitch)
                .MinimumLevel.Override("Quartz", LogEventLevel.Warning);

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
