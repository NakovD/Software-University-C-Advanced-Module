using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cupsCapacity = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var _bottles = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var wastedWatterLitters = 0;

            var cups = new Queue<int>(cupsCapacity);
            var bottles = new Stack<int>(_bottles);
            var remainderOfPreviousCup = 0;

            while(cups.Any() && bottles.Any())
            {
                var currentBottle = bottles.Pop();
                var currentCup = remainderOfPreviousCup <= 0 ? cups.Peek() : remainderOfPreviousCup;

                if (currentBottle >= currentCup)
                {
                    wastedWatterLitters += currentBottle - currentCup;
                    remainderOfPreviousCup = 0;
                    cups.Dequeue();
                }
                else
                {
                    remainderOfPreviousCup = currentCup - currentBottle;
                }
            }

            if (!cups.Any()) Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            else Console.WriteLine($"Cups: {string.Join(" ", cups)}");

            Console.WriteLine($"Wasted litters of water: {wastedWatterLitters}");
        }
    }
}
