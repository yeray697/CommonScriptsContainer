using Data.Converter;
using System.Text.Json;

namespace Data.Repository
{
    public class FileRepository : IFileRepository
    {
        private JsonSerializerOptions _options;
        public FileRepository()
        {
            _options = new JsonSerializerOptions
            {
                Converters = { new ScriptJsonConverter() },
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
