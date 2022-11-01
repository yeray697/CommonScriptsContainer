namespace Common
{
    public static class EnumUtils
    {
        public static T Parse<T>(object value) where T : struct, IConvertible
        {
            return ParseOrDefault(value, default(T));
        }
        public static T ParseOrDefault<T>(object value, T defaultValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            return Enum.TryParse(value?.ToString(), out T enumType) ? enumType : defaultValue;
        }
        public static string GetEnumValueAsString<T>(T enumerationValue)
            where T : struct
        {
            Type tType = typeof(T);
            if (!tType.IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            return Enum.GetName(tType, enumerationValue) ?? throw new ArgumentOutOfRangeException(nameof(enumerationValue));
        }
    }
}
