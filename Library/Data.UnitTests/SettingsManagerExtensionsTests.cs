using Data.Extensions;
using Data.Repository;
using Data.Repository.Interfaces;
using Data.Services;
using Data.Services.Interfaces;
using LiteDB;
using Microsoft.Extensions.DependencyInjection;

namespace DataTests
{
    public class SettingsManagerExtensionsTests
    {
        [Fact]
        public void AddSettingServices_HappyPath()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSettingServices();

            ServiceProvider provider = services.BuildServiceProvider();
            var settingsRepository = provider.GetRequiredService<ISettingsRepository>();
            var scriptsRepository = provider.GetRequiredService<IScriptsRepository>();
            var liteDb = provider.GetRequiredService<ILiteDatabase>();
            var databaseService = provider.GetRequiredService<IDatabaseService>();
            Assert.Equal(4, services.Count);
            Assert.IsType<SettingsRepository>(settingsRepository);
            Assert.IsType<ScriptsRepository>(scriptsRepository);
            Assert.IsType<LiteDatabase>(liteDb);
            Assert.IsType<DatabaseService>(databaseService);
        }
    }
}