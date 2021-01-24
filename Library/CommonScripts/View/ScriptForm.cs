using CommonScripts.Extension;
using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using CommonScripts.Model.Service;
using CommonScripts.Utils;
using CommonScripts.View.Base;
using MetroSet_UI.Components;
using MetroSet_UI.Forms;
using Serilog;
using System;
using System.Windows.Forms;

namespace CommonScripts.View
{
    public partial class ScriptForm : BaseInnerForm
    {
        private ScriptAbs _script;
        private bool _listeningKeys = false;

        private const string FORM_TITLE_ADD = "Add Script";
        private const string FORM_TITLE_EDIT = "Update Script";
        private const string KEY_PRESSED_UNDEFINED_TEXT = "Undefined";
        private const string KEY_PRESSED_LISTENING_TEXT = "Listening...";

        public ScriptForm(StyleManager styleManager, ScriptAbs script) : base()
        {
            InitializeComponent();
            UpdateMetroStyles(styleManager);
            string formTitle = FORM_TITLE_ADD;
            if (script != null)
            {
                formTitle = FORM_TITLE_EDIT;
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
            if (ValidateBeforeSaving())
            {
                ScriptType scriptType = EnumUtils.Parse<ScriptType>(cbxScriptType.SelectedValue);
                ScriptStatus scriptStatus = _script?.ScriptStatus ?? ScriptStatus.Stopped;
                _script = ScriptAbs.GetInstance(_script, scriptType);
                _script.ScriptName = tbxScriptName.Text;
                _script.ScriptPath = tbxScriptPath.Text;
                _script.ScriptStatus = scriptStatus;

                switch (scriptType)
                {
                    case ScriptType.OneOff:
                        break;
                    case ScriptType.Scheduled:
                        DateTime dt = DateTime.Parse(tbxScriptScheduled.Text);
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
        private void ScriptTypeChanged(object sender, EventArgs e)
        {
            StopListeningKeys();
            DisplaySpecificScriptFields();
        }
        private void RemoveKeyMappingClicked(object sender, EventArgs e)
        {
            StopListeningKeys();
            tbxKeyPressed.Text = KEY_PRESSED_UNDEFINED_TEXT;
            tbxKeyPressed.Tag = null;
        }
        private void EditKeyMappingClicked(object sender, EventArgs e)
        {
            StartListeningKeys();
        }
        #endregion

        #region Private Methods
        private void DisplayScriptListeningKeyText()
        {
            tbxKeyPressed.Text = KEY_PRESSED_UNDEFINED_TEXT;
            tbxKeyPressed.Tag = null;
            if (_listeningKeys)
            {
                tbxKeyPressed.Text = KEY_PRESSED_LISTENING_TEXT;
            }
            else if (_script != null && _script is ScriptListenKey scriptListenKey)
            {
                KeyPressed triggerKey = scriptListenKey.TriggerKey;
                if (triggerKey != null)
                {
                    tbxKeyPressed.Text = triggerKey.ToString();
                    tbxKeyPressed.Tag = triggerKey;
                }
            }
        }
        private void DisplaySpecificScriptFields()
        {
            ScriptType scriptType = EnumUtils.Parse<ScriptType>(cbxScriptType.SelectedValue);

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
                ScriptType scriptType = EnumUtils.Parse<ScriptType>(cbxScriptType.SelectedValue);

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
            if (_script != null && _script is ScriptScheduled scriptScheduled)
                value += scriptScheduled.ScheduledHour;

            tbxScriptScheduled.Text = value.ToString("HH:mm");
        }
        private void HideScheduledScriptFields(bool hide)
        {
            if (hide)
            {
                lblScriptSchedule.Hide();
                tbxScriptScheduled.Hide();
            }
            else
            {
                lblScriptSchedule.Show();
                tbxScriptScheduled.Show();
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
        private bool IsMaskDatetimeValid(string maskedText)
        {
            string value = maskedText.Replace(":", "").Trim();

            return (value != String.Empty && value.Length == 4
                && int.TryParse(value.Substring(0, 2), out int hour) && int.TryParse(value.Substring(2, 2), out int minute)
                && hour >= 0 && hour <= 23 && minute >= 0 && minute <= 59);
        }
        private bool ValidateBeforeSaving()
        {
            bool isValid = true;
            ScriptType scriptType = EnumUtils.Parse<ScriptType>(cbxScriptType.SelectedValue);
            if (scriptType == ScriptType.Scheduled && !IsMaskDatetimeValid(tbxScriptScheduled.Text))
            {
                isValid = false;
                MetroSetMessageBox.Show(this, "The Scheduled Time is not in valid format (00:00). Please change the value before saving it."
                    , "Error validating the script fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }
        #endregion

        #region Public Methods
        public override void UpdateMetroStyles(StyleManager styleManager)
        {
            base.UpdateMetroStyles(styleManager);
            tbxScriptScheduled.ApplyTheme(styleManager.Style);
        }
        public ScriptAbs GetScript() => _script;
        #endregion
    }
}
