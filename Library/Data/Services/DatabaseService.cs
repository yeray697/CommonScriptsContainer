using Common;
using Contracts.Scripts.Base;
using Data.Services.Interfaces;
using LiteDB;

namespace Data.Services
{
    public class DatabaseService : IDatabaseService
    {
        private const string DB_NAME = "CommonScripts.db";

        public ILiteCollection<ScriptAbs> ScriptsDbSet { get; set; }

        private readonly ILiteDatabase _db;

        public DatabaseService(ILiteDatabase db) 
        {
            _db = db;
            ScriptsDbSet = _db.GetCollection<ScriptAbs>("scripts");
        }

        public void Dispose()
        {
            _db?.Dispose();
            GC.SuppressFinalize(this);
        }

        public static string GetDatabasePath()
        {
            string path = FileUtils.GetConfigDirectory();
            return Path.Combine(path, DB_NAME);
        }
    }
}
