using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Military_Elite.Contracts;

namespace Military_Elite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public HashSet<Repair> Repairs { get; private set; }

        public Engineer(HashSet<Repair> repairs, string corps, string firstName, string lastName, string id, decimal salary) : base(corps, firstName, lastName, id, salary)
        {
            Repairs = repairs;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Repairs");
            sb.AppendLine(string.Join(Environment.NewLine, Repairs.Select(repair => $"  {repair}")));
            return sb.ToString().Trim();
        }
    }
}
