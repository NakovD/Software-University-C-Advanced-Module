using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    internal class Program
    {
        private static Queue<int> ingredients;

        private static Stack<int> freshnessValues;

        private static Dictionary<string, int> dishesMade = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            var ingredientsArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(ingredient => ingredient != 0);
            var freshnessArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            ingredients = new Queue<int>(ingredientsArr);
            freshnessValues = new Stack<int>(freshnessArr);

            CreateDish();

            PrintOutput();
        }

        private static void PrintOutput()
        {
            var hasSucceded = dishesMade.Keys.Count == 4;

            if (hasSucceded)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Any())
            {
                var ingredientsSum = ingredients.Sum();
                Console.WriteLine($"Ingredients left: {ingredientsSum}");
            }

            var sortedDishes = dishesMade.OrderBy(dish => dish.Key).Select(dish => $"# {dish.Key} --> {dish.Value}");
            Console.WriteLine(String.Join(Environment.NewLine, sortedDishes));
        }

        private static void CreateDish()
        {
            if (!ingredients.Any() || !freshnessValues.Any()) return;
            var ingredient = ingredients.Peek();
            var freshness = freshnessValues.Peek();
            var dish = GetDish(ingredient * freshness);
            var isDishInvalid = string.IsNullOrEmpty(dish);
            freshnessValues.Pop();
            if (isDishInvalid)
            {
                AdjustIngredient();
            }
            else
            {
                ingredients.Dequeue();
                if (!dishesMade.ContainsKey(dish)) dishesMade.Add(dish, 0);
                dishesMade[dish] += 1;
            }

            CreateDish();
        }

        private static void AdjustIngredient()
        {
            var currentIngredientValue = ingredients.Dequeue();
            var newIngredientValue = currentIngredientValue + 5;
            ingredients.Enqueue(newIngredientValue);
        }

        private static string GetDish(int totalFreshness)
        {
            switch (totalFreshness)
            {
                case 150: return "Dipping sauce";
                case 250: return "Green salad";
                case 300: return "Chocolate cake";
                case 400: return "Lobster";
            }

            return string.Empty;
        }
    }
}
