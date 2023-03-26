using DesktopClient.Service;

namespace DesktopClient.Models
{
    public class ClientArguments
    {
        public Argument<bool> StartAppHidden { get; private set; } = new(WindowsRegistryService.APP_HIDE_ARG);
        public Argument<bool> OnStartup { get; private set; } = new(WindowsRegistryService.APP_ON_STARTUP_ARG);

        public ClientArguments(string[] args)
        {
            if (args != null)
            {
                foreach (var arg in args)
                {
                    if (arg == StartAppHidden.ArgumentName)
                        StartAppHidden.Value = true;
                    else if (arg == OnStartup.ArgumentName)
                        OnStartup.Value = true;

                }
            }
        }
    }
}
