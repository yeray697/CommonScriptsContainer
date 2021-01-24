using CommonScripts.CustomComponent.ScriptListBox;
using CommonScripts.Extension;
using CommonScripts.Logging;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Presenter;
using CommonScripts.Settings;
using CommonScripts.Utils;
using CommonScripts.View.Base;
using CommonScripts.View.Interfaces;
using MetroSet_UI.Forms;
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
        public MainPresenter Presenter { get; set; }

        public MainForm()
        {
            InitializeComponent();
            InitScriptListAdapter();
            SetSettingsImage();
            InitTrayContextMenu();
        }

        #region Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!Presenter.AppConfigExists())
            {
                SetInstallationPathForm installationPathForm = new SetInstallationPathForm(styleManager);
                if (installationPathForm.ShowDialog() == DialogResult.OK)
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
                }
            });
        }
        private void EditScript(ScriptAbs script)
        {
            ShowScriptForm(script, (ScriptAbs editedScript) => {
                bool hasScriptTypeChanged = script != null && ScriptAbs.HasScriptTypeChanged(script.ScriptType, editedScript.ScriptType);
                if (Presenter.EditScript(editedScript, hasScriptTypeChanged))
                {
                    _scriptListAdapter.EditItem(editedScript, hasScriptTypeChanged);
                }
            });
        }
        private void RemoveScript(ScriptAbs script)
        {
            DialogResult r = MetroSetMessageBox.Show(this, "Do you want to remove the script?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                string scriptId = script.Id;
                if (Presenter.RemoveScript(scriptId))
                {
                    _scriptListAdapter.RemoveItem(scriptId);
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
        private void SettingsClicked(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(styleManager);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                ReloadStyles(settingsForm.AppSettings.IsDarkMode);
                Presenter.SaveSettings(settingsForm.AppSettings);
            }
        }
        private void Settings_MouseEnter(object sender, EventArgs e) => SetSettingsImage(true);
        private void Settings_MouseLeave(object sender, EventArgs e) => SetSettingsImage();
        private void ContextMenu_Open_Click() => ShowForm();
        private void ContextMenu_Close_Click() => Application.Exit();
        private void ContextMenu_StatusClick(ScriptAbs script) => ChangeScriptStatus(script);
        #endregion

        #region Public Methods
        public void ShowScripts(IList<ScriptAbs> scripts)
        {
            TrayMenuContextScriptList(scripts);
            _scriptListAdapter.CreateWithList(scripts);
        }
        public void ShowRunAtStartupDialog()
        {
            DialogResult r = MetroSetMessageBox.Show(this, null, "Do you want to set the app to run at startup?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
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
            ScriptForm scriptForm = new ScriptForm(styleManager, script);
            if (scriptForm.ShowDialog() == DialogResult.OK)
            {
                postAction(scriptForm.GetScript());
            }
        }
        private void InitScriptListAdapter()
        {
            _scriptListAdapter = new ScriptListAdapter(StyleManager, pnlScripts);
            _scriptListAdapter.EditClicked += EditScript;
            _scriptListAdapter.RemoveClicked += RemoveScript;
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
        private void SetSettingsImage(bool hover = false)
        {
            if (hover)
                pbxSettings.Image = Properties.Resources.settings_hover;
            else
                pbxSettings.Image = Properties.Resources.settings;
        }
        private void ReloadStyles(bool isDarkMode)
        {
            if (_isDarkMode != isDarkMode)
            {
                _isDarkMode = isDarkMode;
                styleManager.Style = isDarkMode ? MetroSet_UI.Enums.Style.Dark : MetroSet_UI.Enums.Style.Light;
                _scriptListAdapter.RefreshMetroStyles();
                ReloadConsoleStyle();
            }
        }
        private void ReloadConsoleStyle()
        {
            rtbConsole.ApplyTheme(_isDarkMode ? MetroSet_UI.Enums.Style.Dark : MetroSet_UI.Enums.Style.Light);
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
        }
        #endregion
    }
}
