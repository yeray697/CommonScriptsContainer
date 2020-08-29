using CommonScripts.Model;

namespace CommonScripts.CustomComponent.ScriptListBox
{
    public partial class ScriptItem
    {
        private Script _script;
        private bool _hasParentLoaded;

        public ScriptItem()
        {
            this._script = null;
            InitializeComponent();
            PaintUI();
        }

        public ScriptItem(Script script)
        {
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

            if (_script != null)
            {
                PaintScriptName();
                PaintScriptStatus();
            }
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
                pbxScriptStatus.Image = (_script.ScriptStatus == Script.Status.Stopped) ? Properties.Resources.play : Properties.Resources.pause;
                pbxScriptStatus.Refresh();
                pbxScriptStatus.Visible = true;
            }
            else
            {
                pbxScriptStatus.Visible = false;
            }
        }
    }
}
