using System;
using System.Collections.Generic;
using System.Text;
using Military.Contracts;

namespace Military
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public string Corps { get; private set; }

        public SpecialisedSoldier(string corps, string firstName, string lastName, string id, decimal salary) : base(firstName, lastName, id, salary)
        {
            Corps = corps;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            return sb.ToString().Trim();
        }
    }
}
