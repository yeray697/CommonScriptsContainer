using CommonScripts.Utils;

namespace CommonScripts.Extension
{
    public static class EnumExtensions
    {
        public static string NameToString<T>(this T value)
            where T : struct
        {
            return EnumUtils.GetEnumValueAsString<T>(value);
        }
    }
}
