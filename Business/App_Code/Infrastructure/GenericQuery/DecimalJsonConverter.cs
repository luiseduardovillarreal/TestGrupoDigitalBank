using Newtonsoft.Json;
using System;

/// <summary>
/// Descripción breve de DecimalJsonConverter
/// </summary>
internal class DecimalJsonConverter : JsonConverter<decimal>
{
    public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue,
        bool hasExistingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, decimal value, JsonSerializer serializer)
    {
        new NotImplementedException();
    }
}