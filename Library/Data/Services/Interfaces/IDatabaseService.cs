using Contracts.Scripts.Base;
using LiteDB;

namespace Data.Services.Interfaces
{
    public interface IDatabaseService : IDisposable
    {
        ILiteCollection<ScriptAbs> ScriptsDbSet { get; set; }
    }
}
