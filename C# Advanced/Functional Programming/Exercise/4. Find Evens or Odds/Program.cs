using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var bounds = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var lowerBound = bounds[0];
            var upperBound = bounds[1];
            var command = Console.ReadLine();
            Func<int, string, bool> getSpecificNumber = (n, command) => command.ToLower() == "odd" ? n % 2 != 0 : n % 2 == 0;
            var numbers = new List<int>();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            var onlySpecificNumbers = numbers.Where(n => getSpecificNumber(n, command));

            Console.WriteLine(string.Join(" ", onlySpecificNumbers));
        }
    }
}
