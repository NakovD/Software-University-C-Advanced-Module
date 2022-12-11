using System;
using System.Linq;

namespace ArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var sum = SumElements(numbers, 0);

            Console.WriteLine(sum);
        }

        private static int SumElements(int[] numbers, int index)
        {
            if (index + 1 == numbers.Length) return numbers[index];

            return numbers[index] + SumElements(numbers, ++index);
        }
    }
}
