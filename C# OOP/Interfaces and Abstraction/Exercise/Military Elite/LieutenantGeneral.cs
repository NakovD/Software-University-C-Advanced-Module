using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Military_Elite.Contracts;

namespace Military_Elite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public HashSet<Private> Privates { get; private set; }

        public LieutenantGeneral(HashSet<Private> privates, string firstName, string lastName, string id, decimal salary) : base(firstName, lastName, id, salary)
        {
            Privates = privates;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates");
            sb.Append(string.Join(Environment.NewLine, Privates.Select(_private => $"  {_private}")));
            return sb.ToString().Trim();

        }
    }
}
