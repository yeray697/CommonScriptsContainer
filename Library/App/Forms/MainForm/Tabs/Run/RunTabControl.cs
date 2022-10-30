using App.CustomComponent.ScriptListBox;
using App.Service;
using Contracts.Key;
using Contracts.Scripts;
using Contracts.Scripts.Base;
using Data;
using JobManager.Job;
using JobManager.Service;
using MaterialSkin.Controls;
using Serilog;
using System.Windows.Forms;

namespace App.Forms.MainForm.Tabs.Run
{
    public partial class RunTabControl : UserControl
    {
        private readonly ScriptListAdapter _scriptListAdapter;
        private readonly ListenKeysService _listenKeysService;
        private IRunScriptService? _runScriptService;
        private JobListener _oneOffJobListener;
        public RunTabControl()
        {
            InitializeComponent();

            _scriptListAdapter = new ScriptListAdapter(pnlScripts);
            _scriptListAdapter.ShowMenu += ShowContextMenuScript;
            _scriptListAdapter.StatusClicked += ChangeScriptStatusClicked;

            _listenKeysService = ListenKeysService.GetInstance();
            _listenKeysService.KeyUpClicked += ListenKeysService_KeyUpClicked;

            _oneOffJobListener = new JobListener();
            _oneOffJobListener.JobWasExecutedListener += OneOffJobWasExecuted;
        }
        public void SetRunScriptService(IRunScriptService runScriptService)
        {
            _runScriptService = runScriptService;
            _runScriptService.SetOneOffJobListener(_oneOffJobListener);
        }
        #region Events
        private void OnLoad(object sender, EventArgs e)
        {
            _scriptListAdapter.CreateWithList(SettingsManager.Scripts);
        }
        private async void OneOffJobWasExecuted(Quartz.IJobExecutionContext context, Quartz.JobExecutionException jobException)
        {
            string scriptId = context.JobDetail.Key.Name;
            var script = SettingsManager.Scripts.FirstOrDefault(s => s.Id == scriptId);
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
            await ChangeScriptStatus(script);
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
                    _runScriptService!.RunScript(item);
                }

            }
        }
        #endregion
        private static bool IsListenKeyServiceNecessary()
        {
            return GetScriptListenKeyScripts()?.Any(s => s.ScriptStatus == ScriptStatus.Running) ?? false;
        }
        private static IEnumerable<ScriptListenKey> GetScriptListenKeyScripts()
        {
            return SettingsManager.Scripts.OfType<ScriptListenKey>();
        }
        #region Private Methods
        public async void ChangeScriptStatusThreadSafe(ScriptAbs script)
        {
            this.Invoke((MethodInvoker)delegate () { ChangeScriptStatus(script); });
        }
        private async Task ShowEditScriptFormAsync(ScriptAbs script)
        {
            await ShowScriptForm(script, async (ScriptAbs editedScript) => {
                Log.Debug("Editing Script {@ScriptName} ({@ScriptType})", editedScript.ScriptName, editedScript.ScriptType);
                bool rescheduleJob = ScriptAbs.HasScriptTypeChanged(script.ScriptType, editedScript.ScriptType) || ScriptAbs.HasScheduledTimeChanged(script, editedScript);
                bool removed = await RemoveScriptAsync(editedScript.Id, false);
                if (removed) //ToDo this could be improved
                {
                    SettingsManager.Scripts.Add(editedScript);
                    await SettingsManager.UpdateScriptsAsync(SettingsManager.Scripts);
                    if (editedScript.ScriptStatus == ScriptStatus.Running && rescheduleJob)
                    {
                        await _runScriptService!.StopScript(editedScript);
                        if (editedScript.ScriptType != ScriptType.OneOff)
                            await _runScriptService!.RunScript(editedScript);
                        else
                            await ChangeScriptStatus(editedScript);
                    }
                    _scriptListAdapter.EditItem(script, editedScript);
                }
            });
        }
        private async Task ShowAddScriptForm()
        {
            await ShowScriptForm(null, async (ScriptAbs addedScript) => {
                Log.Debug("Adding Script {@ScriptName} ({@ScriptType})", addedScript.ScriptName, addedScript.ScriptType);
                addedScript.Id = Guid.NewGuid().ToString();
                SettingsManager.Scripts.Add(addedScript);
                await SettingsManager.UpdateScriptsAsync(SettingsManager.Scripts);
                _scriptListAdapter.AddItem(addedScript);
            });
        }
        private async Task ShowRemoveScriptDialogAsync(ScriptAbs script)
        {
            var dialog = new MaterialDialog(this.ParentForm, "Remove", "Do you want to remove the script?", "Yes", true, "No");
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Log.Debug("Removing ScriptId {@ScriptId}", script.Id);
                await RemoveScriptAsync(script.Id, true);
                _scriptListAdapter.RemoveItem(script.Id);
            }
        }
        private async Task<bool> RemoveScriptAsync(string scriptId, bool save)
        {
            bool successful = false;
            var scriptToRemove = SettingsManager.Scripts.FirstOrDefault(s => s.Id == scriptId);

            if (scriptToRemove != null)
            {
                SettingsManager.Scripts.Remove(scriptToRemove);
                if (save)
                    await SettingsManager.UpdateScriptsAsync(SettingsManager.Scripts);
                successful = true;
            }

            return successful;
        }
        private Task ShowScriptForm(ScriptAbs script, Func<ScriptAbs, Task> postAction)
        {
            ScriptForm scriptForm = new ScriptForm(script);
            if (scriptForm.ShowDialogCenter(this) == DialogResult.OK)
            {
                return postAction(scriptForm.GetScript());
            }
            return Task.CompletedTask;
        }
        private async Task ChangeScriptStatus(ScriptAbs script)
        {
            ScriptStatus oldStatus = script.ScriptStatus;
            script.ScriptStatus = GetNewScriptStatus(oldStatus);

            Log.Debug("Change {@ScriptName} ({@ScriptType}) Script Status from {@OldStatus} to {@NewStatus}", script.ScriptName, script.ScriptType, oldStatus, script.ScriptStatus);
            if (script.ScriptStatus == ScriptStatus.Running)
            {
                if (script is ScriptListenKey)
                    _listenKeysService.Run();
                else
                    await _runScriptService!.RunScript(script);
            }
            else
            {
                if (script is ScriptListenKey && !IsListenKeyServiceNecessary())
                    _listenKeysService.Stop();
                else
                    await _runScriptService!.StopScript(script);
            }

            await SettingsManager.UpdateScriptsAsync(SettingsManager.Scripts);

            _scriptListAdapter.RefreshScriptStatus(script.Id);
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
        public void RefreshScriptStatus(string scriptId)
            => _scriptListAdapter.RefreshScriptStatus(scriptId);
        #endregion

    }
}
