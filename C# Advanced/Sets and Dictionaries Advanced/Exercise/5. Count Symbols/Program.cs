using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var dictionaryWithChars = new SortedDictionary<string, int>();

            foreach (var _character in input)
            {
                var character = _character.ToString();

                if (dictionaryWithChars.ContainsKey(character))
                {
                    dictionaryWithChars[character] += 1;
                    continue;
                }

                dictionaryWithChars.Add(character, 1);
            }

            var sortedDictionary = dictionaryWithChars
                .OrderByDescending(x => x.Key == x.Key.ToUpper())
                .ThenBy(x => x.Key);

            foreach (var character in sortedDictionary)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
