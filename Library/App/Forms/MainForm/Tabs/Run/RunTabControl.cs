using App.CustomComponent.ScriptListBox;
using App.Service;
using Contracts.Key;
using Contracts.Scripts;
using Contracts.Scripts.Base;
using Data;
using JobManager.Service;
using MaterialSkin.Controls;
using Serilog;

namespace App.Forms.MainForm.Tabs.Run
{
    public partial class RunTabControl : UserControl
    {
        public delegate void ScriptChangedHandler(ScriptAbs source);
        public event ScriptChangedHandler? ScriptEdited;
        public event ScriptChangedHandler? ScriptAdded;
        public event ScriptChangedHandler? ScriptRemoved;

        private readonly ScriptListAdapter _scriptListAdapter;
        private readonly ListenKeysService _listenKeysService;
        private IRunScriptService? _runScriptService;
        public RunTabControl()
        {
            InitializeComponent();

            _scriptListAdapter = new ScriptListAdapter(pnlScripts);
            _scriptListAdapter.ShowMenu += ShowContextMenuScript;
            _scriptListAdapter.StatusClicked += ChangeScriptStatusClicked;

            _listenKeysService = ListenKeysService.GetInstance();
            _listenKeysService.KeyUpClicked += ListenKeysService_KeyUpClicked;
        }
        public void SetRunScriptService(IRunScriptService runScriptService)
        {
            _runScriptService = runScriptService;
            _runScriptService.OneOffScriptExecuted += OneOffJobWasExecuted;
        }
        #region Events
        private void OnLoad(object sender, EventArgs e)
        {
            _scriptListAdapter.CreateWithList(SettingsManager.Scripts);
        }
        private void OneOffJobWasExecuted(string scriptId)
        {
            var script = SettingsManager.FindScriptById(scriptId);
            if (script != null)
                ChangeScriptStatusThreadSafe(script);
        }
        private void ShowContextMenuScript(ScriptAbs script)
        {
            cmsScriptList.Tag = script;
            cmsScriptList.Show(Cursor.Position);
        }
        private async void ChangeScriptStatusClicked(ScriptAbs script)
        {
            await ChangeScriptStatusAsync(script);
        }
        private async void AddScriptButtonClicked(object sender, EventArgs e)
        {
            await ShowAddScriptForm();
        }
        private async void ContextMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var control = (sender as Control)!;
            var script = (control.Tag as ScriptAbs)!;
            control.Tag = null;

