using App.Forms.Base;

namespace App.Forms
{
    public partial class SetInstallationPathForm : BaseInnerForm
    {
        public string? InstallationPath { get; private set; }
        public SetInstallationPathForm() : base()
        {
            InitializeComponent();
        }
        private void Save(object sender, EventArgs e)
        {
            if (!Directory.Exists(tbxInstallationPath.Text))
            {
                tbxInstallationPath.SetErrorState(true);
                return;
            }

            InstallationPath = tbxInstallationPath.Text;
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
