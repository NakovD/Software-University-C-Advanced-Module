using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public HashSet<Repair> Repairs { get; }
    }
}
