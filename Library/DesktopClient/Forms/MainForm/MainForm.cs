using Contracts.Scripts.Base;
using DesktopClient.Forms.Base;
using DesktopClient.Models;
using DesktopClient.Service.Interfaces;
using DesktopClient.Utils;

namespace DesktopClient.Forms.MainForm
{
    public partial class MainForm : BaseForm
    {
        private readonly TrayContextMenu _trayContextMenu;
        private readonly IWindowsRegistryService _windowsRegistryService;
        private bool RunOnStartup { get; set; }

        public MainForm(IScriptManagerService scriptManagerService, IWindowsRegistryService windowsRegistryService)
        {
            InitializeComponent();
            _windowsRegistryService = windowsRegistryService;

            var scripts = runTabControl.InitTabController(scriptManagerService, RunOnStartup);
            runTabControl.ScriptEdited += RunTabControl_ScriptEdited;
            runTabControl.ScriptAdded += RunTabControl_ScriptAdded;
            runTabControl.ScriptRemoved += RunTabControl_ScriptRemoved;

            settingsTabControl.SetWindowsRegistryService(_windowsRegistryService);

            _trayContextMenu = new TrayContextMenu();
            ConfigureTrayContextMenu(scripts);
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
            RunOnStartup = clientArguments.OnStartup.Value;
        }
        #endregion

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowForm();
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
