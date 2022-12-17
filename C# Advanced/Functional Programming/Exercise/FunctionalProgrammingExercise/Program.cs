using System;
using System.Collections.Generic;

namespace _Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var output = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = str => Console.WriteLine(str);

            Array.ForEach(output, print);
        }
    }
}
