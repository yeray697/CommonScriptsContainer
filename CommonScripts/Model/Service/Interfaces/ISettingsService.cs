using CommonScripts.Model.Pojo;
using CommonScripts.Model.Pojo.Base;
using System.Collections.Generic;

namespace CommonScripts.Model.Service.Interfaces
{
    public interface ISettingsService
    {
        bool SaveScripts(List<ScriptAbs> scripts);
        List<ScriptAbs> GetScripts();
        bool SaveSettings(Settings settings);
        Settings GetSettings();
    }
}
