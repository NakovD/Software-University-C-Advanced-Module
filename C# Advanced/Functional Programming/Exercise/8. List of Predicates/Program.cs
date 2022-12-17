using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var endOfRange = int.Parse(Console.ReadLine());
            var numbers = new List<int>();

            for (int i = 1; i <= endOfRange; i++)
            {
                numbers.Add(i);
            }

            var dividers = Console.ReadLine().Split(" ").Select(int.Parse);

            var filteredNumbers = numbers.Where(n => dividers.All(divider => n % divider == 0));

            Console.WriteLine(string.Join(" ", filteredNumbers));
        }
    }
}
