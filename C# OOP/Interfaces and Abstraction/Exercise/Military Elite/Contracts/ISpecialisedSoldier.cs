using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public string Corps { get; }
    }
}
