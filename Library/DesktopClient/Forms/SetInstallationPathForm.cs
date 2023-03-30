using Data;
using DesktopClient.Forms.Base;

namespace DesktopClient.Forms
{
    public partial class SetInstallationPathForm : BaseInnerForm
    {
        private string? InstallationPath { get; set; }
        public SetInstallationPathForm() : base()
        {
            InitializeComponent();
        }
        private async void SaveAsync(object sender, EventArgs e)
        {
            if (!Directory.Exists(tbxInstallationPath.Text))
            {
                tbxInstallationPath.SetErrorState(true);
                return;
            }

            InstallationPath = tbxInstallationPath.Text;
            await SettingsManager.UpdateSettingsAsync((settings) => settings.Core.InstallationPath = InstallationPath);
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ShowPathSelector(object sender, EventArgs e)
        {
            if (fbdInstallationPath.ShowDialog() == DialogResult.OK)
                tbxInstallationPath.Text = fbdInstallationPath.SelectedPath;
        }

        private void InstallationPath_TextChanged(object sender, EventArgs e)
            => tbxInstallationPath.SetErrorState(false);
    }
}
