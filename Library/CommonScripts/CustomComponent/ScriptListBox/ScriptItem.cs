using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using MetroSet_UI.Components;
using System.Windows.Forms;

namespace CommonScripts.CustomComponent.ScriptListBox
{
    public partial class ScriptItem : UserControl
    {
        public delegate void ItemClickHandler(ScriptItem source);

        public event ItemClickHandler RemoveClicked;
        public event ItemClickHandler EditClicked;
        public event ItemClickHandler StatusClicked;

        private readonly StyleManager _styleManager;

        public ScriptAbs Script { get; private set; }

        public ScriptItem(ScriptAbs script, StyleManager styleManager)
        {
            _styleManager = styleManager;
            Script = script;
            InitializeComponent();
            PaintUI();
        }

        #region Events
        private void EditButtonClicked(object sender, System.EventArgs e)
        {
            EditClicked?.Invoke(this);
        }
        private void RemoveButtonClicked(object sender, System.EventArgs e)
        {
            RemoveClicked?.Invoke(this);
        }
        private void StatusButtonClicked(object sender, System.EventArgs e)
        {
            StatusClicked?.Invoke(this);
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
            RefreshMetroStyles();
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
        public void RefreshMetroStyles()
        {
            lblScriptName.StyleManager = _styleManager;
            lblScriptType.StyleManager = _styleManager;

            //Little hack to make the style of a component created programmatically to be applied
            //The Style property call the private method 'ApplyTheme', which refreshes the style https://github.com/N-a-r-w-i-n/MetroSet-UI/blob/4939610696619884f5596ef63965e3b1898c4ff0/MetroSet%20UI/Controls/
            lblScriptName.Style = _styleManager.Style;
            lblScriptType.Style = _styleManager.Style;

        }
        #endregion
    }
}
