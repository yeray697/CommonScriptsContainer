using CommonScripts.Extension;
using CommonScripts.Model;
using CommonScripts.Model.Base;
using CommonScripts.Service;
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
        private ScriptAbs _script;
        private bool _listeningKeys = false;

        public bool HasScriptTypeChanged { get; internal set; }

        public ScriptAbs GetScript() => _script;

        public ScriptForm(MetroSet_UI.StyleManager styleManager, ScriptAbs script)
        {
            InitializeComponent();
            UpdateMetroStyles(styleManager);
            string formTitle = "Add Script";
            if (script != null)
            {
                formTitle = "Update Script";
                _script = script.Clone();
                tbxScriptName.Text = _script.ScriptName;
                tbxScriptPath.Text = _script.ScriptPath;
                tbxScriptName.Text = _script.ScriptName;
                tbxScriptPath.Text = _script.ScriptPath;
            }
            cbxScriptType.DataSource = Enum.GetValues(typeof(ScriptType));
            cbxScriptType.SelectedItem = _script == null ? 0 : _script.ScriptType;

            this.Text = formTitle;
            LoadSpecificScriptFields(script);
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
            ScriptType scriptType;
            Enum.TryParse<ScriptType>(cbxScriptType.SelectedValue.ToString(), out scriptType);

            HasScriptTypeChanged = _script != null && (scriptType != _script.ScriptType);
            _script = ScriptAbs.GetInstance(_script, scriptType, HasScriptTypeChanged);
            _script.ScriptName = tbxScriptName.Text;
            _script.ScriptPath = tbxScriptPath.Text;
            _script.ScriptStatus = ScriptStatus.Stopped;

            switch (scriptType) 
            {
                case ScriptType.OneOff:
                    break;
                case ScriptType.Scheduled:
                    DateTime dt = dtpScriptScheduled.Value;
                    TimeSpan st = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
                    ((ScriptScheduled)_script).ScheduledHour = st;
                    break;
                case ScriptType.ListenKey:
                    ((ScriptListenKey)_script).TriggerKey = (KeyPressed) tbxKeyPressed.Tag;
                    break;
                default:
                    break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cbxScriptType_SelectedValueChanged(object sender, EventArgs e)
        {

            ScriptType scriptType;
            Enum.TryParse<ScriptType>(cbxScriptType.SelectedValue.ToString(), out scriptType);

            StopListeningKeys();
            DisplaySpecificScriptFields();

            if (scriptType == ScriptType.ListenKey)
            {
                DisplayScriptListeningKeyText(null);
            }
        }

        private void DisplayScriptListeningKeyText(ScriptAbs script)
        {
            tbxKeyPressed.Text = "Undefined";
            if (_listeningKeys)
            {
                tbxKeyPressed.Text = "Listening...";
            } else if (script != null)
            {
                KeyPressed triggerKey = ((ScriptListenKey)script).TriggerKey;
                if (triggerKey != null)
                    tbxKeyPressed.Text = triggerKey.ToString();
            }
        }

        private void DisplaySpecificScriptFields()
        {
            ScriptType scriptType;
            Enum.TryParse<ScriptType>(cbxScriptType.SelectedValue.ToString(), out scriptType);

            switch (scriptType)
            {
                case ScriptType.OneOff:
                    HideScheduledScriptFields(true);
                    HideListenKeyScriptFields(true);
                    break;
                case ScriptType.Scheduled:
                    HideScheduledScriptFields(false);
                    HideListenKeyScriptFields(true);
                    break;
                case ScriptType.ListenKey:
                    HideScheduledScriptFields(true);
                    HideListenKeyScriptFields(false);
                    break;
                default:
                    break;
            }
        }

        private void LoadSpecificScriptFields(ScriptAbs script)
        {
            if (script != null)
            {
                ScriptType scriptType;
                Enum.TryParse<ScriptType>(cbxScriptType.SelectedValue.ToString(), out scriptType);

                switch (scriptType)
                {
                    case ScriptType.OneOff:
                        break;
                    case ScriptType.Scheduled:
                        TimeSpan scheduledHour = ((ScriptScheduled)script).ScheduledHour;
                        dtpScriptScheduled.Value = DateTime.Now + scheduledHour;
                        break;
                    case ScriptType.ListenKey:
                        DisplayScriptListeningKeyText(script);
                        break;
                    default:
                        break;
                }
            }

            DisplaySpecificScriptFields();
        }

        private void HideScheduledScriptFields(bool hide)
        {
            if (hide)
            {
                lblScriptSchedule.Hide();
                dtpScriptScheduled.Hide();
            }
            else
            {
                lblScriptSchedule.Show();
                dtpScriptScheduled.Show();
            }
        }

        private void HideListenKeyScriptFields(bool hide)
        {
            if (hide)
            {
                lblListenKey.Hide();
                pbxEditKeyPressed.Hide();
                pbxRemoveKeyPressed.Hide();
                tbxKeyPressed.Hide();
            } else
            {
                lblListenKey.Show();
                pbxEditKeyPressed.Show();
                pbxRemoveKeyPressed.Show();
                tbxKeyPressed.Show();
            }
        }

        private void pbxRemoveKeyPressed_Click(object sender, EventArgs e)
        {
            StopListeningKeys();
            tbxKeyPressed.Text = "Undefined";
        }

        private void pbxEditKeyPressed_Click(object sender, EventArgs e)
        {
            StartListeningKeys();
        }

        private void StartListeningKeys()
        {
            _listeningKeys = true;
            DisplayScriptListeningKeyText(null);

            ListenKeysService listenKeysService = ListenKeysService.GetInstance();
            listenKeysService.SingleKeyUpClicked += ListenKeysService_KeyUpClicked;
            listenKeysService.Run(true);
        }

        private void ListenKeysService_KeyUpClicked(KeyPressed keyPressed)
        {
            tbxKeyPressed.Text = keyPressed.ToString();
            tbxKeyPressed.Tag = keyPressed;
            StopListeningKeys();
        }

        private void StopListeningKeys()
        {
            _listeningKeys = false;
        }
    }
}
