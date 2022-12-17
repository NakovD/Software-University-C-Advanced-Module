using System;
using System.Collections.Generic;
using System.Linq;

namespace October2021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vowelsArr = Console.ReadLine().Replace(" ", "").ToCharArray();
            var consonantsArr = Console.ReadLine().Replace(" ", "").ToCharArray();

            var characters = "pearflourporkolive";

            var words = new List<string> { "pear", "flour", "pork", "olive" };

            var charDictionary = new Dictionary<char, int>();

            foreach (var character in characters)
            {
                if (!charDictionary.ContainsKey(character)) charDictionary.Add(character, 0);
                charDictionary[character] += 1;
            }

            var wordsFound = new List<string>();
            var validCharacters = new List<char>();

            var vowels = new Queue<char>(vowelsArr);
            var consonants = new Stack<char>(consonantsArr);

            while (consonants.Any())
            {
                vowels.TryDequeue(out var vowel);
                var consonant = consonants.Pop();
                if (charDictionary.ContainsKey(vowel))
                {
                    if (charDictionary[vowel] != 0)
                    {
                        charDictionary[vowel] -= 1;
                        validCharacters.Add(vowel);
                    }
                }
                if (charDictionary.ContainsKey(consonant))
                {
                    if (charDictionary[consonant] != 0)
                    {
                        charDictionary[consonant] -= 1;
                        validCharacters.Add(consonant);
                    }
                }

                vowels.Enqueue(vowel);
            }

            foreach (var word in words)
            {
                var isWordValid = word.All(character => validCharacters.Contains(character));
                if (isWordValid)
                {
                    wordsFound.Add(word);
                }
            }

            Console.WriteLine($"Words found: {wordsFound.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, wordsFound));
        }
    }
}
