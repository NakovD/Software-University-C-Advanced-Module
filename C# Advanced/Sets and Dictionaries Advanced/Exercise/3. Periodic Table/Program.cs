using System;
using System.Collections.Generic;

namespace _3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var linesAmount = int.Parse(Console.ReadLine());
            var periodicTable = new SortedSet<string>();

            for (int i = 0; i < linesAmount; i++)
            {
                var currentLine = Console.ReadLine().Split(" ");
                for (int j = 0; j < currentLine.Length; j++)
                {
                    var currentElement = currentLine[j];
                    periodicTable.Add(currentElement);
                }
            }

            Console.WriteLine(string.Join(" ", periodicTable));
        }
    }
}
