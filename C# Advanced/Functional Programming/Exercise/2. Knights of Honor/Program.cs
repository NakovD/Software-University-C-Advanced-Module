using System;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var output = input.Split(" ");

            Action<string> appendSir = str => Console.WriteLine($"Sir {str}");

            Array.ForEach(output, appendSir);
        }
    }
}
