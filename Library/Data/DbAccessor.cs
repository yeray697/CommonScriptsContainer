using Common;
using LiteDB;

namespace Data
{
    public class DbAccessor : IDisposable
    {
        private const string DB_NAME = "CommonScripts.db";

        private LiteDatabase? db;
        private int _activeConnections = 0;

        private static DbAccessor? _instance;
        private readonly static object _instanceLockObj = new();
        private readonly static object _accessorLockObj = new();

        public static DbAccessor GetInstance()
        {
            if (_instance != null)
                return _instance;
            lock (_instanceLockObj)
            {
                if (_instance != null)
                    return _instance;
                _instance = new DbAccessor();
            }
            return _instance;
        }

        public void RunAction(Action<LiteDatabase> action)
        {
            try
            {
                InitDatabase();
                action(db!);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DecrementConnections();
            }
        }

        private void InitDatabase()
        {
            Interlocked.Increment(ref _activeConnections);
            if (db != null)
                return;
            lock (_accessorLockObj)
            {
                if (db != null)
                    return;
                db = new LiteDatabase(Path.Combine(FileUtils.GetConfigDirectory(), DB_NAME));
            }
        }

        private void DecrementConnections()
        {
            Interlocked.Decrement(ref _activeConnections);
            if (_activeConnections == 0)
            {
                db?.Dispose();
                db = null;
            }
        }

        public void Dispose()
        {
            db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
