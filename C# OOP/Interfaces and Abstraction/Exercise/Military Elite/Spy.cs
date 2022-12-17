using Military_Elite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Spy : ISpy
    {
        public int CodeNumber { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Id { get; private set; }

        public Spy(int code, string firstName, string lastName, string id)
        {
            CodeNumber = code;
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Code Number: {CodeNumber}");

            return sb.ToString().Trim();
        }
    }
}
