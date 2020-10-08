﻿using CommonScripts.Model;
using CommonScripts.Service.Interfaces;
using Gma.System.MouseKeyHook;
using System;
using System.Windows.Forms;

namespace CommonScripts.Service
{
    public class ListenKeysService : IService
    {
        public delegate void KeyUpHandler(KeyPressed keyPressed);

        public event KeyUpHandler SingleKeyUpClicked;
        public event KeyUpHandler KeyUpClicked;

        private static ListenKeysService _instance;
        private IKeyboardMouseEvents _globalHook;
        private bool _running;
        private bool SingleKeyListen { get; set; }

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
            SingleKeyListen = singleKeyListen;
            Run();
        }

        public void Run()
        {
            if (!_running)
            {
                _running = true;
                Subscribe();
            }
        }

        public void Stop()
        {
            if (_running)
            {
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
            Console.WriteLine(keyPressed);

            if (SingleKeyListen)
            {
                SingleKeyUpClicked?.Invoke(keyPressed);
                SingleKeyListen = false;
            } else
            {
                KeyUpClicked?.Invoke(keyPressed);
            }
        }

        private void Unsubscribe()
        {
            if (_globalHook != null)
            {
                _globalHook.KeyUp -= GlobalHookKeyUp;
                _globalHook.Dispose();
            }
        }
    }
}