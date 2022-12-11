using Border.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Border
{
    public class Rebel : IPerson, IBuyer
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public int Food { get; private set; }

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public int BuyFood()
        {
            Food += 5;

            return 5;
        }
    }
}
