using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var filtersStrings = new List<string>();

            ReadConsoleInput(filtersStrings);

            var criterias = filtersStrings.Select(filterString => {
                var filterData = filterString.Split(";");
                var filterType = filterData[0].ToLower();
                var filterParam = filterData[1];
                return GetFilterPredicate(filterType, filterParam);
            });

            var criteriasAsQueue = new Queue<Predicate<string>>(criterias);

            FilterPeople(criteriasAsQueue, people);

            Console.WriteLine(string.Join(" ", people));
        }

        static void ReadConsoleInput(List<string> filters)
        {
            var currentInput = Console.ReadLine().ToLower();
            var commandsOnly = string.Join(";", currentInput.Split(";").Skip(1));

            if (currentInput.Contains("print")) return;
            if (currentInput.Contains("add")) filters.Add(commandsOnly);
            else filters.Remove(commandsOnly);
            ReadConsoleInput(filters);
        }

        static Predicate<string> GetFilterPredicate (string filterType, string filterParam)
        {
            if (filterType.Contains("starts with")) return str => str.StartsWith(filterParam);
            if (filterType.Contains("ends with")) return str => str.EndsWith(filterParam);
            if (filterType.Contains("contains")) return str => str.Contains(filterParam);
            return str => str.Length == int.Parse(filterParam);
        }

        static void FilterPeople(Queue<Predicate<string>> criterias, List<string> people)
        {
            if (criterias.Count == 0) return;
            var currentCriteria = criterias.Dequeue();
            people.RemoveAll(person => currentCriteria(person.ToLower()));
            FilterPeople(criterias, people);
        }
    }
}
