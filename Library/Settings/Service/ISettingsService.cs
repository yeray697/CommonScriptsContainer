using Contracts.Config;
using Contracts.Scripts.Base;

namespace Data.Service
{
    public interface ISettingsService
    {
        Task<Settings> ReadSettingsAsync();
        Task UpdateSettingsAsync(Settings settings);
        Task<List<ScriptAbs>> ReadScriptsAsync();
        Task UpdateScriptsAsync(List<ScriptAbs> scripts);
    }
}
