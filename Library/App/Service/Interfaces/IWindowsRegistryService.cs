namespace App.Service.Interfaces
{
    public interface IWindowsRegistryService
    {
        bool IsAppSetToRunAtStartup();
        bool SetAppToRunAtStartup();
    }
}
