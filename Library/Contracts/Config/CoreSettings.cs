namespace Contracts.Config
{
    public class CoreSettings : ISettingsFile<CoreSettings>
    {
        public bool EnableGrpcServer { get; set; }
        public bool EnableWebClient { get; set; }
        public LogLevel LoggingLevel { get; set; }

        public CoreSettings()
        {
            EnableGrpcServer = true;
            EnableWebClient = true;
            LoggingLevel = LogLevel.Information;
        }

        public CoreSettings(bool enableGrpcServer, bool enableWebClient, LogLevel loggingLevel)
        {
            EnableGrpcServer = enableGrpcServer;
            EnableWebClient = enableWebClient;
            LoggingLevel = loggingLevel;
        }

        public void CopyFrom(CoreSettings settings)
        {
            LoggingLevel = settings.LoggingLevel;
            EnableGrpcServer = settings.EnableGrpcServer;
            EnableWebClient = settings.EnableWebClient;
        }

        object ICloneable.Clone()
            => Clone();

        public CoreSettings Clone()
            => new(EnableGrpcServer, EnableWebClient, LoggingLevel);

        public override bool Equals(object? obj)
            => Equals(obj as CoreSettings);

        public bool Equals(CoreSettings? other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return EnableGrpcServer == other.EnableGrpcServer
                && EnableWebClient == other.EnableWebClient
                && LoggingLevel == other.LoggingLevel;
        }

        public override int GetHashCode()
            => unchecked(EnableGrpcServer.GetHashCode() ^ EnableWebClient.GetHashCode() ^ LoggingLevel.GetHashCode());
    }
}
