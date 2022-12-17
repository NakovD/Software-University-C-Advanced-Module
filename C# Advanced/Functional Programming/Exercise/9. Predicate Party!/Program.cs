using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialPeople = Console.ReadLine().Split(" ").ToList();
            var input = Console.ReadLine();

            while (!input.ToLower().Contains("party!"))
            {
                var inputData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = inputData[0].ToString();
                var criteria = inputData[1];
                var criteriaValue = inputData[2];
                var criteriaPredicate = GetCriteriaPredicate(criteria.ToLower(), criteriaValue);
                input = Console.ReadLine();
                if (command == "Remove")
                {
                    initialPeople.RemoveAll(criteriaPredicate);
                    continue;
                }
                var newPeople = new Stack<string>(initialPeople.FindAll(criteriaPredicate));
                DoublePerson(criteriaPredicate, newPeople, initialPeople);
            }

            if (initialPeople.Count == 0) Console.WriteLine("Nobody is going to the party!");
            else Console.WriteLine(string.Join(", ", initialPeople) + " are going to the party!");
        }

        static Predicate<string> GetCriteriaPredicate(string criteria, string criteriaValue)
        {
            if (criteria.Contains("startswith")) return name => name.StartsWith(criteriaValue);
            if (criteria.Contains("endswith")) return name => name.EndsWith(criteriaValue);
            return name => name.Length == int.Parse(criteriaValue);
        }

        static void DoublePerson(Predicate<string> criteria, Stack<string> newPeople, List<string> initialPeople)
        {
            if (newPeople.Count == 0) return;
            var currentPerson = newPeople.Pop();
            var neededIndex = initialPeople.FindIndex(p => p == currentPerson);
            initialPeople.Insert(neededIndex, currentPerson);
            DoublePerson(criteria, newPeople, initialPeople);
        }
    }
}
