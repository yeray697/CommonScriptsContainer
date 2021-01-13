using CommonScripts.Model.Pojo;
using Gma.System.MouseKeyHook;
using Serilog;
using System;
using System.Windows.Forms;

namespace CommonScripts.Model.Service
{
    public class ListenKeysService
    {
        public delegate void KeyUpHandler(KeyPressed keyPressed);
        public event KeyUpHandler SingleKeyUpClicked;
        public event KeyUpHandler KeyUpClicked;

        private static ListenKeysService _instance;
        private IKeyboardMouseEvents _globalHook;
        private bool _running;
        private bool _singleKeyListen;

        private ListenKeysService()
        {
            _running = false;
        }
        public static ListenKeysService GetInstance()
        {
            if (_instance == null)
                _instance = new ListenKeysService();

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
        private void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            KeyPressed keyPressed = new KeyPressed(e);
            Log.Debug("Key Up: {@KeyPressed}", keyPressed.ToString());

            if (_singleKeyListen)
            {
                Log.Debug("Emitting SingleKeyUpClicked...");
                SingleKeyUpClicked?.Invoke(keyPressed);
                _singleKeyListen = false;
            } else
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
