namespace CommonScripts.Model.Service.Interfaces
{
    public interface IWindowsRegistryService
    {
        bool IsAppSetToRunAtStartup();
        bool SetAppToRunAtStartup();
    }
}
