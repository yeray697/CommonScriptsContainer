using CommonScripts.CustomComponent.ScriptListBox;
using CommonScripts.Model;
using CommonScripts.Presenter;
using CommonScripts.View.Interfaces;
using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CommonScripts.View
{
    public partial class MainForm : MetroSetForm, IMainView
    {
        public MainPresenter Presenter { get; set; }
        private ScriptListAdapter scriptListManager;

        public MainForm()
        {
            InitializeComponent();
            scriptListManager = new ScriptListAdapter(StyleManager, pnlScripts);
            scriptListManager.EditClicked += EditScript;
            scriptListManager.RemoveClicked += RemoveScript;
            scriptListManager.StatusClicked += ChangeScriptStatus;
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

        #region Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Presenter.LoadSettings();
        }

        private void AddScript(object sender, EventArgs e)
        {
            ShowScriptForm(null, (Script addedScript) => {
                if (Presenter.AddScript(addedScript))
                {
                    scriptListManager.AddItem(addedScript);
                }
            });
        }

        private void ChangeScriptStatus(Script script)
        {
            Script.Status newStatus = Presenter.ChangeScriptStatus(script);
            scriptListManager.ChangeScriptStatus(script.Id, newStatus);
        }

        private void RemoveScript(Script script)
        {
            DialogResult r = MetroSetMessageBox.Show(this, "Do you want to remove the script?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                int scriptId = script.Id;
                if (Presenter.RemoveScript(scriptId))
                {
                    scriptListManager.RemoveItem(scriptId);
                }
            }
        }

        private void EditScript(Script script)
        {
            ShowScriptForm(script, (Script editedScript) => {
                if (Presenter.EditScript(editedScript))
                {
                    scriptListManager.EditItem(editedScript);
                }
            });
        }
        #endregion

        private void ShowScriptForm(Script script, Action<Script> postAction)
        {
            ScriptForm scriptForm = new ScriptForm(styleManager, script);
            if (scriptForm.ShowDialog() == DialogResult.OK)
            {
                postAction(scriptForm.GetScript());
            }
        }

        public void ShowScripts(IList<Script> scripts)
        {
            scriptListManager.CreateWithList(scripts);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void appNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            
        }
    }
}
