using CommonScripts.Model.Pojo.Base;
using System.Threading.Tasks;

namespace CommonScripts.Presenter.Interfaces
{
    public interface IMainPresenter
    {
        void LoadSettings();
        bool AddScript(ScriptAbs script);
        bool EditScript(ScriptAbs script, bool hasScriptTypeChanged);
        bool RemoveScript(string scriptId);
        Task<bool> ChangeScriptStatus(ScriptAbs script);
        void DoNotAskAgainRunAtStartup();
        bool SetAppRunAtStartup();
    }
}
