using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Equality_Logic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sortedSet = new SortedSet<Person>();
            var set = new HashSet<Person>(new PersonComparator());
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var personLineData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var personName = personLineData[0];
                var personAge = int.Parse(personLineData[1]);
                var newPerson = new Person(personName, personAge);
                sortedSet.Add(newPerson);
                set.Add(newPerson);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(set.Count);

            Console.WriteLine(string.Join(Environment.NewLine, sortedSet));

            Console.WriteLine();

            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }

    public class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo([AllowNull] Person other)
        {
            if (Name == other.Name && Age == other.Age) return 0;

            if (Age > other.Age) return 1;

            return -1;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Age}";
        }
    }

    public class PersonComparator : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Name == y.Name && x.Age == y.Age;
        }

        public int GetHashCode(Person person)
        {
            return person.Name.GetHashCode() + person.Age.GetHashCode();
        }
    }
}
