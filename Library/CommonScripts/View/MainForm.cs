using CommonScripts.CustomComponent.ScriptListBox;
using CommonScripts.Extension;
using CommonScripts.Logging;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Presenter;
using CommonScripts.View.Interfaces;
using MetroSet_UI.Forms;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CommonScripts.View
{
    public partial class MainForm : MetroSetForm, IMainView
    {
        private const LogEventLevel MINIMUM_LOG_LEVEL_GUI_CONSOLE = LogEventLevel.Information;
        private ScriptListAdapter _scriptListAdapter;
        public MainPresenter Presenter { get; set; }

        public MainForm()
        {
            InitializeComponent();
            InitScriptListAdapter();
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
            ShowScriptForm(null, (ScriptAbs addedScript) => {
                if (Presenter.AddScript(addedScript))
                {
                    _scriptListAdapter.AddItem(addedScript);
                }
            });
        }
        private void EditScript(ScriptAbs script)
        {
            ShowScriptForm(script, (ScriptAbs editedScript) => {
                bool hasScriptTypeChanged = script != null && ScriptAbs.HasScriptTypeChanged(script.ScriptType, editedScript.ScriptType);
                if (Presenter.EditScript(editedScript, hasScriptTypeChanged))
                {
                    _scriptListAdapter.EditItem(editedScript, hasScriptTypeChanged);
                }
            });
        }
        private void RemoveScript(ScriptAbs script)
        {
            DialogResult r = MetroSetMessageBox.Show(this, "Do you want to remove the script?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                string scriptId = script.Id;
                if (Presenter.RemoveScript(scriptId))
                {
                    _scriptListAdapter.RemoveItem(scriptId);
                }
            }
        }
        private void ChangeScriptStatus(ScriptAbs script)
        {
            bool hasStatusChanged = Presenter.ChangeScriptStatus(script).Result;
            if (hasStatusChanged)
                _scriptListAdapter.ChangeScriptStatus(script.Id);
        }
        private void appNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                this.ShowInTaskbar = false;
            }
        }
        public void LogEmitted(LogMsg log)
        {
            if (log.Lvl >= MINIMUM_LOG_LEVEL_GUI_CONSOLE)
            {
                Color color = GetConsoleTextColor(log.Lvl);
                rtbConsole.AppendTextThreadSafe(log.ToString(), color, true);
            }
        }
        #endregion

        #region Public Methods
        public void ShowScripts(IList<ScriptAbs> scripts)
        {
            _scriptListAdapter.CreateWithList(scripts);
        }
        public void ShowRunAtStartupDialog()
        {
            DialogResult r = MetroSetMessageBox.Show(this, null, "Do you want to set the app to run at startup?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
                Presenter.SetAppRunAtStartup();
            else
                Presenter.DoNotAskAgainRunAtStartup();
        }
        public void ChangeScriptStatusThreadSafe(ScriptAbs script)
        {
            this.Invoke((MethodInvoker)delegate () { ChangeScriptStatus(script); });
        }
        #endregion

        #region Private Methods
        private void ShowScriptForm(ScriptAbs script, Action<ScriptAbs> postAction)
        {
            ScriptForm scriptForm = new ScriptForm(styleManager, script);
            if (scriptForm.ShowDialog() == DialogResult.OK)
            {
                postAction(scriptForm.GetScript());
            }
        }
        private void InitScriptListAdapter()
        {
            _scriptListAdapter = new ScriptListAdapter(StyleManager, pnlScripts);
            _scriptListAdapter.EditClicked += EditScript;
            _scriptListAdapter.RemoveClicked += RemoveScript;
            _scriptListAdapter.StatusClicked += ChangeScriptStatus;
        }
        private Color GetConsoleTextColor(LogEventLevel logLevel)
        {
            //ToDo: Implementing dark mode
            Color color;
            switch (logLevel)
            {
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    color = Color.DarkRed;
                    break;
                case LogEventLevel.Warning:
                    color = Color.Orange;
                    break;
                case LogEventLevel.Debug:
                case LogEventLevel.Verbose:
                default:
                    color = Color.Black;
                    break;
            }
            return color;
        }
        #endregion
    }
}
