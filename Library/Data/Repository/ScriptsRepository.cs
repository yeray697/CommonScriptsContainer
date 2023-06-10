using Contracts.Scripts.Base;
using Data.Repository.Interfaces;
using Data.Services.Interfaces;
using LiteDB;

namespace Data.Repository
{
    public class ScriptsRepository : IScriptsRepository
    {
        private readonly ILiteCollection<ScriptAbs> _dbSet;

        public ScriptsRepository(IDatabaseService databaseService) 
        {
            _dbSet = databaseService.ScriptsDbSet;
        }

        public void DeleteScript(string scriptId)
            => _dbSet.Delete(new BsonValue(scriptId));

        public List<ScriptAbs> GetScripts()
            => _dbSet.FindAll().ToList();

        public void UpdateScript(ScriptAbs script)
            => _dbSet.Update(script);

        public void AddScript(ScriptAbs script)
            => _dbSet.Insert(script);
    }
}
