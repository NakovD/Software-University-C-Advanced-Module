using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface IRepair
    {
        public string Name { get; }

        public int HoursWorked { get; }
    }
}
