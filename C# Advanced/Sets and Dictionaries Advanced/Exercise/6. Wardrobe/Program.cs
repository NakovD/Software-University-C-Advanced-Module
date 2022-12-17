using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var lineAmount = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < lineAmount; i++)
            {
                var currentLine = Console.ReadLine().Split(" -> ");
                var currentColor = currentLine[0];
                var clothes = currentLine[1].Split(",");

                if (wardrobe.ContainsKey(currentColor))
                {
                    var currentClothes = wardrobe[currentColor];
                    AddClothes(currentClothes, clothes);
                    continue;
                }

                var clothesDictionary = new Dictionary<string, int>();
                AddClothes(clothesDictionary, clothes);
                wardrobe.Add(currentColor, clothesDictionary);
            }

            var clothForTheDay = Console.ReadLine().Split(" ");
            var colorOfClothForTheDay = clothForTheDay[0];
            var typeOfClothForTheDay = clothForTheDay[1];

            foreach (var color in wardrobe)
            {
                var currentClothes = wardrobe[color.Key];
                var clothesAsString = currentClothes.Select(cloth => $"* {cloth.Key} - {cloth.Value}{(cloth.Key == typeOfClothForTheDay && color.Key == colorOfClothForTheDay ? " (found!)" : "")}");
                Console.WriteLine($"{color.Key} clothes:");
                Console.WriteLine(string.Join("\n", clothesAsString));
            }
        }

        static void AddClothes(Dictionary<string, int> currentClothes, string[] clothes)
        {
            foreach (var cloth in clothes)
            {
                if (currentClothes.ContainsKey(cloth))
                {
                    currentClothes[cloth] += 1;
                    continue;
                }

                currentClothes.Add(cloth, 1);
            }
        }
    }
}
