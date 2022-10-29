using CommonScripts.Extension;
using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using MaterialSkin;
using System.Drawing;
using System.Windows.Forms;

namespace CommonScripts.CustomComponent.ScriptListBox
{
    public partial class ScriptItem : UserControl
    {
        public delegate void ItemClickHandler(ScriptItem source);

        public event ItemClickHandler MenuClicked;
        public event ItemClickHandler StatusClicked;


        public ScriptAbs Script { get; private set; }

        public ScriptItem(ScriptAbs script)
        {
            Script = script;
            InitializeComponent();
            this.BackColor = MaterialSkinManager.Instance.BackdropColor;
            MaterialSkinManager.Instance.ThemeChanged += ThemeChanged;
            UpdateMenuButtonColor();
            PaintUI();
        }

        #region Events
        private void MenuButtonClicked(object sender, System.EventArgs e)
        {
            MenuClicked?.Invoke(this);
        }
        private void StatusButtonClicked(object sender, System.EventArgs e)
        {
            StatusClicked?.Invoke(this);
        }
        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MenuClicked?.Invoke(this);
            }
        }
        private void ThemeChanged(object sender)
        {
            UpdateMenuButtonColor();
        }
        #endregion

        #region Private Methods
        private void ScriptTypeChanged(ScriptAbs newItem)
        {
            Script = newItem;
            PaintScriptType();
        }
        private bool ModifyScriptName(string name)
        {
            bool hasChanged = false;
            if (Script.ScriptName != name)
            {
                Script.ScriptName = name;
                PaintScriptName();
                hasChanged = true;
            }
            return hasChanged;
        }
        private void PaintUI()
        {
            if (Script != null)
            {
                PaintScriptName();
                PaintScriptStatus();
                PaintScriptType();
            }
        }
        private void PaintScriptName()
        {
            lblScriptName.Text = Script.ScriptName;
        }
        private void PaintScriptType()
        {
            lblScriptType.Text = Script.ScriptType.ToString();
        }
        private void UpdateMenuButtonColor()
        {
            var color = MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.DARK ? Color.White : Color.Black;
            pbxMenu.Image = pbxMenu.Image.RecolorImage(color);
        }
        #endregion

        #region Public Methods
        public void SetWidth(int width)
        {
            Width = width;
            this.Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right);
        }
        public bool ModifyScript(ScriptAbs editScript, bool hasScriptTypeChanged)
        {
            bool hasNameBeenModified = ModifyScriptName(editScript.ScriptName);
            if (hasScriptTypeChanged)
            {
                ScriptTypeChanged(editScript);
                PaintScriptStatus();
            }
            Script = editScript;
            return hasNameBeenModified;
        }
        public void PaintScriptStatus()
        {
            switch (Script.ScriptStatus)
            {
                case ScriptStatus.Running:
                    pbxStatus.Image = Properties.Resources.pause;
                    break;
                case ScriptStatus.Undefined:
                case ScriptStatus.Stopped:
                    pbxStatus.Image = Properties.Resources.play;
                    break;
                default:
                    break;
            }
            pbxStatus.Refresh();
        }
        #endregion
    }
}
