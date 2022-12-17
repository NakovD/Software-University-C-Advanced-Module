using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Barista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coffeeQuantities = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var milkQuantities = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            var coffee = new Queue<int>(coffeeQuantities);
            var milk = new Stack<int>(milkQuantities);
            var drinksMade = new Dictionary<string, int>();

            while (coffee.Count > 0 && milk.Count > 0)
            {
                var coffeeLine = coffee.Peek();
                var milkLine = milk.Peek();
                var beverage = GetBeverage(coffeeLine + milkLine);
                if (string.IsNullOrEmpty(beverage)) { ReduceQuantities(coffee, ref milk); continue; }
                RemoveQuantities(coffee, milk);
                AddBeverageToList(beverage, drinksMade);
            }

            var coffeeLeft = coffee.Count == 0 ? "none" : $"{string.Join(", ", coffee)}";
            var milkLeft = milk.Count == 0 ? "none" : $"{string.Join(", ", milk)}";

            if (coffee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            Console.WriteLine($"Coffee left: {coffeeLeft}");
            Console.WriteLine($"Milk left: {milkLeft}");

            var sortedDrinks = drinksMade
                .OrderBy(drink => drink.Value)
                .ThenByDescending(drink => drink.Key)
                .Select(drink => $"{drink.Key}: {drink.Value}");

            Console.WriteLine(string.Join(Environment.NewLine, sortedDrinks));
        }

        public static void AddBeverageToList(string beverage, Dictionary<string, int> drinksMade)
        {
            if (!drinksMade.ContainsKey(beverage))
            {
                drinksMade.Add(beverage, 0);
            }
            drinksMade[beverage] += 1;
        }

        public static void RemoveQuantities(Queue<int> coffee, Stack<int> milk)
        {
            coffee.Dequeue();
            milk.Pop();
        }

        public static void ReduceQuantities(Queue<int> coffee, ref Stack<int> milk)
        {
            coffee.Dequeue();
            var milkAsArray = milk.ToArray().Reverse().ToArray();
            milkAsArray[milkAsArray.Length - 1] -= 5;
            milk = new Stack<int>(milkAsArray);
        }

        public static string GetBeverage(int sum)
        {
            switch (sum)
            {
                case 50: return "Cortado";
                case 75: return "Espresso";
                case 100: return "Capuccino";
                case 150: return "Americano";
                case 200: return "Latte";
                default: return string.Empty;
            }
        }
    }
}
