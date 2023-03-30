using Contracts.Key;
using Contracts.Scripts;
using Contracts.Scripts.Base;
using DesktopClient.CustomComponent.ScriptListBox;
using DesktopClient.Service;
using DesktopClient.Service.Interfaces;
using MaterialSkin.Controls;
using Serilog;

namespace DesktopClient.Forms.MainForm.Tabs.Run
{
    public partial class RunTabControl : UserControl
    {
        public delegate void ScriptChangedHandler(ScriptAbs source);
        public event ScriptChangedHandler? ScriptEdited;
        public event ScriptChangedHandler? ScriptAdded;
        public event ScriptChangedHandler? ScriptRemoved;

        private readonly ScriptListAdapter _scriptListAdapter;
        private readonly ListenKeysService _listenKeysService;
        private IScriptManagerService? _scriptManagerService;
        private List<ScriptAbs> _scripts;
        private bool _runScriptsOnStartup;
        public RunTabControl()
        {
            InitializeComponent();

            _scripts = new();

            _scriptListAdapter = new ScriptListAdapter(pnlScripts);
            _scriptListAdapter.ShowMenu += ShowContextMenuScript;
            _scriptListAdapter.StatusClicked += ScriptStatusButtonClickedAsync;

            _listenKeysService = ListenKeysService.GetInstance();
            _listenKeysService.KeyUpClicked += ListenKeysService_KeyUpClicked;
        }

        #region Public methods
        public List<ScriptAbs> InitTabController(IScriptManagerService scriptManagerService, bool runScriptsOnStartup)
        {
            _runScriptsOnStartup = runScriptsOnStartup;
            _scriptManagerService = scriptManagerService;
            _scriptManagerService.ScriptAdded += OnScriptAdded;
            _scriptManagerService.ScriptEdited += OnScriptEdited;
            _scriptManagerService.ScriptRemoved += OnScriptRemoved;
            _scriptManagerService.ScriptStatusChanged += (script) => ModifyScriptStatusByIdThreadSafe(script.Id, script.ScriptStatus);

            _scripts = _scriptManagerService.GetScripts();

            return _scripts;
        }
        public async Task SwapScriptStatusAsync(ScriptAbs? script)
        {
            await Task.Run(() => ScriptStatusButtonClickedAsync(script));
        }

        #endregion
        #region Events
        private async void OnLoad(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            _scriptListAdapter.CreateWithList(_scripts);
            await CheckIfScriptsNeedToRunOnLoadAsync();
        }
        private void OnScriptAdded(ScriptAbs script)
        {
            _scriptListAdapter.AddItem(script);
            ScriptAdded?.Invoke(script);
        }
        private void OnScriptEdited(ScriptAbs oldScript, ScriptAbs editedScript)
        {
            _scriptListAdapter.EditItem(oldScript, editedScript);
            ScriptEdited?.Invoke(editedScript);
        }
        private void OnScriptRemoved(ScriptAbs script)
        {
            _scriptListAdapter.RemoveItem(script.Id);
            ScriptRemoved?.Invoke(script);
        }
        private void ShowContextMenuScript(ScriptAbs script)
        {
            cmsScriptList.Tag = script;
            cmsScriptList.Show(Cursor.Position);
        }
        private async void ScriptStatusButtonClickedAsync(ScriptAbs? script)
        {
            if (script == null)
                return;

            Log.Debug("Change {@ScriptName} ({@ScriptType}) Script Status from {@OldStatus}", script.ScriptName, script.ScriptType, script.ScriptStatus);
            if (script.ScriptStatus == ScriptStatus.Stopped)
            {
                if (script is ScriptListenKey)
                    _listenKeysService.Run();
                
                await _scriptManagerService!.RunScriptAsync(script);
            }
            else
            {
                if (script is ScriptListenKey && !IsListenKeyServiceNecessary(script.Id))
                    _listenKeysService.Stop();
                await _scriptManagerService!.StopScriptAsync(script);
            }
            //OneOffs are updated by IRunScriptService events
            //The other scripts need to be updated here
            //if (script is not ScriptOneOff)
            //{
            //    ModifyScriptStatusByIdThreadSafe(script.Id, newStatus);
            //}
        }
        private async void AddScriptButtonClicked(object sender, EventArgs e)
            => await ShowAddScriptForm();
        private async void ContextMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == null)
                return;
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
            var scripts = GetRunningScriptsByType<ScriptListenKey>().ToList();
            foreach (ScriptListenKey item in scripts)
            {
                if (item.TriggerKey?.Equals(keyPressed) ?? false)
                {
                    Log.Debug("KeyUp matches with a running ScriptListenKey script ({@ScriptName})", item.ScriptName);
                    _scriptManagerService!.RunScriptAsync(item);
                }

            }
        }
        #endregion

        #region Private Methods
        private async Task CheckIfScriptsNeedToRunOnLoadAsync()
        {
            if (_runScriptsOnStartup)
            {
                var onStartupScripts = GetRunningScriptsByType<ScriptOnStartup>().ToList();
                foreach (var script in onStartupScripts)
                {
                    await _scriptManagerService!.RunScriptAsync(script);
                }
            }

            var scripts = GetRunningScriptsByType<ScriptScheduled>().ToList();
            foreach (var script in scripts)
                await _scriptManagerService!.RunScriptAsync(script);

            if (IsListenKeyServiceNecessary())
                _listenKeysService.Run();
        }
        private bool IsListenKeyServiceNecessary(string? executingScriptId = null)
            => GetRunningScriptsByType<ScriptListenKey>()?.Any(s => s.Id != executingScriptId) ?? false;
        private IEnumerable<T> GetRunningScriptsByType<T>() 
            where T : ScriptAbs => _scripts.OfType<T>().Where(s => s.ScriptStatus == ScriptStatus.Running);
        private async Task ShowEditScriptFormAsync(ScriptAbs script)
        {
            await ShowScriptForm(script, async (ScriptAbs? editedScript) => {
                if (editedScript == null)
                    return;
                await _scriptManagerService!.EditScriptAsync(script, editedScript);
            });
        }
        private async Task ShowAddScriptForm()
        {
            await ShowScriptForm(null, (ScriptAbs? addedScript) => {
                if (addedScript != null)
                    _scriptManagerService!.AddScript(addedScript);

                return Task.CompletedTask;
            });
        }
        private void ShowRemoveScriptDialog(ScriptAbs script)
        {
            var dialog = new MaterialDialog(this.ParentForm, "Remove", "Do you want to remove the script?", "Yes", true, "No");
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                _scriptManagerService!.RemoveScript(script);
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
        private void ModifyScriptStatusByIdThreadSafe(string scriptId, ScriptStatus newScriptStatus)
        {
            var script = _scripts.FirstOrDefault(s => s.Id == scriptId)?.Clone();
            if (script != null)
            {
                script.ScriptStatus = newScriptStatus;

                this.Invoke((MethodInvoker)delegate () {
                    _scriptListAdapter.RefreshScriptStatus(script.Id, script.ScriptStatus);
                    ScriptEdited?.Invoke(script);
                });
            }
        }
        #endregion

    }
}
