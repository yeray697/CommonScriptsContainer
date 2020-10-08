using System.Collections.Generic;

namespace CommonScripts.View.Interfaces
{
    public interface IMainView
    {
        Presenter.MainPresenter Presenter { get; set; }
        void ShowScripts(IList<Model.Base.ScriptAbs> scripts);
    }
}
