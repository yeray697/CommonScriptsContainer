using Contracts.Config;
using Data.Repository.Interfaces;

namespace Data
{
    public class SettingsManager
    {
        private static SettingsManager? _instance;

        private readonly ISettingsRepository _settingsRepository;
        private Settings? _settings;

        private SettingsManager(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public static Settings Settings
            => GetInstance().GetSettings();

        public static Settings CloneSettings
            => (Settings)GetInstance().GetSettings().Clone();

        public static async Task InitInstanceAsync(ISettingsRepository settingsRepository)
        {
            _instance = new(settingsRepository);
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
            _settings = await _settingsRepository.ReadSettingsAsync();
        }

        private Settings GetSettings()
            => _settings!;

        private async Task UpdateSettingsFileAsync(Settings newSettings)
        {
            if (newSettings.Equals(_settings))
                return;
            await _settingsRepository.UpdateSettingsAsync(newSettings);
            _settings = newSettings;
        }
    }
}
