using CommonScripts.CustomComponent.ScriptListBox;
using CommonScripts.Extension;
using CommonScripts.Logging;
using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Presenter;
using CommonScripts.Settings;
using CommonScripts.Utils;
using CommonScripts.View.Base;
using CommonScripts.View.Interfaces;
using MaterialSkin.Controls;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CommonScripts.View
{
    public partial class MainForm : BaseForm, IMainView
    {
        private ScriptListAdapter _scriptListAdapter;
        private TrayContextMenu _trayContextMenu;
        private bool _isDarkMode;
        private bool _preventTabSettingsFromLeaving;
        private AppSettings _appSettings_SettingsTab;
        public MainPresenter Presenter { get; set; }

        public MainForm()
        {
            InitializeComponent();
            InitScriptListAdapter();
            InitTrayContextMenu();
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
#if DEBUG
            return;
#endif
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowForm();
            }
        }

#region Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!Presenter.AppConfigExists())
            {
                SetInstallationPathForm installationPathForm = new SetInstallationPathForm();
                if (installationPathForm.ShowDialogCenter(this) == DialogResult.OK)
                {
                    Presenter.InitializeAppConfig(installationPathForm.InstallationPath);
                }
            }
            Presenter.LoadSettings();
            ReloadStyles(AppSettingsManager.IsDarkMode());
            Presenter.LoadScripts();
        }
        private void AddScript(object sender, EventArgs e)
        {
            ShowScriptForm(null, (ScriptAbs addedScript) => {
                if (Presenter.AddScript(addedScript))
                {
                    _scriptListAdapter.AddItem(addedScript);
                    _trayContextMenu.AddScript(addedScript);
                }
            });
        }
        private void EditScript(ScriptAbs script)
        {
            ShowScriptForm(script, (ScriptAbs editedScript) => {
                if (Presenter.EditScript(script, editedScript))
                {
                    _scriptListAdapter.EditItem(script, editedScript);
                    _trayContextMenu.EditScript(editedScript);
                }
            });
        }
        private void RemoveScript(ScriptAbs script)
        {
            MaterialDialog dialog = new MaterialDialog(this, "Remove", "Do you want to remove the script?", "Yes", true, "No");
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                string scriptId = script.Id;
                if (Presenter.RemoveScript(scriptId))
                {
                    _scriptListAdapter.RemoveItem(scriptId);
                    _trayContextMenu.RemoveScript(scriptId);
                }
            }
        }
        private void ChangeScriptStatus(ScriptAbs script)
        {
            bool hasStatusChanged = Presenter.ChangeScriptStatus(script).Result;
            if (hasStatusChanged)
            {
                _scriptListAdapter.RefreshScriptStatus(script.Id);
                _trayContextMenu.RefreshScriptStatus(script);
            }
        }
        private void AppTrayIcon_DoubleClick(object sender, MouseEventArgs e) => ShowForm();
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                this.ShowInTaskbar = false;
            }
        }
        internal void LogEmitted(LogMessage log)
        {
            Color color = GetConsoleTextColor(log.Lvl);
            rtbConsole.AppendTextThreadSafe(log.ToString(), color, true);
        }
        private void ContextMenu_Open_Click() => ShowForm();
        private void ContextMenu_Close_Click() => Application.Exit();
        private void ContextMenu_StatusClick(ScriptAbs script) => ChangeScriptStatus(script);
        private void SaveSettingsButtonClicked(object sender, EventArgs e)
        {
            MapSettingsFromControls();
            Presenter.SaveSettings(_appSettings_SettingsTab);
            ReloadStyles(_appSettings_SettingsTab.IsDarkMode);
        }
        private void OpenSettingsTab(object sender, EventArgs e)
        {
            _appSettings_SettingsTab = (AppSettings)AppSettingsManager.GetSettings().Clone();
            swtIsDarkMode.Checked = _appSettings_SettingsTab.IsDarkMode;

            cbxConsoleMinLevel.DataSource = Enum.GetValues(typeof(LogEventLevel));
            cbxConsoleMinLevel.SelectedItem = _appSettings_SettingsTab.ConsoleMinimumLoggingLevel;

            cbxFileMinLevel.DataSource = Enum.GetValues(typeof(LogEventLevel));
            cbxFileMinLevel.SelectedItem = _appSettings_SettingsTab.FileMinimumLoggingLevel;
        }
        private void LeaveSettingsTab(object sender, EventArgs e)
        {
            MapSettingsFromControls();

            if (_appSettings_SettingsTab.Equals(AppSettingsManager.GetSettings()))
            {
                _appSettings_SettingsTab = null;
                return;
            }
            MaterialDialog dialog = new MaterialDialog(this, "Unsaved changes", "There are changes that were not saved. Do you want to leave?", "Yes", true, "No");
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                _appSettings_SettingsTab = null;
            }
            else
            {
                _preventTabSettingsFromLeaving = true;
            }
        }
        private void TabSelectingEvent(object sender, TabControlCancelEventArgs e)
        {
            if (_preventTabSettingsFromLeaving)
            {
                e.Cancel = true;
                _preventTabSettingsFromLeaving = false;
            }
        }
        private void ShowContextMenuScript(ScriptAbs script)
        {
            cmsScriptList.Tag = script;
            cmsScriptList.Show(Cursor.Position);
        }
        private void ContextMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var control = (sender as Control);
            var script = control.Tag as ScriptAbs;
            control.Tag = null;

            if (e.ClickedItem.Text == "Edit")
            {
                EditScript(script);
            }
            else if (e.ClickedItem.Text == "Remove")
            {
                RemoveScript(script);
            }
        }
        #endregion

        #region Public Methods
        public void ShowScripts(IList<ScriptAbs> scripts)
        {
            TrayMenuContextScriptList(scripts);
            _scriptListAdapter.CreateWithList(scripts);
        }
        public void ShowRunAtStartupDialog()
        {
            MaterialDialog runAtStartupDialog = new MaterialDialog(this, null, "Do you want to set the app to run at startup?", "Yes", true, "No");
            if (runAtStartupDialog.ShowDialog(this) == DialogResult.OK)
                Presenter.SetAppRunAtStartup();
            else
                Presenter.DoNotAskAgainRunAtStartup();
        }
        public void ChangeScriptStatusThreadSafe(ScriptAbs script)
        {
            this.Invoke((MethodInvoker)delegate () { ChangeScriptStatus(script); });
        }
