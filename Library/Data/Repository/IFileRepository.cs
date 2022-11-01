namespace Data.Repository
{
    public interface IFileRepository
    {
        bool FileExists(string path);
        Task<T> GetFileAsync<T>(string path);
        Task UpdateFileAsync(object file, string path);
    }
}
