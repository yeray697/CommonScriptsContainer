namespace Contracts.Config
{
    public class AppSettings : ISettingsFile<AppSettings>
    {
        public bool DarkMode { get; set; }
        public LogLevel LoggingLevel { get; set; }

        public AppSettings()
        {
            DarkMode = false;
            LoggingLevel = LogLevel.Information;
        }
        public AppSettings(bool darkMode, LogLevel loggingLevel)
        {
            DarkMode = darkMode;
            LoggingLevel = loggingLevel;
        }

        public void CopyFrom(AppSettings settings)
        {
            DarkMode = settings.DarkMode;
            LoggingLevel = settings.LoggingLevel;
        }

        object ICloneable.Clone()
            => Clone();

        public AppSettings Clone()
            => new(DarkMode, LoggingLevel);

        public override bool Equals(object? obj)
            => Equals(obj as AppSettings);

        public bool Equals(AppSettings? other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return DarkMode == other.DarkMode
                && LoggingLevel == other.LoggingLevel;
        }

        public override int GetHashCode()
            => unchecked(DarkMode.GetHashCode() ^ LoggingLevel.GetHashCode());
    }
}
