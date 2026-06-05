using QuizModel;
using QuizModel.Observed.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace QuizModel.Containers
{
    [JsonConverter(typeof(ObservedArrayConverterFactory))]
    public class ObservedArray<T>
    {
        public event Action<int, T>? ItemUpdated;

        public T[] Items { get; }

        public ObservedArray(int size)
        {
            Items = new T[size];
        }

        public ObservedArray(IEnumerable<T> items)
        {
            Items = items.ToArray();
        }

        public void Set(int index, T item)
        {
            Items[index] = item;
            ItemUpdated?.Invoke(index, item);
        }
    }
}
