using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split(" ");
            var numElementsInQueue = firstInput[0];
            var elementsToRemove = int.Parse(firstInput[1]);
            var numberToFind = int.Parse(firstInput[2]);

            var numbersInQueue = Console.ReadLine().Split(" ");

            var queueWithNumbers = new Queue<int>(Array.ConvertAll(numbersInQueue, num => int.Parse(num)));

            for (int i = 0; i < elementsToRemove; i++)
            {
                queueWithNumbers.Dequeue();
            }

            if (queueWithNumbers.Contains(numberToFind))
            {
                Console.WriteLine("true");
                return;
            }
            if (queueWithNumbers.Count > 0)
            {
                Console.WriteLine(queueWithNumbers.Min());
                return;
            }

            Console.WriteLine("0");
        }
    }
}
