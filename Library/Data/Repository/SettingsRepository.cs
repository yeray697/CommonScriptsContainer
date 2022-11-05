using Data.Repository.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Data.Repository
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly JsonSerializerOptions _options;
        public SettingsRepository()
        {
            _options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                WriteIndented = true
            };
        }
        public bool FileExists(string path)
            => File.Exists(path);

        public async Task<T> GetFileAsync<T>(string path)
            => JsonSerializer.Deserialize<T>(await File.ReadAllTextAsync(path), _options)!;

        public async Task UpdateFileAsync(object file, string path)
            => await File.WriteAllTextAsync(path, JsonSerializer.Serialize(file, _options));
    }
}
