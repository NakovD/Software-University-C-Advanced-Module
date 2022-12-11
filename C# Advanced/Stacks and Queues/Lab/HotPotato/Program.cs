using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var kids = Console.ReadLine().Split(" ");
            var turns = int.Parse(Console.ReadLine());
            var kidsQueue = new Queue<string>(kids);
            var index = 1;

            while (true)
            {
                if (kidsQueue.Count == 1) break;
                if (index == turns)
                {
                    var kidThatLeftTheGame = kidsQueue.Dequeue();
                    Console.WriteLine("Removed " + kidThatLeftTheGame);
                    index = 1;
                    continue;
                }
                var kidWithThePotato = kidsQueue.Dequeue();
                kidsQueue.Enqueue(kidWithThePotato);
                index++;
            }

            Console.WriteLine("Last is " + string.Join("", kidsQueue));
        }
    }
}
