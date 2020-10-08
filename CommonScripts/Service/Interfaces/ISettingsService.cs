using CommonScripts.Model.Base;
using System.Collections.Generic;

namespace CommonScripts.Service.Interfaces
{
    public interface ISettingsService
    {
        bool SaveScripts(List<ScriptAbs> scripts);
        List<ScriptAbs> GetScripts();
    }
}
