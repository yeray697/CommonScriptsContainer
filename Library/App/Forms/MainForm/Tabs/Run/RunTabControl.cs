using App.CustomComponent.ScriptListBox;
using App.Service;
using Contracts.Key;
using Contracts.Scripts;
using Contracts.Scripts.Base;
using Data.Service.Interfaces;
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
        private IScriptsService? _scriptsService;
        private List<ScriptAbs> _scripts;
        public RunTabControl()
        {
            InitializeComponent();

            _scripts = new();

            _scriptListAdapter = new ScriptListAdapter(pnlScripts);
            _scriptListAdapter.ShowMenu += ShowContextMenuScript;
            _scriptListAdapter.StatusClicked += ChangeScriptStatusClicked;

            _listenKeysService = ListenKeysService.GetInstance();
            _listenKeysService.KeyUpClicked += ListenKeysService_KeyUpClicked;
        }

        #region Public methods
        public void SetRunScriptService(IRunScriptService runScriptService)
        {
            _runScriptService = runScriptService;
            _runScriptService.OneOffScriptExecuted += OneOffJobWasExecuted;
        }
        public List<ScriptAbs> SetScriptsService(IScriptsService scriptsService)
        {
            _scriptsService = scriptsService;
            _scripts = _scriptsService.GetScripts();
            return _scripts;
        }
        public async void RefreshScriptStatusAsync(string scriptId)
        {
            var script = _scripts.FirstOrDefault(s => s.Id == scriptId)?.Clone();
            await ChangeScriptStatusAsync(script);
        }
        public async void RunScriptsOnStartupAsync()
        {
            var scripts = GetRunningScriptsByType<ScriptOnStartup>();
            foreach (var script in scripts)
            {
                await _runScriptService!.RunScriptAsync(script);
            }
        }
        #endregion
        #region Events
        private async void OnLoad(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            _scriptListAdapter.CreateWithList(_scripts);
            await CheckIfScriptsNeedToRunOnLoadAsync();
        }
        private void OneOffJobWasExecuted(string scriptId)
        {
            var script = _scripts.FirstOrDefault(s => s.Id == scriptId)?.Clone();
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
                ShowRemoveScriptDialog(script);
            }
        }
        private void ListenKeysService_KeyUpClicked(KeyPressed keyPressed)
        {
            Log.Debug("MainPresenter: KeyUpClicked event received");
            foreach (ScriptListenKey item in GetRunningScriptsByType<ScriptListenKey>())
            {
                if (item.TriggerKey?.Equals(keyPressed) ?? false)
                {
                    Log.Debug("KeyUp matches with a running ScriptListenKey script ({@ScriptName})", item.ScriptName);
                    _runScriptService!.RunScriptAsync(item);
                }

            }
        }
        #endregion

        #region Private Methods
        private async Task CheckIfScriptsNeedToRunOnLoadAsync()
        {
            foreach (var script in GetRunningScriptsByType<ScriptScheduled>())
                await _runScriptService!.RunScriptAsync(script);

            if (IsListenKeyServiceNecessary())
                _listenKeysService.Run();
        }
        private bool IsListenKeyServiceNecessary(string? executingScriptId = null)
            => GetRunningScriptsByType<ScriptListenKey>()?.Any(s => s.Id != executingScriptId) ?? false;
        private IEnumerable<T> GetRunningScriptsByType<T>() 
            where T : ScriptAbs => _scripts.OfType<T>().Where(s => s.ScriptStatus == ScriptStatus.Running);
        private void ChangeScriptStatusThreadSafe(ScriptAbs script)
            => this.Invoke((MethodInvoker) async delegate () { await ChangeScriptStatusAsync(script); });
        private async Task ShowEditScriptFormAsync(ScriptAbs script)
        {
            await ShowScriptForm(script, async (ScriptAbs? editedScript) => {
                if (editedScript == null)
                    return;
                Log.Debug("Editing Script {@ScriptName} ({@ScriptType})", editedScript.ScriptName, editedScript.ScriptType);
                bool rescheduleJob = ScriptAbs.HasScriptTypeChanged(script.ScriptType, editedScript.ScriptType) || ScriptAbs.HasScheduledTimeChanged(script, editedScript);
                UpdateScript(editedScript);
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
            await ShowScriptForm(null, (ScriptAbs? addedScript) => {
                if (addedScript == null)
                    return Task.CompletedTask;
                Log.Debug("Adding Script {@ScriptName} ({@ScriptType})", addedScript.ScriptName, addedScript.ScriptType);
                addedScript.Id = Guid.NewGuid().ToString();
                AddScript(addedScript);
                _scriptListAdapter.AddItem(addedScript);
                ScriptAdded?.Invoke(addedScript);
                return Task.CompletedTask;
            });
        }
        private void ShowRemoveScriptDialog(ScriptAbs script)
        {
            var dialog = new MaterialDialog(this.ParentForm, "Remove", "Do you want to remove the script?", "Yes", true, "No");
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Log.Debug("Removing ScriptId {@ScriptId}", script.Id);
                DeleteScript(script.Id);
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

            UpdateScript(script);

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
        private void AddScript(ScriptAbs addedScript)
        {
            _scriptsService!.AddScript(addedScript);
            _scripts.Add(addedScript);
        }
        private void UpdateScript(ScriptAbs editedScript)
        {
            _scriptsService!.UpdateScript(editedScript);
            int index = _scripts.FindIndex(s => s.Id == editedScript.Id);
            if (index == -1)
                return;
            _scripts[index] = editedScript;
        }
        private void DeleteScript(string scriptId)
        {
            _scriptsService!.DeleteScript(scriptId);
            var scriptToDelete = _scripts.FirstOrDefault(s => s.Id == scriptId);
            if (scriptToDelete == null)
                return;
            _scripts.Remove(scriptToDelete);
        }
        #endregion

    }
}
