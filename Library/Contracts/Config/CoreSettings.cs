namespace Contracts.Config
{
    public class CoreSettings : ISettingsFile<CoreSettings>
    {
        public string InstallationPath { get; set; }
        public bool DoNotAskAgainRunStartup { get; set; }
        public LogLevel LoggingLevel { get; set; }

        public CoreSettings()
        {
            InstallationPath = string.Empty;
            DoNotAskAgainRunStartup = true;
            LoggingLevel = LogLevel.Information;
        }

        public CoreSettings(string installationPath, bool doNotAskAgainRunStartup, LogLevel loggingLevel)
        {
            InstallationPath = installationPath;
            DoNotAskAgainRunStartup = doNotAskAgainRunStartup;
            LoggingLevel = loggingLevel;
        }

        public void CopyFrom(CoreSettings settings)
        {
            InstallationPath = settings.InstallationPath;
            DoNotAskAgainRunStartup = settings.DoNotAskAgainRunStartup;
            LoggingLevel = settings.LoggingLevel;
        }

        object ICloneable.Clone()
            => Clone();

        public CoreSettings Clone()
            => new(InstallationPath, DoNotAskAgainRunStartup, LoggingLevel);

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
                && LoggingLevel == other.LoggingLevel;
        }

        public override int GetHashCode()
            => unchecked(InstallationPath.GetHashCode() ^ DoNotAskAgainRunStartup.GetHashCode() ^ LoggingLevel.GetHashCode());
    }
}