#endregion

#region Private Methods
        private void ShowScriptForm(ScriptAbs script, Action<ScriptAbs> postAction)
        {
            ScriptForm scriptForm = new ScriptForm(script);
            if (scriptForm.ShowDialogCenter(this) == DialogResult.OK)
            {
                postAction(scriptForm.GetScript());
            }
        }
        private void InitScriptListAdapter()
        {
            _scriptListAdapter = new ScriptListAdapter(pnlScripts);
            _scriptListAdapter.ShowMenu += ShowContextMenuScript;
            _scriptListAdapter.StatusClicked += ChangeScriptStatus;
        }
        private Color GetConsoleTextColor(LogEventLevel logLevel)
        {
            Color color;
            switch (logLevel)
            {
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    color = ColorUtils.CONSOLE_ERROR_COLOR;
                    break;
                case LogEventLevel.Warning:
                    color = ColorUtils.CONSOLE_WARNING_COLOR;
                    break;
                case LogEventLevel.Debug:
                case LogEventLevel.Verbose:
                default:
                    color = _isDarkMode ? ColorUtils.CONSOLE_DEFAULT_DARK_COLOR : ColorUtils.CONSOLE_DEFAULT_LIGHT_COLOR;
                    break;
            }
            return color;
        }
        private void ReloadStyles(bool isDarkMode)
        {
            if (_isDarkMode != isDarkMode)
            {
                _isDarkMode = isDarkMode;
                ReloadConsoleStyle();
            }
        }
        private void ReloadConsoleStyle()
        {
            //rtbConsole.ApplyTheme(_isDarkMode ? MetroSet_UI.Enums.Style.Dark : MetroSet_UI.Enums.Style.Light);
            ReloadConsoleTextLines();
        }
        private void ReloadConsoleTextLines()
        {
            int lineCount = 0;
            Color color = Color.White;
            bool changeLine = true;
            foreach (string line in rtbConsole.Lines)
            {
                if (line.Contains(LogMessage.ERROR_STRING) || line.Contains(LogMessage.FATAL_STRING))
                    color = ColorUtils.CONSOLE_ERROR_COLOR;
                else if (line.Contains(LogMessage.WARNING_STRING))
                    color = ColorUtils.CONSOLE_WARNING_COLOR;
                else
                    changeLine = false;

                if (changeLine)
                    rtbConsole.ColorLineThreadSafe(lineCount, line.Length, color);
                lineCount++;
                changeLine = true;
            }
        }
        private void TrayMenuContextScriptList(IList<ScriptAbs> scripts)
        {
            _trayContextMenu.LoadScriptList(scripts);
        }
        private void InitTrayContextMenu()
        {
            _trayContextMenu = new TrayContextMenu();
            _trayContextMenu.CloseClicked += ContextMenu_Close_Click;
            _trayContextMenu.OpenClicked += ContextMenu_Open_Click;
            _trayContextMenu.ScriptStatusClicked += ContextMenu_StatusClick;
            this.appNotifyIcon.ContextMenuStrip = _trayContextMenu;
        }
        private void ShowForm()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
           
            this.ShowInTaskbar = true;
            //Bring app to the foreground
            bool currentTop = TopMost;
            TopMost = true;
            TopMost = currentTop;
        }
        private void MapSettingsFromControls()
        {
            _appSettings_SettingsTab.FileMinimumLoggingLevel = EnumUtils.Parse<LogEventLevel>(cbxFileMinLevel.SelectedValue);
            _appSettings_SettingsTab.ConsoleMinimumLoggingLevel = EnumUtils.Parse<LogEventLevel>(cbxConsoleMinLevel.SelectedValue);
            _appSettings_SettingsTab.IsDarkMode = swtIsDarkMode.Checked;
        }
        #endregion
    }
}
