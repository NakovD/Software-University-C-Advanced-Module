using System;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public class AddCollection<T> : IAddCollection<T>
    {
        public List<T> Collection { get; private set; }

        public AddCollection()
        {
            Collection = new List<T>();
        }

        public AddCollection(List<T> collection)
        {
            Collection = collection;    
        }

        public int Add(T item)
        {
            var index = Collection.Count;
            Collection.Add(item);

            return index;
        }
    }
}
