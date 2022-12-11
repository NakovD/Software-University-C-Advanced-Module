using System;
using System.Collections.Generic;

namespace GenericSwap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var list = new List<int>();

            for (int i = 0; i < lines; i++)
            {
                var line = int.Parse(Console.ReadLine());
                list.Add(line);
            }

            var command = Console.ReadLine().Split(" ");
            var fIndex = int.Parse(command[0]);
            var sIndex = int.Parse(command[1]);

            Swap(list, fIndex, sIndex);

            list.ForEach(str => Console.WriteLine($"{str.GetType()}: {str}"));
        }

        static public void Swap<T>(List<T> list, int firstIndex, int secondIndex )
        {
            var firstValue = list[firstIndex];
            var secondValue = list[secondIndex];
            list[firstIndex] = secondValue;
            list[secondIndex] = firstValue;
        }
    }
}
