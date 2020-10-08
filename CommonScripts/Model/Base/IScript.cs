using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonScripts.Model.Base
{
    interface IScript
    {
        int Id { get; set; }
        string ScriptName { get; set; }
        ScriptStatus ScriptStatus { get; set; }
        string ScriptPath { get; set; }
    }
}
