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

        private readonly JsonSerializerOptions _converterOptions = new() { Converters = { new JsonStringEnumConverter() } };

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
            ScriptAbs baseClass = typeDiscriminator switch
            {
                TypeDiscriminator.Scheduled => GetScript<ScriptScheduled>(ref reader),
                TypeDiscriminator.ListenKey => GetScript<ScriptListenKey>(ref reader),
                TypeDiscriminator.OneOff => GetScript<ScriptOneOff>(ref reader),
                _ => throw new NotSupportedException(),
            };
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
                JsonSerializer.Serialize(writer, derivedA, _converterOptions);
            }
            else if (value is ScriptListenKey derivedB)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.ListenKey);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, derivedB, _converterOptions);
            }
            else if (value is ScriptScheduled derivedC)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Scheduled);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, derivedC, _converterOptions);
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

        private T GetScript<T>(ref Utf8JsonReader reader)
        {
            if (!reader.Read() || reader.GetString() != "TypeValue")
            {
                throw new JsonException();
            }
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            return (T)JsonSerializer.Deserialize(ref reader, typeof(T), _converterOptions)!;
        }
    }
}
