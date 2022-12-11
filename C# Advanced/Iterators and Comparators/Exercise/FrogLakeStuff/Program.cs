using System;
using System.Collections.Generic;
using System.Linq;

namespace FrogLakeStuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stones = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var firstTypeStones = new List<int>();
            var secondTypeStones = new List<int>();

            for (int i = 0; i < stones.Length; i++)
            {
                if (i % 2 == 0)
                {
                    firstTypeStones.Add(stones[i]);
                }
                else
                {
                    secondTypeStones.Add(stones[i]);
                }
            }

            secondTypeStones.Reverse();

            var all = firstTypeStones.Concat(secondTypeStones);

            Console.WriteLine(string.Join(", ", all));
        }
    }
}
