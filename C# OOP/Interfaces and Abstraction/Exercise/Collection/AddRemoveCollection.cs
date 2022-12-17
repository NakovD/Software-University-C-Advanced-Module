using System;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public class AddRemoveCollection<T> : ICollection<T>
    {
        public List<T> Collection { get; private set; }

        public AddRemoveCollection()
        {
            Collection = new List<T>();
        }

        public AddRemoveCollection(List<T> collection)
        {
            Collection = collection;
        }

        public int Add(T item)
        {
            Collection.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            var element = Collection[Collection.Count - 1];
            Collection.RemoveAt(Collection.Count - 1);
            return element;
        }
    }
}
