﻿using System;
using System.Windows.Forms;

namespace CommonScripts.Model.Pojo
{
    public class KeyPressed : IEquatable<KeyPressed>
    {
        private const string PLUS_TO_STRING = " + ";
        private const string CONTROL_KEY = "CTRL";
        private const string SHIFT_KEY = "SHIFT";
        private const string ALT_KEY = "ALT";
        private Keys? _key;

        public bool IsShiftPressed { get; set; }
        public bool IsControlPressed { get; set; }
        public bool IsAltPressed { get; set; }
        public Keys? Key {
            get { return _key; }
            set {
                if (value == null)
                    _key = null;
                else
                {
                    Keys aux = value ?? default;
                    if (IsOnlyShiftPressed(aux) || IsOnlyControlPressed(aux) || IsOnlyAltPressed(aux))
                        _key = null;
                    else
                        _key = value;
                }
            }
        }
        public KeyPressed() : this(null)
        {
        }
        public KeyPressed(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs != null)
            {
                IsShiftPressed = keyEventArgs.Shift;
                IsControlPressed = keyEventArgs.Control;
                IsAltPressed = keyEventArgs.Alt;
                Key = keyEventArgs.KeyCode;
            }
        }
        private bool IsOnlyShiftPressed(Keys key)
        {
            return key == Keys.LShiftKey || key == Keys.RShiftKey;
        }
        private bool IsOnlyControlPressed(Keys key)
        {
            return key == Keys.LControlKey || key == Keys.RControlKey;
        }
        private bool IsOnlyAltPressed(Keys key)
        {
            return key == Keys.LMenu || key == Keys.RMenu;
        }
        public override string ToString()
        {
            string aux = "";

            if (IsShiftPressed)
                aux += SHIFT_KEY;

            if (IsControlPressed)
                aux += GetPlusSignIfRequired(aux) + CONTROL_KEY;

            if (IsAltPressed)
                aux += GetPlusSignIfRequired(aux) + ALT_KEY;

            if (Key != null)
                aux += GetPlusSignIfRequired(aux) + Key;

            return aux;
        }
        private string GetPlusSignIfRequired(string currentRepresentation)
        {
            return (currentRepresentation == "" ? "" : PLUS_TO_STRING); 
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as KeyPressed);
        }
        public bool Equals(KeyPressed other)
        {
            if (other == null)
                return false;

            return this.IsShiftPressed == other.IsShiftPressed
                && this.IsControlPressed == other.IsControlPressed
                && this.IsAltPressed == other.IsAltPressed
                && (
                    (this.Key == null && other.Key == null)
                    || (this.Key == other.Key)
                );
        }
    }
}
