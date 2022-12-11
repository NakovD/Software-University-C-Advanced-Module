using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Contracts
{
    public interface IPrivate : ISoldier
    {

        public decimal Salary { get; }
    }
}
