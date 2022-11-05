using Contracts.Config;

namespace Data.Repository.Interfaces
{
    public interface ISettingsRepository
    {
        Task<Settings> ReadSettingsAsync();
        Task UpdateSettingsAsync(object file);
    }
}
