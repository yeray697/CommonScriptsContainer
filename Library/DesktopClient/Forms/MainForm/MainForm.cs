using DesktopClient.Forms.Base;
using DesktopClient.Service.Interfaces;
using DesktopClient.Utils;
using Contracts.Scripts.Base;
using Data;
using Data.Service.Interfaces;
using JobManager.Service;
using MaterialSkin.Controls;

namespace DesktopClient.Forms.MainForm
{
    public partial class MainForm : BaseForm
    {
        private readonly TrayContextMenu _trayContextMenu;
        private readonly IWindowsRegistryService _windowsRegistryService;
        public bool RunOnStartup { get; set; }

        public MainForm(IRunScriptService runScriptService, IWindowsRegistryService windowsRegistryService, IScriptsService scriptsService)
        {
            InitializeComponent();
            _windowsRegistryService = windowsRegistryService;

            var scripts = runTabControl.SetScriptsService(scriptsService);
            runTabControl.SetRunScriptService(runScriptService);
            runTabControl.ScriptEdited += RunTabControl_ScriptEdited;
            runTabControl.ScriptAdded += RunTabControl_ScriptAdded;
            runTabControl.ScriptRemoved += RunTabControl_ScriptRemoved;

            _trayContextMenu = new TrayContextMenu();
            ConfigureTrayContextMenu(scripts);
        }

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
        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await ShowRunAtStartupDialogIfNeededAsync();
            if (RunOnStartup)
            {
                runTabControl.RunScriptsOnStartupAsync();
            }
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
        private void ContextMenu_StatusClick(ScriptAbs script)
            => ChangeScriptStatus(script);
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
        private void ChangeScriptStatus(ScriptAbs script)
        {
            runTabControl.RefreshScriptStatusAsync(script.Id);
        }
        private async Task ShowRunAtStartupDialogIfNeededAsync()
        {
            if (SettingsManager.Settings.Core.DoNotAskAgainRunStartup || _windowsRegistryService.IsAppSetToRunAtStartup())
                return;
            var runAtStartupDialog = new MaterialDialog(this, null, "Do you want to set the app to run at startup?", "Yes", true, "No");
            if (runAtStartupDialog.ShowDialog(this) == DialogResult.OK)
                _windowsRegistryService.SetAppToRunAtStartup();
            else
            {
                await SettingsManager.UpdateSettingsAsync((settings) => settings.Core.DoNotAskAgainRunStartup = true);
            }
        }
        #endregion
    }
}
