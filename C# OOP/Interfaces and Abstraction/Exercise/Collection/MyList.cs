using System;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    internal class MyList<T> : IMyList<T>
    {
        public int Used { get => Collection.Count; }

        public List<T> Collection { get; private set; }

        public MyList()
        {
            Collection = new List<T>();
        }

        public MyList(List<T> collection)
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
            var element = Collection[0];
            Collection.RemoveAt(0);
            return element;
        }
    }
}
