using CommonScripts.Logging;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Presenter;
using CommonScripts.Utils;
using CommonScripts.View.Base;
using CommonScripts.View.Interfaces;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CommonScripts.View.MainForm
{
    public partial class MainForm : BaseForm, IMainView
    {
        private readonly TrayContextMenu _trayContextMenu;
        public MainPresenter Presenter { get; set; }

        public MainForm()
        {
            InitializeComponent();
            _trayContextMenu = new TrayContextMenu();
            ConfigureTrayContextMenu();
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
            Presenter.LoadScripts();
        }
        private void AddScript(ScriptAbs addedScript)
    {
            if (Presenter.AddScript(addedScript))
            {
                runTabControl.AddItem(addedScript);
                _trayContextMenu.AddScript(addedScript);
            }
        }
        private void EditScript(ScriptAbs script, ScriptAbs editedScript)
    {
            if (Presenter.EditScript(script, editedScript))
            {
                runTabControl.EditScript(script, editedScript);
                _trayContextMenu.EditScript(editedScript);
            }
        }
        private void RemoveScript(ScriptAbs script)
        {
            if (Presenter.RemoveScript(script.Id))
            {
                runTabControl.RemoveScript(script.Id);
                _trayContextMenu.RemoveScript(script.Id);
            }
        }
        private void ChangeScriptStatus(ScriptAbs script)
        {
            if (Presenter.ChangeScriptStatus(script).Result)
            {
                runTabControl.RefreshScriptStatus(script.Id);
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
            consoleTabControl.PrintLog(log);
        }
        private void ContextMenu_Open_Click() => ShowForm();
        private void ContextMenu_Close_Click() => Application.Exit();
        private void ContextMenu_StatusClick(ScriptAbs script) => ChangeScriptStatus(script);
        private void SaveSettingsButtonClicked(object sender, EventArgs e)
        {
            Presenter.SaveSettings(settingsTabControl.AppSettings);
        }
        private void OpenSettingsTab(object sender, EventArgs e)
        {
            settingsTabControl.LoadView();
        }
        private void LeaveSettingsTab(object sender, EventArgs e)
        {
            settingsTabControl.ShowUnsavedChangesDialogIfNeeded();
        }
        private void TabSelectingEvent(object sender, TabControlCancelEventArgs e)
        {
            if (settingsTabControl.PreventTabSettingsFromLeaving)
            {
                e.Cancel = true;
                settingsTabControl.PreventTabSettingsFromLeaving = false;
            }
        }
        #endregion

        #region Public Methods
        public void ShowScripts(IList<ScriptAbs> scripts)
        {
            TrayMenuContextScriptList(scripts);
            runTabControl.LoadScriptList(scripts);
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
        private void TrayMenuContextScriptList(IList<ScriptAbs> scripts)
        {
            _trayContextMenu.LoadScriptList(scripts);
        }
        private void ConfigureTrayContextMenu()
        {
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
        #endregion
    }
}
