using App.Forms.Base;
using App.Service;
using Common;
using Contracts.Key;
using Contracts.Scripts;
using Contracts.Scripts.Base;
using MaterialSkin.Controls;
using Serilog;

namespace App.Forms
{
    public partial class ScriptForm : BaseInnerForm
    {
        private ScriptAbs _script;
        private bool _listeningKeys = false;

        private const string FORM_TITLE_ADD = "Add Script";
        private const string FORM_TITLE_EDIT = "Update Script";
        private const string KEY_PRESSED_UNDEFINED_TEXT = "";
        private const string KEY_PRESSED_LISTENING_TEXT = "Listening...";

        public ScriptForm(ScriptAbs script) : base()
        {
            InitializeComponent();
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
            if (tbxKeyPressed.ContainsFocus)
                this.ActiveControl = null;
            StopListeningKeys();
        }
        private void ScriptTypeChanged(object sender, EventArgs e)
        {
            StopListeningKeys();
            DisplaySpecificScriptFields();
        }
        private void ListenForKeyControlLeaveFocus(object sender, EventArgs e)
        {
            StopListeningKeys();
            if (tbxKeyPressed.Text == KEY_PRESSED_LISTENING_TEXT)
            {
                tbxKeyPressed.Text = KEY_PRESSED_UNDEFINED_TEXT;
                tbxKeyPressed.Tag = null;
            }
        }
        private void ListenForKeyControlFocused(object sender, EventArgs e)
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
                tbxScriptScheduled.Hide();
            }
            else
            {
                tbxScriptScheduled.Show();
            }
        }
        private void HideListenKeyScriptFields(bool hide)
        {
            if (hide)
            {
                tbxKeyPressed.Hide();
            }
            else
            {
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

                _ = new MaterialDialog(this,
                                       "Error validating the script fields",
                                       "The Scheduled Time is not in valid format (00:00). Please change the value before saving it.",
                                       "Yes")
                    .ShowDialog(this);
            }

            return isValid;
        }
        #endregion

        #region Public Methods
        public ScriptAbs GetScript() => _script;
        #endregion
    }
}
