using CommonScripts.Model;
using CommonScripts.Model.Base;

namespace CommonScripts.Presenter.Interfaces
{
    public interface IMainPresenter
    {
        void LoadSettings();
        bool AddScript(ScriptAbs script);
        bool EditScript(ScriptAbs script);
        bool RemoveScript(string scriptId);
        ScriptStatus ChangeScriptStatus(ScriptAbs script);
    }
}
