using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CustomComparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var allPeople = new List<Person>();
            var line = Console.ReadLine();

            while (!line.ToLower().Contains("end"))
            {
                var currentPersonData = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var newPerson = new Person(currentPersonData[0], int.Parse(currentPersonData[1]), currentPersonData[2]);
                allPeople.Add(newPerson);
                line = Console.ReadLine();
            }

            var allPeopleCount = allPeople.Count;

            var index = int.Parse(Console.ReadLine()) - 1;

            var neededPerson = allPeople[index];

            var matches = allPeople.Where(p => p.CompareTo(neededPerson) == 0);

            var differences = allPeople.Where(p => p.CompareTo(neededPerson) != 0);

            if (matches.Count() > 1) { Console.WriteLine($"{matches.Count()} {differences.Count()} {allPeopleCount}"); }
            else Console.WriteLine("No matches");

        }
    }


    public class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public int CompareTo(Person other)
        {
            var nameComparation = this.Name.CompareTo(other.Name);

            if (nameComparation == 0)
            {
                var ageComparation = this.Age.CompareTo(other.Age);

                if (ageComparation == 0)
                {
                    return this.Town.CompareTo(other.Town);
                }
                return ageComparation;
            }

            return nameComparation;
        }
    }
}
