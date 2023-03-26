namespace DesktopClient.Models
{
    public class Argument<T>
    {
        public T? Value { get; set; }
        public string ArgumentName { get; private set; }

        public Argument(string argumentName)
        {
            ArgumentName = argumentName;
            Value = default;
        }
    }
}
