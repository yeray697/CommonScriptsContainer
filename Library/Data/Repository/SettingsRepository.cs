using Common;
using Contracts.Config;
using Data.Repository.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Data.Repository
{
    public class SettingsRepository : ISettingsRepository
    {
        private const string SettingsFileName = "settings.json";
        private readonly JsonSerializerOptions _options;

        public SettingsRepository()
        {
            _options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                WriteIndented = true
            };
        }

        public async Task<Settings> ReadSettingsAsync()
        {
            Settings fileContent;
            string settingsPath = GetSettingsPath();

            if (!File.Exists(settingsPath))
            {
                fileContent = new();
                CreateDirectoryIfNotExists(settingsPath);
                await UpdateSettingsAsync(fileContent);
            }
            else
                fileContent = JsonSerializer.Deserialize<Settings>(await File.ReadAllTextAsync(settingsPath), _options)!;

            return fileContent;
        }

        public async Task UpdateSettingsAsync(object file)
            => await File.WriteAllTextAsync(GetSettingsPath(), JsonSerializer.Serialize(file, _options));

        private static string GetSettingsPath()
            => Path.Combine(FileUtils.GetConfigDirectory(), SettingsFileName);

        private static void CreateDirectoryIfNotExists(string filePath)
        {
            string? directoryPath = Path.GetDirectoryName(filePath);
            if (directoryPath == null)
                throw new ArgumentNullException(directoryPath);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }
}
