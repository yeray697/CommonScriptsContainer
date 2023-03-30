using Contracts.Key;
using Gma.System.MouseKeyHook;
using Serilog;

namespace DesktopClient.Service
{
    public class ListenKeysService
    {
        public delegate void KeyUpHandler(KeyPressed keyPressed);
        public event KeyUpHandler? SingleKeyUpClicked;
        public event KeyUpHandler? KeyUpClicked;

        private static ListenKeysService? _instance;
        private IKeyboardMouseEvents? _globalHook;
        private bool _running;
        private bool _singleKeyListen;

        private ListenKeysService()
        {
            _running = false;
        }
        public static ListenKeysService GetInstance()
        {
            _instance ??= new ListenKeysService();

            return _instance;
        }
        public void Run(bool singleKeyListen)
        {
            _singleKeyListen = singleKeyListen;
            Run();
        }
        public void Run()
        {
            if (!_running)
            {
                Log.Information("Running ListenKeyService...");
                _running = true;
                Subscribe();
            }
        }
        public void Stop()
        {
            if (_running)
            {
                Log.Information("Stopping ListenKeyService...");
                _running = false;
                Unsubscribe();
            }
        }
        private void Subscribe()
        {
            if (_globalHook == null)
            {
                _globalHook = Hook.GlobalEvents();
                _globalHook.KeyUp += GlobalHookKeyUp;
            }
        }
        private void GlobalHookKeyUp(object? sender, System.Windows.Forms.KeyEventArgs e)
        {
            int key = (int)e.KeyData;
            Contracts.Key.Keys keys = (Contracts.Key.Keys)key;
            var keyPressed = new KeyPressed(new Contracts.Key.KeyEventArgs(keys));
            Log.Debug("Key Up: {@KeyPressed}", keyPressed.ToString());

            if (_singleKeyListen)
            {
                Log.Debug("Emitting SingleKeyUpClicked...");
                SingleKeyUpClicked?.Invoke(keyPressed);
                _singleKeyListen = false;
            }
            else
            {
                Log.Debug("Emitting KeyUpClicked...");
                KeyUpClicked?.Invoke(keyPressed);
            }
        }
        private void Unsubscribe()
        {
            if (_globalHook != null)
            {
                _globalHook.KeyUp -= GlobalHookKeyUp;
                _globalHook.Dispose();
                _globalHook = null;
            }
        }
    }
}
