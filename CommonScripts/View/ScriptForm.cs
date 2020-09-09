using CommonScripts.Extension;
using CommonScripts.Model;
using MetroSet_UI;
using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonScripts.View
{
    public partial class ScriptForm : MetroSetForm
    {
        private Script _script;

        public Script GetScript() => _script;

        public ScriptForm(MetroSet_UI.StyleManager styleManager, Script script)
        {
            InitializeComponent();
            UpdateMetroStyles(styleManager);
            string formTitle;
            if (script == null)
            {
                _script = new Script();
                formTitle = "Add Script";
            }
            else
            {
                _script = script.Clone();
                formTitle = "Update Script";
            }
            this.Text = formTitle;

            tbxScriptName.Text = _script.ScriptName;
            tbxScriptPath.Text = _script.ScriptPath;
            cbxScriptType.DataSource = Enum.GetValues(typeof(Script.Type));
            cbxScriptType.SelectedItem = _script.ScriptType;
        }

        private void UpdateMetroStyles(StyleManager styleManager)
        {
            this.StyleManager = styleManager.Clone(this);
        }

        private void ShowPathSelector(object sender, EventArgs e)
        {
            if (ofdScriptPath.ShowDialog() == DialogResult.OK)
                tbxScriptPath.Text = ofdScriptPath.FileName;
        }

        private void Cancel(object sender, EventArgs e)
        {
            _script = null;
            Close();
        }

        private void Save(object sender, EventArgs e)
        {
            Script.Type scriptType;
            Enum.TryParse<Script.Type>(cbxScriptType.SelectedValue.ToString(), out scriptType);

            _script.ScriptName = tbxScriptName.Text;
            _script.ScriptPath = tbxScriptPath.Text;
            _script.ScriptType = scriptType;
            _script.ScriptStatus = Script.Status.Stopped;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
