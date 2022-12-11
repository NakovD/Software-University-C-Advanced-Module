using System;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public interface IMyList<T> : ICollection<T>
    {
        public int Used { get; }
    }
}
