using Contracts.Config;
using Contracts.Scripts.Base;
using Data.Service;

namespace Data
{
    public class SettingsManager
    {
        private static SettingsManager? _instance;

        private readonly ISettingsService _settingsService;
        private Settings? _settings;
        private List<ScriptAbs>? _scripts;

        private SettingsManager(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public static Settings Settings
            => GetInstance().GetSettings();

        public static Settings CloneSettings
            => (Settings)GetInstance().GetSettings().Clone();

        public static List<ScriptAbs> Scripts
            => GetInstance().GetScripts();

        public static ScriptAbs? FindScriptById(string scriptId)
            => GetInstance().GetScripts().FirstOrDefault(s => s.Id == scriptId)?.Clone();

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

        public static async Task UpdateScriptsAsync(List<ScriptAbs> newScripts)
            => await GetInstance().UpdateScriptsFileAsync(newScripts);

        public static async Task AddScriptAsync(ScriptAbs newScript)
            => await UpdateScriptsAsync(scripts => scripts.Add(newScript));

        public static async Task EditScriptAsync(ScriptAbs scriptToEdit)
        {
            int index = Scripts.FindIndex(s => s.Id == scriptToEdit.Id);
            if (index == -1) 
                return;
            await UpdateScriptsAsync(scripts => scripts[index] = scriptToEdit);
        }

        public static async Task RemoveScriptAsync(string scriptId)
        {
            var scriptToDelete = Scripts.FirstOrDefault(s => s.Id == scriptId);
            if (scriptToDelete == null)
                return;
            await UpdateScriptsAsync(scripts => scripts.Remove(scriptToDelete));
        }

        public static async Task UpdateScriptsAsync(Action<List<ScriptAbs>> action)
        {
            List<ScriptAbs> scripts = GetInstance().GetScripts();
            action(scripts);
            await UpdateScriptsAsync(scripts);
        }

        private static SettingsManager GetInstance()
            => _instance ?? throw new ArgumentNullException("Instance is not initiated. Call InitInstance() method first");

        private async Task InitConfigFilesAsync()
        {
            _settings = await _settingsService.ReadSettingsAsync();
            _scripts = await _settingsService.ReadScriptsAsync();
        }

        private Settings GetSettings()
            => _settings!;

        private List<ScriptAbs> GetScripts()
            => _scripts!;

        private async Task UpdateSettingsFileAsync(Settings newSettings)
        {
            if (newSettings.Equals(_settings))
                return;
            await _settingsService.UpdateSettingsAsync(newSettings);
            _settings = newSettings;
        }
        private async Task UpdateScriptsFileAsync(List<ScriptAbs> newScripts)
        {
            await _settingsService.UpdateScriptsAsync(newScripts);
            _scripts = newScripts;
        }
    }
}
