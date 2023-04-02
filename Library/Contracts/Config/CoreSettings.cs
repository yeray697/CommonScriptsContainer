namespace Contracts.Config
{
    public class CoreSettings : ISettingsFile<CoreSettings>
    {
        public bool DoNotAskAgainRunStartup { get; set; }
        public bool EnableGrpcServer { get; set; }
        public bool EnableWebClient { get; set; }
        public LogLevel LoggingLevel { get; set; }

        public CoreSettings()
        {
            DoNotAskAgainRunStartup = true;
            EnableGrpcServer = true;
            EnableWebClient = true;
            LoggingLevel = LogLevel.Information;
        }

        public CoreSettings(bool doNotAskAgainRunStartup, bool enableGrpcServer, bool enableWebClient, LogLevel loggingLevel)
        {
            DoNotAskAgainRunStartup = doNotAskAgainRunStartup;
            EnableGrpcServer = enableGrpcServer;
            EnableWebClient = enableWebClient;
            LoggingLevel = loggingLevel;
        }

        public void CopyFrom(CoreSettings settings)
        {
            DoNotAskAgainRunStartup = settings.DoNotAskAgainRunStartup;
            LoggingLevel = settings.LoggingLevel;
            EnableGrpcServer = settings.EnableGrpcServer;
            EnableWebClient = settings.EnableWebClient;
        }

        object ICloneable.Clone()
            => Clone();

        public CoreSettings Clone()
            => new(DoNotAskAgainRunStartup, EnableGrpcServer, EnableWebClient, LoggingLevel);

        public override bool Equals(object? obj)
            => Equals(obj as CoreSettings);

        public bool Equals(CoreSettings? other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return DoNotAskAgainRunStartup == other.DoNotAskAgainRunStartup
                && EnableGrpcServer == other.EnableGrpcServer
                && EnableWebClient == other.EnableWebClient
                && LoggingLevel == other.LoggingLevel;
        }

        public override int GetHashCode()
            => unchecked(DoNotAskAgainRunStartup.GetHashCode() ^ EnableGrpcServer.GetHashCode() ^ EnableWebClient.GetHashCode() ^ LoggingLevel.GetHashCode());
    }
}