            if (e.ClickedItem.Text == "Edit")
            {
                await ShowEditScriptFormAsync(script);
            }
            else if (e.ClickedItem.Text == "Remove")
            {
                await ShowRemoveScriptDialogAsync(script);
            }
        }
        private void ListenKeysService_KeyUpClicked(KeyPressed keyPressed)
        {
            Log.Debug("MainPresenter: KeyUpClicked event received");
            foreach (ScriptListenKey item in GetScriptListenKeyScripts())
            {
                if (item.ScriptStatus == ScriptStatus.Running && (item.TriggerKey?.Equals(keyPressed) ?? false))
                {
                    Log.Debug("KeyUp matches with a running ScriptListenKey script ({@ScriptName})", item.ScriptName);
                    _runScriptService!.RunScriptAsync(item);
                }

            }
        }
        #endregion
        private static bool IsListenKeyServiceNecessary(string executingScriptId)
        {
            return GetScriptListenKeyScripts()?.Any(s => s.ScriptStatus == ScriptStatus.Running && s.Id != executingScriptId) ?? false;
        }
        private static IEnumerable<ScriptListenKey> GetScriptListenKeyScripts()
        {
            return SettingsManager.Scripts.OfType<ScriptListenKey>();
        }
        #region Private Methods
        public void ChangeScriptStatusThreadSafe(ScriptAbs script)
        {
            this.Invoke((MethodInvoker) async delegate () { await ChangeScriptStatusAsync(script); });
        }
        private async Task ShowEditScriptFormAsync(ScriptAbs script)
        {
            await ShowScriptForm(script, async (ScriptAbs? editedScript) => {
                if (editedScript == null)
                    return;
                Log.Debug("Editing Script {@ScriptName} ({@ScriptType})", editedScript.ScriptName, editedScript.ScriptType);
                bool rescheduleJob = ScriptAbs.HasScriptTypeChanged(script.ScriptType, editedScript.ScriptType) || ScriptAbs.HasScheduledTimeChanged(script, editedScript);
                await SettingsManager.EditScriptAsync(editedScript);
                if (editedScript.ScriptStatus == ScriptStatus.Running && rescheduleJob)
                {
                    await _runScriptService!.StopScriptAsync(editedScript);
                    if (editedScript.ScriptType != ScriptType.OneOff)
                        await _runScriptService!.RunScriptAsync(editedScript);
                    else
                        await ChangeScriptStatusAsync(editedScript);
                }
                _scriptListAdapter.EditItem(script, editedScript);
                ScriptEdited?.Invoke(editedScript);
            });
        }
        private async Task ShowAddScriptForm()
        {
            await ShowScriptForm(null, async (ScriptAbs? addedScript) => {
                if (addedScript == null)
                    return;
                Log.Debug("Adding Script {@ScriptName} ({@ScriptType})", addedScript.ScriptName, addedScript.ScriptType);
                addedScript.Id = Guid.NewGuid().ToString();
                await SettingsManager.AddScriptAsync(addedScript);
                _scriptListAdapter.AddItem(addedScript);
                ScriptAdded?.Invoke(addedScript);
            });
        }
        private async Task ShowRemoveScriptDialogAsync(ScriptAbs script)
        {
            var dialog = new MaterialDialog(this.ParentForm, "Remove", "Do you want to remove the script?", "Yes", true, "No");
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Log.Debug("Removing ScriptId {@ScriptId}", script.Id);
                await SettingsManager.RemoveScriptAsync(script.Id);
                _scriptListAdapter.RemoveItem(script.Id);
                ScriptRemoved?.Invoke(script);
            }
        }
        private Task ShowScriptForm(ScriptAbs? script, Func<ScriptAbs?, Task> postAction)
        {
            var scriptForm = new ScriptForm(script);
            if (scriptForm.ShowDialogCenter(this) == DialogResult.OK)
            {
                return postAction(scriptForm.GetScript());
            }
            return Task.CompletedTask;
        }
        private async Task ChangeScriptStatusAsync(ScriptAbs? script)
        {
            if (script == null)
                return;
            ScriptStatus oldStatus = script.ScriptStatus;
            script.ScriptStatus = GetNewScriptStatus(oldStatus);

            Log.Debug("Change {@ScriptName} ({@ScriptType}) Script Status from {@OldStatus} to {@NewStatus}", script.ScriptName, script.ScriptType, oldStatus, script.ScriptStatus);
            if (script.ScriptStatus == ScriptStatus.Running)
            {
                if (script is ScriptListenKey)
                    _listenKeysService.Run();
                else
                    await _runScriptService!.RunScriptAsync(script);
            }
            else
            {
                if (script is ScriptListenKey && !IsListenKeyServiceNecessary(script.Id))
                    _listenKeysService.Stop();
                else 
                    await _runScriptService!.StopScriptAsync(script);
            }

            await SettingsManager.EditScriptAsync(script);

            _scriptListAdapter.RefreshScriptStatus(script.Id, script.ScriptStatus);
            ScriptEdited?.Invoke(script);
        }
        private static ScriptStatus GetNewScriptStatus(ScriptStatus oldStatus)
        {
            ScriptStatus newStatus = ScriptStatus.Undefined;
            switch (oldStatus)
            {
                case ScriptStatus.Running:
                    newStatus = ScriptStatus.Stopped;
                    break;
                case ScriptStatus.Undefined:
                case ScriptStatus.Stopped:
                    newStatus = ScriptStatus.Running;
                    break;
                default:
                    break;
            }
            return newStatus;
        }
        #endregion

        #region Public methods
        public async void RefreshScriptStatusAsync(string scriptId)
        {
            var script = SettingsManager.FindScriptById(scriptId);
            await ChangeScriptStatusAsync(script);
        }
        #endregion

    }
}
