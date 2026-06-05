using QuizModel.Containers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuizModel.Observed.Serialization
{
    internal class RepositoryConverter<T> : JsonConverter<Repository<T>> where T : IGuided
    {
        public override Repository<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var items = JsonSerializer.Deserialize<List<T>>(ref reader, options);
            return items != null ? new Repository<T>(items) : null;
        }

        public override void Write(Utf8JsonWriter writer, Repository<T> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Items.Values, options);
        }
    }
}
