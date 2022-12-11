using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var linesAmount = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, int>();

            for (int i = 0; i < linesAmount; i++)
            {
                var currentLine = Console.ReadLine();
                if (dictionary.ContainsKey(currentLine))
                {
                    dictionary[currentLine] += 1;
                    continue;
                }
                dictionary.Add(currentLine, 1);
            }

            foreach (var number in dictionary)
            {
                if (number.Value % 2 == 0) Console.WriteLine(number.Key);
            }
        }
    }
}
