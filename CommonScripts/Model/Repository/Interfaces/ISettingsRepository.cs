using CommonScripts.Model.Pojo.Base;
using System.Collections.Generic;

namespace CommonScripts.Model.Repository.Interfaces
{
    public interface ISettingsRepository
    {
        bool SaveScripts(List<ScriptAbs> scripts);
        List<ScriptAbs> GetScripts();
    }
}
