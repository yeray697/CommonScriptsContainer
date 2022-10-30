namespace Contracts.Key
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
        public Keys? Key
        {
            get { return _key; }
            set
            {
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
        public KeyPressed(KeyEventArgs? keyEventArgs)
        {
            if (keyEventArgs != null)
            {
                IsShiftPressed = keyEventArgs.Shift;
                IsControlPressed = keyEventArgs.Control;
                IsAltPressed = keyEventArgs.Alt;
                Key = keyEventArgs.KeyCode;
            }
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
        private static string GetPlusSignIfRequired(string currentRepresentation)
            => currentRepresentation == "" ? "" : PLUS_TO_STRING;
        public override bool Equals(object? obj)
            => Equals(obj as KeyPressed);
        public bool Equals(KeyPressed? other)
        {
            if (other == null)
                return false;

            return IsShiftPressed == other.IsShiftPressed
                && IsControlPressed == other.IsControlPressed
                && IsAltPressed == other.IsAltPressed
                && (
                    (Key == null && other.Key == null)
                    || Key == other.Key
                );
        }
        public override int GetHashCode()
            => unchecked(Key.GetHashCode() ^ IsAltPressed.GetHashCode() ^ IsShiftPressed.GetHashCode() ^ IsControlPressed.GetHashCode());
        private static bool IsOnlyShiftPressed(Keys key)
            => key == Keys.LShiftKey || key == Keys.RShiftKey;
        private static bool IsOnlyControlPressed(Keys key)
            => key == Keys.LControlKey || key == Keys.RControlKey;
        private static bool IsOnlyAltPressed(Keys key)
            => key == Keys.LMenu || key == Keys.RMenu;
    }
}
