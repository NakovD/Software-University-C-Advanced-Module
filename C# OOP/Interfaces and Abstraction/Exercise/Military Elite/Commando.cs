using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Military_Elite.Contracts;

namespace Military_Elite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public HashSet<Mission> Missions { get; private set; }

        public Commando(HashSet<Mission> missions, string corps, string firstName, string lastName, string id, decimal salary) : base(corps, firstName, lastName, id, salary)
        {
            Missions = missions;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append(string.Join(Environment.NewLine, Missions.Select(mission => $"  {mission}")));
            return sb.ToString().Trim();
        }
    }
}
