using System;
using System.Collections.Generic;
using System.Text;

namespace Collection
{
    public interface ICollection<T> : IAddCollection<T>
    {
        T Remove();
    }
}
