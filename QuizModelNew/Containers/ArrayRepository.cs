using QuizModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizModel.Containers
{
    public class ArrayRepository<T>
    {
        public event Action<int, T>? ItemUpdated;

        public T[] Items { get; }

        public ArrayRepository(int size)
        {
            Items = new T[size];
        }

        public ArrayRepository(IEnumerable<T> items)
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
