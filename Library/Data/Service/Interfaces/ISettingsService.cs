using Contracts.Config;

namespace Data.Service.Interfaces
{
    public interface ISettingsService
    {
        Task<Settings> ReadSettingsAsync();
        Task UpdateSettingsAsync(Settings settings);
    }
}
