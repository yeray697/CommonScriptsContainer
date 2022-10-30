using Common;
using Contracts.Config;
using Data;
using MaterialSkin;
using MaterialSkin.Controls;
using Serilog.Events;
using SettingsModel = Contracts.Config.Settings;

namespace App.Forms.MainForm.Tabs.Settings
{
    public partial class SettingsTabControl : UserControl
    {
        private SettingsModel? _newSettings;
        public bool PreventTabSettingsFromLeaving { get; set; }

        private SettingsModel? _currentSettings;

        public SettingsTabControl()
        {
            InitializeComponent();
        }
        #region Public Methods
        public void LoadView()
        {
            _currentSettings = SettingsManager.CloneSettings;
            _newSettings = SettingsManager.CloneSettings;
            swtIsDarkMode.Checked = _newSettings.App.DarkMode;

            cbxConsoleMinLevel.DataSource = Enum.GetValues(typeof(LogEventLevel));
            cbxConsoleMinLevel.SelectedItem = _newSettings.App.LoggingLevel;

            cbxFileMinLevel.DataSource = Enum.GetValues(typeof(LogEventLevel));
            cbxFileMinLevel.SelectedItem = _newSettings.Core.LoggingLevel;
        }
        public void ShowUnsavedChangesDialogIfNeeded()
        {
            MapSettingsFromControls();

            if (_newSettings != null &&_newSettings.Equals(_currentSettings))
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

            Color primaryAcolor = ColorTranslator.FromHtml(tbxPrimaryColor.Text);
            Color darkPrimaryColor = ColorTranslator.FromHtml(tbxDarkPrimaryColor.Text);
            Color lightPrimaryColor = ColorTranslator.FromHtml(tbxLightPrimaryColor.Text);
            Color accentColor = ColorTranslator.FromHtml(tbxAccentColor.Text);
            TextShade textShadeColor = TextShade.WHITE;
            MaterialSkinManager.Instance.ColorScheme = new ColorScheme(primaryAcolor, darkPrimaryColor, lightPrimaryColor, accentColor, textShadeColor);
            MapSettingsFromControls();

            //TODO
            //if (settings.FileMinimumLoggingLevel != AppSettingsManager.GetFileMinLogLevel())
            //    LogManager.ChangeMinLoggingLevel(settings.FileMinimumLoggingLevel);
            if (_newSettings != null)
                await SettingsManager.UpdateSettingsAsync(_newSettings);
        }
        #endregion
        #region Private Methods
        private void MapSettingsFromControls()
        {
            if (_newSettings == null)
                return;
            _newSettings.App.LoggingLevel = EnumUtils.Parse<LogLevel>(cbxFileMinLevel.SelectedValue);
            _newSettings.Core.LoggingLevel = EnumUtils.Parse<LogLevel>(cbxConsoleMinLevel.SelectedValue);
            _newSettings.App.DarkMode = swtIsDarkMode.Checked;
        }
        #endregion
    }
}
