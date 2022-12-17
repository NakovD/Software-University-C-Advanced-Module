using System;
using System.Linq;

namespace _3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Func<int, int, int> getSmallestNumber = (n, minNumber) => {
                if (n < minNumber) { minNumber = n; return n; }
                return minNumber;
            };

            var output = input.Split(" ").Select(int.Parse).Aggregate(int.MaxValue, (min, next) => getSmallestNumber(next, min));
            Console.WriteLine(output);
        }
    }
}
