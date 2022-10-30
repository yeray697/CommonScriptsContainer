namespace Contracts.Config
{
    public class Settings : ISettingsFile<Settings>
    {
        public CoreSettings Core { get; set; }
        public AppSettings App { get; set; }

        public Settings()
        {
            Core = new();
            App = new();
        }
        public Settings(CoreSettings core, AppSettings app)
        {
            Core = core;
            App = app;
        }

        public void CopyFrom(Settings settings)
        {
            Core.CopyFrom(settings.Core);
            App.CopyFrom(settings.App);
        }

        object ICloneable.Clone()
            => Clone();

        public object Clone()
            => new Settings(Core.Clone(), App.Clone());

        public override bool Equals(object? obj)
            => Equals(obj as Settings);

        public bool Equals(Settings? other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Core.Equals(other.Core) && App.Equals(other.App);
        }

        public override int GetHashCode()
            => unchecked(Core.GetHashCode() ^ App.GetHashCode());
    }
}