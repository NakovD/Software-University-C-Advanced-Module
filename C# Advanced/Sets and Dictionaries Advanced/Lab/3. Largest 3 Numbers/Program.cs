using System;
using System.Linq;

namespace _3._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var integers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var ordered = integers.OrderByDescending(x => x);
            var howManyToPrint = 3;

            var biggestAmount = ordered.Take(howManyToPrint);
            var elementsAsString = string.Join(" ", biggestAmount);

            Console.WriteLine(elementsAsString);
        }
    }
}
