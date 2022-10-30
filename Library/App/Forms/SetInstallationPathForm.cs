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
            InstallationPath = tbxInstallationPath.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void Cancel(object sender, EventArgs e)
        {
            InstallationPath = null;
            Close();
        }
        private void ShowPathSelector(object sender, EventArgs e)
        {
            if (fbdInstallationPath.ShowDialog() == DialogResult.OK)
                tbxInstallationPath.Text = fbdInstallationPath.SelectedPath;
        }
    }
}
