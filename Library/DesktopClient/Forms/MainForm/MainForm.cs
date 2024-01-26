using AutoUpdaterDotNET;
using Contracts.Scripts.Base;
using DesktopClient.Extension;
using DesktopClient.Forms.Base;
using DesktopClient.Models;
using DesktopClient.Service.Interfaces;
using DesktopClient.Utils;
using MaterialSkin.Controls;
using Serilog;

namespace DesktopClient.Forms.MainForm
{
    public partial class MainForm : BaseForm
    {
        private readonly TrayContextMenu _trayContextMenu;
        private readonly IWindowsRegistryService _windowsRegistryService;

        private static bool systemShutdown = false;
        public MainForm(IScriptManagerService scriptManagerService, IWindowsRegistryService windowsRegistryService)
        {
            InitializeComponent();
            this.OnFormClosingAsync(MainForm_ClosingAsync);
            _windowsRegistryService = windowsRegistryService;

            var scripts = runTabControl.InitTabController(scriptManagerService);
            runTabControl.ScriptEdited += RunTabControl_ScriptEdited;
            runTabControl.ScriptAdded += RunTabControl_ScriptAdded;
            runTabControl.ScriptRemoved += RunTabControl_ScriptRemoved;

            settingsTabControl.SetWindowsRegistryService(_windowsRegistryService);

            _trayContextMenu = new TrayContextMenu();
            ConfigureTrayContextMenu(scripts);

            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
            AutoUpdater.Start("https://gist.githubusercontent.com/yeray697/484fa8d7871d44d1f67cc68a2c7d082f/raw");
        }
        #region Public methods
        public void Setup(ClientArguments clientArguments)
        {
            if (clientArguments.StartAppHidden.Value)
            {
                WindowState = FormWindowState.Minimized;
                Hide();
                ShowInTaskbar = false;
            }
            runTabControl.NeedToRunStartupScripts(clientArguments.OnStartup.Value);
        }
        #endregion
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                Log.Debug("WM_SHOWME event triggered");
                ShowForm();
            }
            else if (m.Msg == NativeMethods.WM_QUERYENDSESSION)
            {
                Log.Debug("WM_QUERYENDSESSION");
                systemShutdown = true;
            }
        }

        #region Events
        private void RunTabControl_ScriptEdited(ScriptAbs script)
        {
            _trayContextMenu.EditScript(script);
        }
        private void RunTabControl_ScriptRemoved(ScriptAbs script)
        {
            _trayContextMenu.RemoveScript(script.Id);
        }
        private void RunTabControl_ScriptAdded(ScriptAbs script)
        {
            _trayContextMenu.AddScript(script);
        }
        private void SettingsTab_Open(object sender, EventArgs e)
        {
            settingsTabControl.LoadView();
        }
        private void SettingsTab_Leave(object sender, EventArgs e)
        {
            settingsTabControl.ShowUnsavedChangesDialogIfNeeded();
        }
        private void Tab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (settingsTabControl.PreventTabSettingsFromLeaving)
            {
                e.Cancel = true;
                settingsTabControl.PreventTabSettingsFromLeaving = false;
            }
        }
        private void AppTrayIcon_DoubleClick(object sender, MouseEventArgs e) => ShowForm();
        private void ContextMenu_Open_Click()
            => ShowForm();
        private void ContextMenu_Close_Click()
            => Application.Exit();
        private async void ContextMenu_StatusClick(ScriptAbs script)
        {
            await runTabControl.SwapScriptStatusAsync(script);
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                this.ShowInTaskbar = false;
            }
        }
        private async Task MainForm_ClosingAsync(object? sender, FormClosingAsyncEventArgs e)
        {
            if (systemShutdown)
            {
                systemShutdown = false;
                await runTabControl.RunShutdownScriptsAsync();
            }
        }
        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            Log.Debug("Checking if a new update is available");
            if (args.Error == null)
            {
                if (args.IsUpdateAvailable)
                {
                    Log.Debug("New version available ({@CurrentVersion}). Current version {@InstalledVersion}", args.CurrentVersion, args.InstalledVersion);
                    DialogResult dialogResult;
                    string title = "Update Available";
                    string description = $"There is new version {args.CurrentVersion} available. You are using version {args.InstalledVersion}.";
                    if (args.Mandatory.Value)
                    {
                        dialogResult =
                            new MaterialDialog(
                                    this.FindForm(),
                                    title,
                                    $"{description} This is required update. Press Ok to begin updating the application.", 
                                    "Ok"
                                ).ShowDialog(this);
                    }
                    else
                    {
                        dialogResult =
                            new MaterialDialog(
                                    this.FindForm(),
                                    title,
                                    $"{description} Do you want to update the application now?",
                                    "Yes",
                                    true,
                                    "No"
                                ).ShowDialog(this);
                    }

                    if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                    {
                        Log.Debug("Start downloading new version");
                        try
                        {
                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Log.Debug("New version downloaded. Restarting the application");
                                Application.Exit();
                            }
                        }
                        catch (Exception exception)
                        {
                            Log.Error(exception, "An error has occurred when downloading the new version.");
                            MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    Log.Debug("There is no update available");
                }
            }
            else
            {
                if (args.Error is System.Net.WebException)
                {
                    Log.Error(args.Error, "An error has occurred when checking if a new version is available.");
                }
                else
                {
                    Log.Error(args.Error, "An unknown error has occurred when checking if a new version is available.");
                    new MaterialDialog(
                                    this.FindForm(),
                                    args.Error.GetType().ToString(),
                                    args.Error.Message,
                                    "Ok"
                                ).ShowDialog(this);
                }
            }
        }
        #endregion

        #region Private Methods
        private void ShowForm()
        {
            Show();
            this.WindowState = FormWindowState.Normal;

            this.ShowInTaskbar = true;
            //Bring app to the foreground
            bool currentTop = TopMost;
            TopMost = true;
            TopMost = currentTop;
            ApplyFormStyle();
        }
        private void ConfigureTrayContextMenu(List<ScriptAbs> scripts)
        {
            _trayContextMenu.CloseClicked += ContextMenu_Close_Click;
            _trayContextMenu.OpenClicked += ContextMenu_Open_Click;
            _trayContextMenu.ScriptStatusClicked += ContextMenu_StatusClick;
            _trayContextMenu.LoadScriptList(scripts);
            this.appNotifyIcon.ContextMenuStrip = _trayContextMenu;
        }
        #endregion
    }
}
