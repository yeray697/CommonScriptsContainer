using App.Extension;
using Common;
using Contracts.Config;
using Data;
using Logging;
using MaterialSkin;
using MaterialSkin.Controls;
using SettingsModel = Contracts.Config.Settings;

namespace App.Forms.MainForm.Tabs.Settings
{
    public partial class SettingsTabControl : UserControl
    {
        private SettingsModel? _newSettings;
        public bool PreventTabSettingsFromLeaving { get; set; }

        public SettingsTabControl()
        {
            InitializeComponent();
        }
        #region Public Methods
        public void LoadView()
        {
            _newSettings = SettingsManager.CloneSettings;
            swtIsDarkMode.Checked = _newSettings.App.DarkMode;

            cbxConsoleMinLevel.DataSource = Enum.GetValues(typeof(LogLevel));
            cbxConsoleMinLevel.SelectedItem = _newSettings.App.LoggingLevel;

            cbxFileMinLevel.DataSource = Enum.GetValues(typeof(LogLevel));
            cbxFileMinLevel.SelectedItem = _newSettings.Core.LoggingLevel;
        }
        public void ShowUnsavedChangesDialogIfNeeded()
        {
            MapSettingsFromControls();

            if (_newSettings != null &&_newSettings.Equals(SettingsManager.Settings))
            {
                _newSettings = null;
                return;
            }
            MaterialDialog dialog = new(this.FindForm(), "Unsaved changes", "There are changes that were not saved. Do you want to leave?", "Yes", true, "No");
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                _newSettings = null;
            }
            else
            {
                PreventTabSettingsFromLeaving = true;
            }
        }
        #endregion
        #region Events
        private async void SaveSettingsButtonClicked(object sender, EventArgs e)
        {
            MapSettingsFromControls();
            if (_newSettings == null)
                return;
            await SettingsManager.UpdateSettingsAsync(_newSettings);
            MaterialSkinManager.Instance.ChangeTheme(_newSettings.App.DarkMode);
            LogManager.ChangeConsoleMinLoggingLevel(_newSettings.App.LoggingLevel);
            LogManager.ChangeFileMinLoggingLevel(_newSettings.Core.LoggingLevel);
        }
        #endregion
        #region Private Methods
        private void MapSettingsFromControls()
        {
            if (_newSettings == null)
                return;
            _newSettings.App.LoggingLevel = EnumUtils.Parse<LogLevel>(cbxConsoleMinLevel.SelectedValue);
            _newSettings.Core.LoggingLevel = EnumUtils.Parse<LogLevel>(cbxFileMinLevel.SelectedValue);
            _newSettings.App.DarkMode = swtIsDarkMode.Checked;
        }
        #endregion
    }
}
