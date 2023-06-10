namespace Common
{
    public static class EnumUtils
    {
        public static T ParseOrDefault<T>(object value, T defaultValue = default) where T : struct, Enum
            => Enum.TryParse(value?.ToString(), out T enumType) ? enumType : defaultValue;
    }
}
