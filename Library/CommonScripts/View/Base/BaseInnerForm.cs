using CommonScripts.Extension;
using MetroSet_UI.Components;

namespace CommonScripts.View.Base
{
    public partial class BaseInnerForm : BaseForm
    {
        public BaseInnerForm() : base()
        {
            InitializeComponent();
        }
        public virtual void UpdateMetroStyles(StyleManager styleManager)
        {
            this.StyleManager = styleManager.Clone(this);
        }
    }
}
