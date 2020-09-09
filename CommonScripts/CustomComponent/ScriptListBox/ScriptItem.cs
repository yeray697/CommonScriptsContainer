using CommonScripts.Model;
using MetroSet_UI;
using System.Windows.Forms;

namespace CommonScripts.CustomComponent.ScriptListBox
{
    public partial class ScriptItem : UserControl
    {
        public delegate void ItemClickHandler(ScriptItem source);

        public event ItemClickHandler RemoveClicked;
        public event ItemClickHandler EditClicked;
        public event ItemClickHandler StatusClicked;

        private Script _script;
        private StyleManager _styleManager;

        public ScriptItem(Script script, StyleManager styleManager)
        {
            _styleManager = styleManager;
            _script = script;
            InitializeComponent();
            PaintUI();
        }
        public int GetScriptId() => _script.Id;

        public void ModifyScriptStatus(Script.Status status)
        {
            if (_script.ScriptStatus != status)
            {
                _script.ScriptStatus = status;
                PaintScriptStatus();
            }
        }
        public bool ModifyScriptName(string name)
        {
            bool hasChanged = false;
            if (_script.ScriptName != name)
            {
                _script.ScriptName = name;
                PaintScriptName();
                hasChanged = true;
            }
            return hasChanged;
        }

        private void PaintUI()
        {
            UpdateMetroStyles();
            if (_script != null)
            {
                PaintScriptName();
                PaintScriptStatus();
            }
        }

        private void UpdateMetroStyles()
        {
            lblScriptName.StyleManager = _styleManager;
            lblScriptName.Style = _styleManager.Style; //Little hack to make the style of a component created programmatically to apply
            //The style property call the private method 'ApplyTheme', which refresh the style https://github.com/N-a-r-w-i-n/MetroSet-UI/blob/4939610696619884f5596ef63965e3b1898c4ff0/MetroSet%20UI/Controls/MetroSetLabel.cs#L51

        }

        public void SetWidth(int width)
        {
            Width = width;
            this.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        }

        public Script GetScript()
        {
            return _script;
        }

        private void PaintScriptName()
        {
            lblScriptName.Text = _script.ScriptName;
        }

        private void PaintScriptStatus()
        {
            switch (_script.ScriptStatus)
            {
                case Script.Status.Running:
                case Script.Status.Resuming:
                    pbxStatus.Image = Properties.Resources.pause;
                    break;
                case Script.Status.Undefined:
                case Script.Status.Stopped:
                    pbxStatus.Image = Properties.Resources.play;
                    break;
                default:
                    break;
            }
            pbxStatus.Refresh();

        }

        private void pbxEdit_Click(object sender, System.EventArgs e)
        {
            EditClicked?.Invoke(this);
        }

        private void pbxRemove_Click(object sender, System.EventArgs e)
        {
            RemoveClicked?.Invoke(this);
        }

        private void pbxStatus_Click(object sender, System.EventArgs e)
        {
            StatusClicked?.Invoke(this);
        }
    }
}
