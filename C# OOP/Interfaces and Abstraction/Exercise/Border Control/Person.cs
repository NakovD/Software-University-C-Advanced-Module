using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Person : ICitizen
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public long Id { get; set; }

        public Person(string name, int age, long id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
    }
}
