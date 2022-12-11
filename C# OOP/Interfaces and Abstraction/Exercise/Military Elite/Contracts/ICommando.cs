using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public HashSet<Mission> Missions { get; }
    }
}
