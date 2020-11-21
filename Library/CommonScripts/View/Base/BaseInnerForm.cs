using CommonScripts.Extension;
using MetroSet_UI.Components;
using MetroSet_UI.Forms;
using System;

namespace CommonScripts.View.Base
{
    public partial class BaseInnerForm : BaseForm
    {
        public BaseInnerForm() : base()
        {
            InitializeComponent();
        }
        public BaseInnerForm(StyleManager styleManager) : base()
        {
            InitializeComponent();
            UpdateMetroStyles(styleManager);
        }

        private void UpdateMetroStyles(StyleManager styleManager)
        {
            this.StyleManager = styleManager.Clone(this);
        }
    }
}
