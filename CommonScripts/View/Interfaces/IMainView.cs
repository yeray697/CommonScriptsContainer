using CommonScripts.Model.Pojo.Base;
using System.Collections.Generic;

namespace CommonScripts.View.Interfaces
{
    public interface IMainView
    {
        Presenter.MainPresenter Presenter { get; set; }
        void ShowScripts(IList<ScriptAbs> scripts);
        void ChangeScriptStatusThreadSafe(ScriptAbs script);
    }
}
