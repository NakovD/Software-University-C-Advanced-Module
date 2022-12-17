using DefiningClasses;
using System;

namespace _3._Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfPplToAdd = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < numberOfPplToAdd; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var personName = input[0];
                var personAge = int.Parse(input[1]);
                var newPerson = new Person(personName, personAge);
                family.AddMember(newPerson);
            }

            var oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
