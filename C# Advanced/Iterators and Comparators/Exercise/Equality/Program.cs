using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sortedSet = new SortedSet<Person>();
            var set = new HashSet<Person>();
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
        }
    }

    public class Person : IComparable<Person>, IEquatable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(Person other)
        {
            if (Name.CompareTo(other.Name) != 0)
            {
                return Name.CompareTo(other.Name);
            }

            return Age.CompareTo(other.Age);
        }

        public bool Equals(Person other)
        {
            return Name == other.Name && Age == other.Age;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
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
