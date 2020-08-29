using MetroFramework.Controls;
using CommonScripts.Model;
using MetroFramework.Components;

namespace CommonScripts.CustomComponent.ScriptListBox
{
    public partial class ScriptItem : MetroUserControl
    {
        public delegate void ItemClickHandler(ScriptItem source);

        public event ItemClickHandler RemoveClicked;
        public event ItemClickHandler EditClicked;
        public event ItemClickHandler StatusClicked;

        private Script _script;
        private bool _hasParentLoaded;
        private MetroStyleManager _styleManager;

        public ScriptItem()
        {
            InitializeComponent();
            PaintUI();
        }

        public ScriptItem(Script script, MetroStyleManager styleManager)
        {
            _styleManager = styleManager;
            this._script = script;
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
        public void ModifyScriptName(string name)
        {
            if (_script.ScriptName != name)
            {
                _script.ScriptName = name;
                PaintScriptName();
            }
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
            this.Style = _styleManager.Style;
            this.Theme = _styleManager.Theme;
            this.StyleManager = _styleManager;

            lblScriptName.Style = _styleManager.Style;
            lblScriptName.Theme = _styleManager.Theme;
        }

        private void MainForm_ParentChanged(object sender, System.EventArgs e)
        {
            // Parent is null when a ScriptItem is created, as it has not been added to the panel yet,
            // so managing here the width avoids the need to create a public method to be called from the view
            // and it is easier to reuse this element
            // (Not reusing it right now, and in case it is needed to reuse it, probably, it would be better to create and abstract class 
            if (!_hasParentLoaded && Parent != null)
            {
                Width = Parent.Width;
                this.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
                _hasParentLoaded = true;
            }
        }

        private void PaintScriptName()
        {
            lblScriptName.Text = _script.ScriptName;
        }

        private void PaintScriptStatus()
        {
            if (_script.ScriptType == Script.Type.Daemon || _script.ScriptType == Script.Type.Scheduled)
            {
                pbxStatus.Image = (_script.ScriptStatus == Script.Status.Stopped) ? Properties.Resources.play : Properties.Resources.pause;
                pbxStatus.Refresh();
                pbxStatus.Visible = true;
            }
            else
            {
                pbxStatus.Visible = false;
            }
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
