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
        {
            List<ScriptAbs> scripts;
            string filePath = GetScriptsPath();

            if (!_fileRepository.FileExists(filePath))
            {
                scripts = new List<ScriptAbs>();
                CreateDirectoryIfNotExists(filePath);
                await _fileRepository.UpdateFileAsync(scripts, filePath);
            }
            else
                scripts = await _fileRepository.GetFileAsync<List<ScriptAbs>>(filePath);

            return scripts;
        }

        public async Task<Settings> ReadSettingsAsync()
        {
            Settings settings;
            string filePath = GetConfigPath();
            
            if (!_fileRepository.FileExists(filePath))
            {
                settings = new Settings();
                CreateDirectoryIfNotExists(filePath);
                await _fileRepository.UpdateFileAsync(settings, filePath);
            }
            else
                settings = await _fileRepository.GetFileAsync<Settings>(filePath);

            return settings;
        }

        private void CreateDirectoryIfNotExists(string filePath)
        {
            string? directoryPath = Path.GetDirectoryName(filePath);
            if (directoryPath == null)
                throw new ArgumentNullException(directoryPath);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }

        public async Task UpdateScriptsAsync(List<ScriptAbs> scripts)
        {
            await _fileRepository.UpdateFileAsync(scripts, GetScriptsPath());
        }

        public async Task UpdateSettingsAsync(Settings settings)
        {
            await _fileRepository.UpdateFileAsync(settings, GetConfigPath());
        }

        private static string GetFilePath(string configFilename)
            => Path.Combine(FileUtils.GetConfigDirectory(), configFilename);

        private static string GetConfigPath()
            => GetFilePath(SettingsFileName);

        private static string GetScriptsPath()
            => GetFilePath(ScriptsFileName);
    }
}
