using System;
using System.Linq;

namespace _7._Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameLengthRange = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split(" ");

            var filteredNames = names.Where(name => name.Length <= nameLengthRange);

            Console.WriteLine(string.Join(Environment.NewLine, filteredNames));
        }
    }
}
