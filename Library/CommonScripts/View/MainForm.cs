﻿using CommonScripts.CustomComponent.ScriptListBox;
using CommonScripts.Extension;
using CommonScripts.Logging;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Presenter;
using CommonScripts.Settings;
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
        private bool _isDarkMode;
        public MainPresenter Presenter { get; set; }

        public MainForm()
        {
            InitializeComponent();
            InitScriptListAdapter();
            SetSettingsImage();
        }

        #region Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Presenter.LoadScripts();
            Presenter.LoadSettings();
            ReloadStyles(AppSettingsManager.IsDarkMode());
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
                _scriptListAdapter.ChangeScriptStatus(script.Id);
        }
        private void appNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                this.ShowInTaskbar = false;
            }
        }
        public void LogEmitted(LogMsg log)
        {
            Color color = GetConsoleTextColor(log.Lvl);
            rtbConsole.AppendTextThreadSafe(log.ToString(), color, true);
        }
        private void pbxSettings_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(styleManager);
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                ReloadStyles(settingsForm.AppSettings.IsDarkMode);
                Presenter.SaveSettings(settingsForm.AppSettings);
            }
        }
        private void ReloadStyles(bool isDarkMode)
        {
            if (_isDarkMode != isDarkMode)
            {
                _isDarkMode = isDarkMode;
                styleManager.Style = isDarkMode ? MetroSet_UI.Enums.Style.Dark : MetroSet_UI.Enums.Style.Light;
                _scriptListAdapter.RefreshMetroStyles();
            }
        }

        private void pbxSettings_MouseEnter(object sender, EventArgs e)
        {
            SetSettingsImage(true);
        }

        private void pbxSettings_MouseLeave(object sender, EventArgs e)
        {
            SetSettingsImage();
        }
        #endregion

        #region Public Methods
        public void ShowScripts(IList<ScriptAbs> scripts)
        {
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
            //ToDo: Implementing dark mode
            Color color;
            switch (logLevel)
            {
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    color = Color.DarkRed;
                    break;
                case LogEventLevel.Warning:
                    color = Color.Orange;
                    break;
                case LogEventLevel.Debug:
                case LogEventLevel.Verbose:
                default:
                    color = Color.Black;
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
        #endregion
    }
}
