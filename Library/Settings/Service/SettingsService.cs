using Common;
using Contracts.Config;
using Contracts.Scripts.Base;
using Data.Repository;

namespace Data.Service
{
    public class SettingsService : ISettingsService
    {
        private readonly IFileRepository _fileRepository;
        private const string SettingsFileName = "settings.json";
        private const string ScriptsFileName = "scripts.json";
        
        public SettingsService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<List<ScriptAbs>> ReadScriptsAsync()
            => await ReadFileAsync< List<ScriptAbs>>(GetScriptsPath());
        
        public async Task<Settings> ReadSettingsAsync()
            => await ReadFileAsync<Settings>(GetConfigPath());

        public async Task UpdateScriptsAsync(List<ScriptAbs> scripts)
            => await _fileRepository.UpdateFileAsync(scripts, GetScriptsPath());

        public async Task UpdateSettingsAsync(Settings settings)
            => await _fileRepository.UpdateFileAsync(settings, GetConfigPath());

        private async Task<T> ReadFileAsync<T>(string filePath)
            where T : new()
        {
            T fileContent;

            if (!_fileRepository.FileExists(filePath))
            {
                fileContent = new();
                CreateDirectoryIfNotExists(filePath);
                await _fileRepository.UpdateFileAsync(fileContent, filePath);
            }
            else
                fileContent = await _fileRepository.GetFileAsync<T>(filePath);

            return fileContent;
        }

        private static void CreateDirectoryIfNotExists(string filePath)
        {
            string? directoryPath = Path.GetDirectoryName(filePath);
            if (directoryPath == null)
                throw new ArgumentNullException(directoryPath);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }

        private static string GetFilePath(string configFilename)
            => Path.Combine(FileUtils.GetConfigDirectory(), configFilename);

        private static string GetConfigPath()
            => GetFilePath(SettingsFileName);

        private static string GetScriptsPath()
            => GetFilePath(ScriptsFileName);
    }
}
