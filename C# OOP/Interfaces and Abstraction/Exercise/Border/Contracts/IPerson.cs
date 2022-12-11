using System;
using System.Collections.Generic;
using System.Text;

namespace Border.Contracts
{
    public interface IPerson : ICreature
    {
        public int Age { get; }
    }
}
