using MetroSet_UI.Forms;
using System.Windows.Forms;

namespace CommonScripts.View.Base
{
    public partial class BaseForm : MetroSetForm
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        //Helps with the refresh of the UI when resizing the window
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
