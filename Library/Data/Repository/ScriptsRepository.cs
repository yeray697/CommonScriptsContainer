using Contracts.Scripts.Base;
using Data.Repository.Interfaces;
using LiteDB;

namespace Data.Repository
{
    public class ScriptsRepository : IScriptsRepository
    {
        public void DeleteScript(string scriptId)
        {
            RunAction(scriptsCollection =>
            {
                scriptsCollection.Delete(new BsonValue(scriptId));
            });
        }

        public List<ScriptAbs> GetScripts()
        {
            List<ScriptAbs> scripts = new();

            RunAction(scriptsCollection =>
            {
                scripts = scriptsCollection.FindAll().ToList();
            });

            return scripts;
        }

        public void UpdateScript(ScriptAbs script)
        {
            RunAction(scriptsCollection =>
            {
                scriptsCollection.Update(script);
            });
        }

        public void AddScript(ScriptAbs script)
        {
            RunAction(scriptsCollection =>
            {
                scriptsCollection.Insert(script);
            });
        }

        private static void RunAction(Action<ILiteCollection<ScriptAbs>> action)
            => DbAccessor.GetInstance().RunAction(db => action(db.GetCollection<ScriptAbs>("scripts")));
    }
}
