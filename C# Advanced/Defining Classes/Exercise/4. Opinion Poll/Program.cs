using System;
using System.Collections.Generic;
using System.Linq;

namespace opinionPoll
{
    class Program
    {
        static void Main()
        {
            var countToRead = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < countToRead; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var personName = input[0];
                var personAge = int.Parse(input[1]);
                var newPerson = new Person(personName, personAge);
                people.Add(newPerson);
            }

            var filteredPeople = people
                .Where(person => person.Age > 30)
                .OrderBy(person => person.Name)
                .Select(person => $"{person.Name} - {person.Age}");

            Console.WriteLine(string.Join(Environment.NewLine, filteredPeople));
        }
    }

}