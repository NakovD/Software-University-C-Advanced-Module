using Border.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Border
{
    public class Pet : ICreature, IBirthable
    {
        public string Name { get; private set; }

        public string Birthday { get; private set; }

        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }
    }
}
