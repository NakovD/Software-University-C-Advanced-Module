using System;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public interface IAddCollection<T>
    {
        public List<T> Collection { get; }

        int Add(T item);
    }
}
