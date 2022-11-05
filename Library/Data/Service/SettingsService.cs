using Contracts.Config;
using Data.Repository.Interfaces;
using Data.Service.Interfaces;

namespace Data.Service
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _fileRepository;
        
        public SettingsService(ISettingsRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        
        public async Task<Settings> ReadSettingsAsync()
            => await _fileRepository.ReadSettingsAsync();

        public async Task UpdateSettingsAsync(Settings settings)
            => await _fileRepository.UpdateSettingsAsync(settings);
    }
}
