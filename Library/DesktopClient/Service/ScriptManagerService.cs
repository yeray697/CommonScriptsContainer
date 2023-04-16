using Contracts.Scripts;
using Contracts.Scripts.Base;
using Data.Service.Interfaces;
using DesktopClient.Service.Interfaces;
using JobManager.Service;
using Serilog;

namespace DesktopClient.Service
{
    public class ScriptManagerService : IScriptManagerService
    {
        public event IScriptManagerService.ScriptHandler? ScriptAdded;
        public event IScriptManagerService.ScriptEditedHandler? ScriptEdited;
        public event IScriptManagerService.ScriptHandler? ScriptRemoved;
        public event IScriptManagerService.ScriptHandler? ScriptStatusChanged;

        private readonly IRunScriptService _runScriptService;
        private readonly IScriptsService _scriptsService;
        private readonly string _client;

        private List<ScriptAbs>? _scripts;

        public ScriptManagerService(string client, IRunScriptService runScriptService, IScriptsService scriptsService)
        {
            _client = client;
            _runScriptService = runScriptService;
            _scriptsService = scriptsService;
            _runScriptService.OneOffScriptExecuted += (scriptId) => ModifyScriptStatusById(scriptId, ScriptStatus.Stopped);
            _runScriptService.ScriptStarted += (scriptId) => ModifyScriptStatusById(scriptId, ScriptStatus.Running);
            _runScriptService.ScriptStopped += (scriptId) => ModifyScriptStatusById(scriptId, ScriptStatus.Stopped);
        }

        public void AddScript(ScriptAbs script)
        {
            Log.Debug("Adding Script {@ScriptName} ({@ScriptType}) from {@Client}", script.ScriptName, script.ScriptType, _client);
            script.Id = Guid.NewGuid().ToString();
            _scriptsService!.AddScript(script);
            GetScripts().Add(script);
            ScriptAdded?.Invoke(script);
        }

        public async Task EditScriptAsync(ScriptAbs oldScript, ScriptAbs editedScript)
        {
            Log.Debug("Editing Script {@ScriptName} ({@ScriptType}) from {@Client}", oldScript.ScriptName, oldScript.ScriptType, _client);
            _scriptsService!.UpdateScript(editedScript);

            int index = GetScripts().FindIndex(s => s.Id == editedScript.Id);
            if (index == -1)
                return;
            _scripts![index] = editedScript;

            ScriptEdited?.Invoke(oldScript, editedScript);
            if (editedScript.ScriptStatus == ScriptStatus.Running 
                && (ScriptAbs.HasScriptTypeChanged(oldScript.ScriptType, editedScript.ScriptType) || ScriptAbs.HasScheduledTimeChanged(oldScript, editedScript)))
            {
                await _runScriptService!.StopScriptAsync(editedScript);
                if (editedScript.ScriptType != ScriptType.OneOff)
                    await _runScriptService!.RunScriptAsync(editedScript);
                else
                    ScriptStatusChanged?.Invoke(editedScript);
            }
        }

        public List<ScriptAbs> GetScripts(bool refresh = false)
        {
            if (_scripts ==  null || refresh)
                _scripts = _scriptsService.GetScripts();
            return _scripts;
        }

        public void RemoveScript(ScriptAbs script)
        {
            Log.Debug("Removing ScriptId {@ScriptId} from {@Client}", script.Id, _client);
            _scriptsService!.DeleteScript(script.Id);
            var scriptToDelete = GetScripts()!.FirstOrDefault(s => s.Id == script.Id);
            if (scriptToDelete == null)
                return;
            _scripts!.Remove(scriptToDelete);
            ScriptRemoved?.Invoke(script);
        }

        public async Task RunScriptAsync(ScriptAbs script)
            => await _runScriptService!.RunScriptAsync(script);

        public async Task StopScriptAsync(ScriptAbs script)
            => await _runScriptService!.StopScriptAsync(script);

        public void ModifyScriptStatusById(string scriptId, ScriptStatus newScriptStatus)
        {
            var script = GetScripts().FirstOrDefault(s => s.Id == scriptId);
            if (script != null)
            {
                script.ScriptStatus = newScriptStatus;
                _scriptsService!.UpdateScript(script);
                ScriptStatusChanged?.Invoke(script);
            }
        }
    }
}
