namespace Contracts.Config
{
    public class CoreSettings : ISettingsFile<CoreSettings>
    {
        public string InstallationPath { get; set; }
        public bool DoNotAskAgainRunStartup { get; set; }
        public bool EnableGrpcServer { get; set; }
        public bool EnableWebClient { get; set; }
        public LogLevel LoggingLevel { get; set; }

        public CoreSettings()
        {
            InstallationPath = string.Empty;
            DoNotAskAgainRunStartup = true;
            EnableGrpcServer = true;
            EnableWebClient = true;
            LoggingLevel = LogLevel.Information;
        }

        public CoreSettings(string installationPath, bool doNotAskAgainRunStartup, bool enableGrpcServer, bool enableWebClient, LogLevel loggingLevel)
        {
            InstallationPath = installationPath;
            DoNotAskAgainRunStartup = doNotAskAgainRunStartup;
            EnableGrpcServer = enableGrpcServer;
            EnableWebClient = enableWebClient;
            LoggingLevel = loggingLevel;
        }

        public void CopyFrom(CoreSettings settings)
        {
            InstallationPath = settings.InstallationPath;
            DoNotAskAgainRunStartup = settings.DoNotAskAgainRunStartup;
            LoggingLevel = settings.LoggingLevel;
            EnableGrpcServer = settings.EnableGrpcServer;
            EnableWebClient = settings.EnableWebClient;
        }

        object ICloneable.Clone()
            => Clone();

        public CoreSettings Clone()
            => new(InstallationPath, DoNotAskAgainRunStartup, EnableGrpcServer, EnableWebClient, LoggingLevel);

        public override bool Equals(object? obj)
            => Equals(obj as CoreSettings);

        public bool Equals(CoreSettings? other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return InstallationPath == other.InstallationPath
                && DoNotAskAgainRunStartup == other.DoNotAskAgainRunStartup
                && EnableGrpcServer == other.EnableGrpcServer
                && EnableWebClient == other.EnableWebClient
                && LoggingLevel == other.LoggingLevel;
        }

        public override int GetHashCode()
            => unchecked(InstallationPath.GetHashCode() ^ DoNotAskAgainRunStartup.GetHashCode() ^ EnableGrpcServer.GetHashCode() ^ EnableWebClient.GetHashCode() ^ LoggingLevel.GetHashCode());
    }
}
