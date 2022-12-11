using System;
using System.Collections.Generic;
using System.Text;
using Border.Contracts;

namespace Border
{
    public class Person : IPerson, ICitizen, IBirthable, IBuyer
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthday { get; private set; }

        public int Food { get; private set; }

        public Person(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public int BuyFood()
        {
            Food += 10;

            return 10;
        }
    }
}
