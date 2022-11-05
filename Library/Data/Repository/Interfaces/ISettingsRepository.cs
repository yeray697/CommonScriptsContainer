namespace Data.Repository.Interfaces
{
    public interface ISettingsRepository
    {
        bool FileExists(string path);
        Task<T> GetFileAsync<T>(string path);
        Task UpdateFileAsync(object file, string path);
    }
}
