using System;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var divisibleBy = int.Parse(Console.ReadLine());

            Func<int, bool> predicate = n => n % divisibleBy != 0;

            var output = numbers.Reverse().Where(predicate);

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
