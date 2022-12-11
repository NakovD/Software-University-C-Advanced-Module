using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        public HashSet<Private> Privates { get; }
    }
}
