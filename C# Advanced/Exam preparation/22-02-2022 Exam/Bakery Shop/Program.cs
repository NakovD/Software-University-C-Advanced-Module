using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var waterArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse);
            var flourArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse);

            var water = new Queue<double>(waterArray);
            var flour = new Stack<double>(flourArray);

            var productsBaked = new Dictionary<string, int>();

            while (water.Any() && flour.Any())
            {
                var currentWater = water.Peek();
                var currentFlour = flour.Peek();
                (double waterPercent, double flourPercent) = CalculatePercentages(currentWater, currentFlour);
                var bakeryProduct = GetBakeryProduct(waterPercent, flourPercent);
                var noMatch = string.IsNullOrEmpty(bakeryProduct);
                if (noMatch) { AddBestSellingProduct(currentWater, currentFlour, water, ref flour, productsBaked); continue; }
                if (!productsBaked.ContainsKey(bakeryProduct)) { productsBaked.Add(bakeryProduct, 0); }
                productsBaked[bakeryProduct]++;
                water.Dequeue();
                flour.Pop();
            }

            var sortedBakedProducts = productsBaked
                .OrderByDescending(product => product.Value)
                .ThenBy(product => product.Key)
                .Select(product => $"{product.Key}: {product.Value}");

            Console.WriteLine(string.Join(Environment.NewLine, sortedBakedProducts));

            var waterOutput = string.Join(", ", water);

            if (!water.Any())
            {
                waterOutput = "None";
            }

            Console.WriteLine($"Water left: {waterOutput}");

            var flourOutput = string.Join(", ", flour);

            if (!flour.Any())
            {
                flourOutput = "None";
            }

            Console.WriteLine($"Flour left: {flourOutput}");
        }

        private static void AddBestSellingProduct(double currentWater, double currentFlour, Queue<double> water, ref Stack<double> flour, Dictionary<string, int> productsBaked)
        {
            var remainingFlour = currentFlour - currentWater;
            var flourAsArray = flour.ToArray();
            flourAsArray[0] = remainingFlour;
            flour = new Stack<double>(flourAsArray.Reverse());
            water.Dequeue();
            if (!productsBaked.ContainsKey("Croissant")) productsBaked.Add("Croissant", 0);
            productsBaked["Croissant"]++;
        }

        private static string GetBakeryProduct(double waterPercent, double flourPercent)
        {
            if (waterPercent == 50 && flourPercent == 50) return "Croissant";
            if (waterPercent == 40 && flourPercent == 60) return "Muffin";
            if (waterPercent == 30 && flourPercent == 70) return "Baguette";
            if (waterPercent == 20 && flourPercent == 80) return "Bagel";

            return string.Empty;
        }

        private static (double, double) CalculatePercentages(double currentWater, double currentFlour)
        {
            var sum = currentWater + currentFlour;
            var waterPercentage = (currentWater * 100) / sum;
            var flourtPercentage = (currentFlour * 100) / sum;

            return (waterPercentage, flourtPercentage);
        }
    }
}
