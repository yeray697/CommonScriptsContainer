using CommonScripts.Model.Pojo;
using CommonScripts.Settings;
using CommonScripts.Utils;
using CommonScripts.View.Base;
using MetroSet_UI.Components;
using Serilog.Events;
using System;
using System.Windows.Forms;

namespace CommonScripts.View
{
    public partial class Settings : BaseInnerForm
    {
        public AppSettings AppSettings { get; private set; }

        public Settings() : base()
        {
            InitializeComponent();
        }
        public Settings(StyleManager styleManager) : base()
        {
            InitializeComponent();
            UpdateMetroStyles(styleManager);
            AppSettings = (AppSettings) AppSettingsManager.GetSettings().Clone();
            DisplaySettings();
        }

        private void DisplaySettings()
        {
            swtIsDarkMode.Switched = AppSettings.IsDarkMode;

            cbxConsoleMinLevel.DataSource = Enum.GetValues(typeof(LogEventLevel));
            cbxConsoleMinLevel.SelectedItem = AppSettings.ConsoleMinimumLoggingLevel;

            cbxFileMinLevel.DataSource = Enum.GetValues(typeof(LogEventLevel));
            cbxFileMinLevel.SelectedItem = AppSettings.FileMinimumLoggingLevel;
        }

        private void Cancel(object sender, EventArgs e)
        {
            AppSettings = null;
            Close();
        }
        private void Save(object sender, EventArgs e)
        {
            AppSettings.FileMinimumLoggingLevel = EnumUtils.Parse<LogEventLevel>(cbxFileMinLevel.SelectedValue);
            AppSettings.ConsoleMinimumLoggingLevel = EnumUtils.Parse<LogEventLevel>(cbxConsoleMinLevel.SelectedValue);
            AppSettings.IsDarkMode = swtIsDarkMode.Switched;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
