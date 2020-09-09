using CommonScripts.Model;

namespace CommonScripts.Presenter.Interfaces
{
    public interface IMainPresenter
    {
        void LoadSettings();
        bool AddScript(Script script);
        bool EditScript(Script script);
        bool RemoveScript(int scriptId);
        Script.Status ChangeScriptStatus(Script script);
    }
}
