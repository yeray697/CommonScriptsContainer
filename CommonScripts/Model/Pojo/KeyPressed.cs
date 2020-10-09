using System.Windows.Forms;

namespace CommonScripts.Model.Pojo
{
    public class KeyPressed
    {
        private const string PlusToString = " + ";
        private Keys? _key;

        public bool IsShiftPressed { get; private set; }
        public bool IsControlPressed { get; private set; }
        public bool IsAltPressed { get; private set; }
        public Keys? Key {
            get { return _key; }
            private set {
                if (value == null)
                    _key = null;
                else
                {
                    Keys aux = value ?? default(Keys);
                    if (IsOnlyShiftPressed(aux) || IsOnlyControlPressed(aux) || IsOnlyAltPressed(aux))
                        _key = null;
                    else
                        _key = value;
                }
            }
        }

        public KeyPressed(KeyEventArgs keyEventArgs)
        {
            IsShiftPressed = keyEventArgs.Shift;
            IsControlPressed = keyEventArgs.Control;
            IsAltPressed = keyEventArgs.Alt;
            Key = keyEventArgs.KeyCode;
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
                aux += "SHIFT";

            if (IsControlPressed)
                aux += GetPlusSignIfRequired(aux) + "CTRL";

            if (IsAltPressed)
                aux += GetPlusSignIfRequired(aux) + "ALT";

            if (Key != null)
                aux += GetPlusSignIfRequired(aux) + Key;

            return aux;
        }

        private string GetPlusSignIfRequired(string currentRepresentation)
        {
            return (currentRepresentation == "" ? "" : PlusToString); 
        }
    }
}
