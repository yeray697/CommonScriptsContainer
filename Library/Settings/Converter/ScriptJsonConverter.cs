using Contracts.Scripts;
using Contracts.Scripts.Base;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Data.Converter
{
    public class ScriptJsonConverter : JsonConverter<ScriptAbs>
    {
        private enum TypeDiscriminator
        {
            BaseClass = 0,
            Scheduled = 1,
            OneOff = 2,
            ListenKey = 3
        }

        public override bool CanConvert(Type type)
        {
            return typeof(ScriptAbs).IsAssignableFrom(type);
        }

        public override ScriptAbs? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            TypeDiscriminator typeDiscriminator = GetTypeDiscriminator(ref reader);
            ScriptAbs baseClass;
            switch (typeDiscriminator)
            {
                case TypeDiscriminator.Scheduled:
                    baseClass = GetScript<ScriptScheduled>(ref reader);
                    break;
                case TypeDiscriminator.ListenKey:
                    baseClass = GetScript<ScriptListenKey>(ref reader);
                    break;
                case TypeDiscriminator.OneOff:
                    baseClass = GetScript<ScriptOneOff>(ref reader);
                    break;
                default:
                    throw new NotSupportedException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }

            return baseClass;
        }

        public override void Write(Utf8JsonWriter writer, ScriptAbs value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (value is ScriptOneOff derivedA)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.OneOff);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, derivedA);
            }
            else if (value is ScriptListenKey derivedB)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.ListenKey);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, derivedB);
            }
            else if (value is ScriptScheduled derivedC)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Scheduled);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, derivedC);
            }
            else
            {
                throw new NotSupportedException();
            }

            writer.WriteEndObject();
        }

        private static TypeDiscriminator GetTypeDiscriminator(ref Utf8JsonReader reader)
        {
            if (!reader.Read()
                    || reader.TokenType != JsonTokenType.PropertyName
                    || reader.GetString() != "TypeDiscriminator")
            {
                throw new JsonException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }

            return (TypeDiscriminator)reader.GetInt32();
        }

        private static T GetScript<T>(ref Utf8JsonReader reader)
        {
            if (!reader.Read() || reader.GetString() != "TypeValue")
            {
                throw new JsonException();
            }
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            return (T)JsonSerializer.Deserialize(ref reader, typeof(T))!;
        }
    }
}
