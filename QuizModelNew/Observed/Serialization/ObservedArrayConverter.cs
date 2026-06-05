using QuizModel.Containers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuizModel.Observed.Serialization
{
    internal class ObservedArrayConverter<T> : JsonConverter<ObservedArray<T>>
    {
        public override ObservedArray<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var items = JsonSerializer.Deserialize<T[]>(ref reader, options);
            return items != null ? new ObservedArray<T>(items) : null;
        }
        public override void Write(Utf8JsonWriter writer, ObservedArray<T> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Items, options);
        }
    }
}
