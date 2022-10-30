using MaterialSkin;
using MaterialSkin.Controls;

namespace App.Forms.Base
{
    public partial class BaseForm : MaterialForm
    {
        private const int WS_EX_COMPOSITED = 0x02000000;
        private const int WS_MINIMIZEBOX = 0x20000;
        private const int CS_DBLCLKS = 0x8;

        public BaseForm()
        {
            InitializeComponent();
            Utils.DropShadow.ApplyShadows(this);
            MaterialSkinManager.Instance.AddFormToManage(this);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                //Helps with the refresh of the UI when resizing the window
                cp.ExStyle |= WS_EX_COMPOSITED;
                //Allow to minimize from taskbar, as FormBorderStyle.None (because of MetroSetForm) removes that behaviour
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }

        public DialogResult ShowDialogCenter(IWin32Window form)
        {
            StartPosition = FormStartPosition.CenterParent;
            return this.ShowDialog(form);
        }
    }
}
