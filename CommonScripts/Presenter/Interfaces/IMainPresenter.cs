using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using System.Threading.Tasks;

namespace CommonScripts.Presenter.Interfaces
{
    public interface IMainPresenter
    {
        void LoadSettings();
        bool AddScript(ScriptAbs script);
        bool EditScript(ScriptAbs script);
        bool RemoveScript(string scriptId);
        Task<bool> ChangeScriptStatus(ScriptAbs script);
    }
}
