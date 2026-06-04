using System;
using System.Collections.Generic;
using System.Text;

namespace QuizModel.Containers
{
    public class Repository<T> where T : IGuided
    {
        public event Action<T>? ItemAdded;
        public event Action<T>? ItemUpdated;
        public event Action<T>? ItemRemoved;

        public Dictionary<Guid, T> Items { get; } = new Dictionary<Guid, T>();

        public void AddItem(T item)
        {
            Items.Add(item.Id, item);
            ItemAdded?.Invoke(item);
        }

        public void UpdateItem(T item)
        {
            if (Items.ContainsKey(item.Id))
            {
                Items[item.Id] = item;
                this.ItemUpdated?.Invoke(item);
            }
            else
            {
                throw new InvalidOperationException($"Can't update item with ID {item.Id} because it doesn't exist.");
            }
        }

        public void RemoveItem(Guid id)
        {
            if (Items.TryGetValue(id, out T item))
            {
                Items.Remove(id);
                ItemRemoved?.Invoke(item);
            }
        }
    }
}
