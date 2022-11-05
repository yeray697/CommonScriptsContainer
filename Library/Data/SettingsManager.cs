using Contracts.Config;
using Data.Service.Interfaces;

namespace Data
{
    public class SettingsManager
    {
        private static SettingsManager? _instance;

        private readonly ISettingsService _settingsService;
        private Settings? _settings;

        private SettingsManager(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public static Settings Settings
            => GetInstance().GetSettings();

        public static Settings CloneSettings
            => (Settings)GetInstance().GetSettings().Clone();

        public static async Task InitInstanceAsync(ISettingsService settingsService)
        {
            _instance = new(settingsService);
            await _instance.InitConfigFilesAsync();
        }

        public static async Task UpdateSettingsAsync(Settings newSettings)
            => await GetInstance().UpdateSettingsFileAsync(newSettings);

        public static async Task UpdateSettingsAsync(Action<Settings> action)
        {
            Settings settings = CloneSettings;
            action(settings);
            await UpdateSettingsAsync(settings);
        }

        private static SettingsManager GetInstance()
            => _instance ?? throw new ArgumentNullException("Instance is not initiated. Call InitInstance() method first");

        private async Task InitConfigFilesAsync()
        {
            _settings = await _settingsService.ReadSettingsAsync();
        }

        private Settings GetSettings()
            => _settings!;

        private async Task UpdateSettingsFileAsync(Settings newSettings)
        {
            if (newSettings.Equals(_settings))
                return;
            await _settingsService.UpdateSettingsAsync(newSettings);
            _settings = newSettings;
        }
    }
}
