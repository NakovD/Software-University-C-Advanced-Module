using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstProblem
{
    internal class Program
    {
        private static Queue<int> energyDrinks;

        private static Stack<int> caffeinеTotal;

        private static int totalCaffeine = 0;

        private static int maxCaffeineForNight = 300;

        static void Main(string[] args)
        {
            var entityFirstArr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var entitySecondArr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            energyDrinks = new Queue<int>(entitySecondArr);
            caffeinеTotal = new Stack<int>(entityFirstArr);

            CalculateCaffeine();

            if (energyDrinks.Any()) Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            else Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");

            Console.WriteLine($"Stamat is going to sleep with {totalCaffeine} mg caffeine.");
        }

        private static void CalculateCaffeine()
        {
            if (!energyDrinks.Any() || !caffeinеTotal.Any()) return;

            var drink = energyDrinks.Dequeue();
            var caffeine = caffeinеTotal.Pop();
            var multiply = drink * caffeine;

            if (multiply <= maxCaffeineForNight)
            {
                totalCaffeine += multiply;
                maxCaffeineForNight -= multiply;
            }
            else
            {
                energyDrinks.Enqueue(drink);
                if (totalCaffeine - 30 >= 0)
                {
                    totalCaffeine -= 30;
                    maxCaffeineForNight += 30;
                }
            }

            CalculateCaffeine();
        }
    }
}
