namespace DI_Implementation.Models.Person
{
    using Contracts;
    using System;

    public class Person : IPerson
    {
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be null, empty or only whitespace");
                name = value;
            }
        }

        private int age;

        public int Age
        {
            get => age;

            private set
            {
                if (value <= 0) throw new ArgumentException("Age cannot be 0 or negative");
                age= value;
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
