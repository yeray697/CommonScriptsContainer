using CommonScripts.Model;
using CommonScripts.Model.Base;

namespace CommonScripts.Presenter.Interfaces
{
    public interface IMainPresenter
    {
        void LoadSettings();
        bool AddScript(ScriptAbs script);
        bool EditScript(ScriptAbs script);
        bool RemoveScript(int scriptId);
        ScriptStatus ChangeScriptStatus(ScriptAbs script);
    }
}
