using CommonScripts.Extension;
using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Model.Service;
using CommonScripts.Utils;
using MetroSet_UI.Components;
using MetroSet_UI.Forms;
using Serilog;
using System;
using System.Windows.Forms;

namespace CommonScripts.View
{
    public partial class ScriptForm : MetroSetForm
    {
        public bool HasScriptTypeChanged { get; internal set; }

        private ScriptAbs _script;
        private bool _listeningKeys = false;

        public ScriptForm(StyleManager styleManager, ScriptAbs script)
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
            LoadSpecificScriptFields();
        }

        #region Events
        private void Cancel(object sender, EventArgs e)
        {
            _script = null;
            Close();
        }
        private void Save(object sender, EventArgs e)
        {
            ScriptType scriptType = EnumUtils.ParseOrDefault<ScriptType>(cbxScriptType.SelectedValue);

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
                    ((ScriptListenKey)_script).TriggerKey = (KeyPressed)tbxKeyPressed.Tag;
                    break;
                default:
                    break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        private void ShowPathSelector(object sender, EventArgs e)
        {
            if (ofdScriptPath.ShowDialog() == DialogResult.OK)
                tbxScriptPath.Text = ofdScriptPath.FileName;
        }
        private void ListenKeysService_KeyUpClicked(KeyPressed keyPressed)
        {
            Log.Debug("ScriptForm: SingleKeyUpClicked event received");
            tbxKeyPressed.Text = keyPressed.ToString();
            tbxKeyPressed.Tag = keyPressed;
            StopListeningKeys();
        }
        private void cbxScriptType_SelectedValueChanged(object sender, EventArgs e)
        {
            ScriptType scriptType;
            Enum.TryParse<ScriptType>(cbxScriptType.SelectedValue.ToString(), out scriptType);

            StopListeningKeys();
            DisplaySpecificScriptFields();
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
        #endregion

        #region Private Methods
        private void UpdateMetroStyles(StyleManager styleManager)
        {
            this.StyleManager = styleManager.Clone(this);
        }
        private void DisplayScriptListeningKeyText()
        {
            tbxKeyPressed.Text = "Undefined";
            if (_listeningKeys)
            {
                tbxKeyPressed.Text = "Listening...";
            } else if (_script != null && _script is ScriptListenKey)
            {
                KeyPressed triggerKey = ((ScriptListenKey)_script).TriggerKey;
                if (triggerKey != null)
                    tbxKeyPressed.Text = triggerKey.ToString();
            }
        }
        private void DisplaySpecificScriptFields()
        {
            ScriptType scriptType = EnumUtils.ParseOrDefault<ScriptType>(cbxScriptType.SelectedValue);

            switch (scriptType)
            {
                case ScriptType.OneOff:
                    HideScheduledScriptFields(true);
                    HideListenKeyScriptFields(true);
                    break;
                case ScriptType.Scheduled:
                    HideScheduledScriptFields(false);
                    HideListenKeyScriptFields(true);
                    AssignDateTimePickerValue();
                    break;
                case ScriptType.ListenKey:
                    HideScheduledScriptFields(true);
                    HideListenKeyScriptFields(false);
                    DisplayScriptListeningKeyText();
                    break;
                default:
                    break;
            }
        }
        private void LoadSpecificScriptFields()
        {
            if (_script != null)
            {
                ScriptType scriptType = EnumUtils.ParseOrDefault<ScriptType>(cbxScriptType.SelectedValue);

                switch (scriptType)
                {
                    case ScriptType.OneOff:
                        break;
                    case ScriptType.Scheduled:
                        AssignDateTimePickerValue();
                        break;
                    case ScriptType.ListenKey:
                        DisplayScriptListeningKeyText();
                        break;
                    default:
                        break;
                }
            }

            DisplaySpecificScriptFields();
        }
        private void AssignDateTimePickerValue()
        {
            DateTime value = DateTime.Now.Date;
            if (_script != null && _script is ScriptScheduled)
                value += ((ScriptScheduled)_script).ScheduledHour;
            
            dtpScriptScheduled.Value = value;
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
        private void StartListeningKeys()
        {
            _listeningKeys = true;
            DisplayScriptListeningKeyText();

            ListenKeysService listenKeysService = ListenKeysService.GetInstance();
            listenKeysService.SingleKeyUpClicked += ListenKeysService_KeyUpClicked;
            listenKeysService.Run(true);
        }
        private void StopListeningKeys()
        {
            _listeningKeys = false;
        }
        #endregion

        #region Public Methods
        public ScriptAbs GetScript() => _script;
        #endregion
    }
}
