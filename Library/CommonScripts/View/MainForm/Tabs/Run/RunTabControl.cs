using CommonScripts.CustomComponent.ScriptListBox;
using CommonScripts.Model.Pojo.Base;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static CommonScripts.CustomComponent.ScriptListBox.ScriptListAdapter;

namespace CommonScripts.View.MainForm.Tabs.Run
{
    public partial class RunTabControl : UserControl
    {
        public event ScriptClickHandler StatusClicked;
        public event ScriptClickHandler ScriptAdded;
        public event ScriptClickHandler ScriptDeleted;
        public event ScriptEditHandler ScriptEdited;

        public delegate void ScriptEditHandler(ScriptAbs source, ScriptAbs editedScript);

        private readonly ScriptListAdapter _scriptListAdapter;
        public RunTabControl()
        {
            InitializeComponent();

            _scriptListAdapter = new ScriptListAdapter(pnlScripts);
            _scriptListAdapter.ShowMenu += ShowContextMenuScript;
            _scriptListAdapter.StatusClicked += ChangeScriptStatus;
        }
        public void AddItem(ScriptAbs script)
            => _scriptListAdapter.AddItem(script);
        public void EditScript(ScriptAbs oldScript, ScriptAbs editedScript)
            => _scriptListAdapter.EditItem(oldScript, editedScript);
        public void RemoveScript(string scriptId)
            => _scriptListAdapter.RemoveItem(scriptId);
        public void RefreshScriptStatus(string scriptId)
            => _scriptListAdapter.RefreshScriptStatus(scriptId);
        public void LoadScriptList(IList<ScriptAbs> scripts)
            => _scriptListAdapter.CreateWithList(scripts);
        public void EditScriptForm(ScriptAbs script)
        {
            ShowScriptForm(script, (ScriptAbs editedScript) => {
                ScriptEdited?.Invoke(script, editedScript);
            });
        }
        private void AddScriptButtonClicked(object sender, EventArgs e)
        {
            ShowScriptForm(null, (ScriptAbs addedScript) => {
                ScriptAdded?.Invoke(addedScript);
            });
        }
        private void ShowScriptForm(ScriptAbs script, Action<ScriptAbs> postAction)
        {
            ScriptForm scriptForm = new ScriptForm(script);
            if (scriptForm.ShowDialogCenter(this) == DialogResult.OK)
            {
                postAction(scriptForm.GetScript());
            }
        }
        private void ShowContextMenuScript(ScriptAbs script)
        {
            cmsScriptList.Tag = script;
            cmsScriptList.Show(Cursor.Position);
        }
        private void ChangeScriptStatus(ScriptAbs script)
        {
            StatusClicked?.Invoke(script);
        }
        private void ContextMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var control = (sender as Control);
            var script = control.Tag as ScriptAbs;
            control.Tag = null;

            if (e.ClickedItem.Text == "Edit")
            {
                EditScriptForm(script);
            }
            else if (e.ClickedItem.Text == "Remove")
            {
                RemoveScript(script);
            }
        }
        private void RemoveScript(ScriptAbs script)
        {
            MaterialDialog dialog = new MaterialDialog(this.ParentForm, "Remove", "Do you want to remove the script?", "Yes", true, "No");
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ScriptDeleted?.Invoke(script);
            }
        }
    }
}
