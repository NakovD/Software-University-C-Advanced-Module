using Military.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military
{
    public class Spy : Soldier, ISpy
    {
        public int CodeNumber { get; private set; }

        public Spy(int code, string firstName, string lastName, string id) : base(firstName, lastName, id)
        {
            CodeNumber = code;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id}");
            sb.AppendLine($"Code Number: {CodeNumber}");
            return sb.ToString().Trim();
        }
    }
}
