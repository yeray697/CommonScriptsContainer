using CommonScripts.CustomComponent.ScriptListBox;
using CommonScripts.Model.Pojo;
using CommonScripts.Settings;
using CommonScripts.Utils;
using MaterialSkin.Controls;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonScripts.View.MainForm.Tabs.Settings
{
    public partial class SettingsTabControl : UserControl
    {
        public event EventHandler SaveClicked;
        public AppSettings AppSettings { get; private set; }
        public bool PreventTabSettingsFromLeaving { get; set; }


        public SettingsTabControl()
        {
            InitializeComponent();
        }
        #region Public Methods
        public void LoadView()
        {
            AppSettings = (AppSettings)AppSettingsManager.GetSettings().Clone();
            swtIsDarkMode.Checked = AppSettings.IsDarkMode;

            cbxConsoleMinLevel.DataSource = Enum.GetValues(typeof(LogEventLevel));
            cbxConsoleMinLevel.SelectedItem = AppSettings.ConsoleMinimumLoggingLevel;

            cbxFileMinLevel.DataSource = Enum.GetValues(typeof(LogEventLevel));
            cbxFileMinLevel.SelectedItem = AppSettings.FileMinimumLoggingLevel;
        }
        public void ShowUnsavedChangesDialogIfNeeded()
        {
            MapSettingsFromControls();

            if (AppSettings.Equals(AppSettingsManager.GetSettings()))
            {
                AppSettings = null;
                return;
            }
            MaterialDialog dialog = new MaterialDialog(this.FindForm(), "Unsaved changes", "There are changes that were not saved. Do you want to leave?", "Yes", true, "No");
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                AppSettings = null;
            }
            else
            {
                PreventTabSettingsFromLeaving = true;
            }
        }
        #endregion
        #region Events
        private void SaveSettingsButtonClicked(object sender, EventArgs e)
        {
            MapSettingsFromControls();
            SaveClicked?.Invoke(sender, e);
        }
        #endregion
        #region Private Methods
        private void MapSettingsFromControls()
        {
            AppSettings.FileMinimumLoggingLevel = EnumUtils.Parse<LogEventLevel>(cbxFileMinLevel.SelectedValue);
            AppSettings.ConsoleMinimumLoggingLevel = EnumUtils.Parse<LogEventLevel>(cbxConsoleMinLevel.SelectedValue);
            AppSettings.IsDarkMode = swtIsDarkMode.Checked;
        }
        #endregion
    }
}
