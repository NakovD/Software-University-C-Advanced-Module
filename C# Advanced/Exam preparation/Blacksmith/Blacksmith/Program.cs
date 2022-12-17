using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        private static Dictionary<string, int> swords = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            var steelArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var carbonArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            var steel = new Queue<int>(steelArr);
            var carbon = new Stack<int>(carbonArr);

            ForgeWeapons(steel, ref carbon);

            PrintOutput(steel, carbon);
        }

        private static void PrintOutput(Queue<int> steel, Stack<int> carbon)
        {
            if (swords.Count > 0)
            {
                var swordsCount = swords.Sum(sword => sword.Value);
                Console.WriteLine($"You have forged {swordsCount} swords.");
            }
            else Console.WriteLine($"You did not have enough resources to forge a sword.");
            var steelAsString = steel.Any() ? string.Join(", ", steel) : "none";
            var carbonAsString = carbon.Any() ? string.Join(", ", carbon) : "none";

            Console.WriteLine($"Steel left: {steelAsString}");
            Console.WriteLine($"Carbon left: {carbonAsString}");

            var orderedSwords = swords.OrderBy(sword => sword.Key).Select(sword => $"{sword.Key}: {sword.Value}");

            Console.WriteLine(string.Join(Environment.NewLine, orderedSwords));
        }

        private static void ForgeWeapons(Queue<int> steel, ref Stack<int> carbon)
        {
            if (!steel.Any() || !carbon.Any()) return;

            var currentSteel = steel.Dequeue();
            var currentCarbon = carbon.Peek();
            var weapon = GetWeapon(currentSteel + currentCarbon);
            if (string.IsNullOrEmpty(weapon))
            {
                var newCarbonValue = currentCarbon + 5;
                var newCarbon = InsertCarbonInCollection(carbon, newCarbonValue);
                carbon = newCarbon;
            }
            else
            {
                carbon.Pop();
                if (!swords.ContainsKey(weapon)) swords.Add(weapon, 0);
                swords[weapon]++;
            }

            ForgeWeapons(steel, ref carbon);
        }

        private static Stack<int> InsertCarbonInCollection(Stack<int> carbon, int newCarbonValue)
        {
            var carbonArr = carbon.ToArray();
            carbonArr[0] = newCarbonValue;
            var newCarbonStack = new Stack<int>(carbonArr.Reverse());
            return newCarbonStack;
        }

        private static string GetWeapon(int sumIngredients)
        {
            switch (sumIngredients)
            {
                case 70: return "Gladius";
                case 80: return "Shamshir";
                case 90: return "Katana";
                case 110: return "Sabre";
                case 150: return "Broadsword";
                default: return string.Empty;
            }
        }
    }
}
