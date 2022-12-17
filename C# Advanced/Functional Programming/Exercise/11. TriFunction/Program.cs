using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfCharacters = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> namesPredicate = (name, n) =>
            {
                var sum = 0;
                SumStringCharacters(name, ref sum);
                if (sum < numberOfCharacters) return false;
                return true;
            };

            FindNamesThatMeetsCriteriaAndPrint(names, numberOfCharacters, namesPredicate);
        }

        static void FindNamesThatMeetsCriteriaAndPrint(List<string> names, int criteriaParam, Func<string, int, bool> criteria)
        {
            var firstNamePassingTheCriteria = names.Find(name => criteria(name, criteriaParam));

            Console.WriteLine(firstNamePassingTheCriteria);
        }

        static void SumStringCharacters(string str, ref int sum, int index = 0)
        {
            if (index == str.Length) return;
            sum += str[index];
            index++;
            SumStringCharacters(str, ref sum, index);
        }
    }



    class Human
    {
        public string Name { get; set; }
    }
}
