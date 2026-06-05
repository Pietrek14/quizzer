using QuizModel.Containers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuizModel.Observed.Serialization
{
    public class ObservedArrayConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType) return false;

            return typeToConvert.GetGenericTypeDefinition() == typeof(ObservedArray<>);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type itemType = typeToConvert.GetGenericArguments()[0];

            Type converterType = typeof(ObservedArrayConverter<>).MakeGenericType(itemType);

            return (JsonConverter)Activator.CreateInstance(converterType);
        }
    }
}
