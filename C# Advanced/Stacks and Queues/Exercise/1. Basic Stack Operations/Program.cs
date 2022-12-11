using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split(" ");
            var numElementsInStack = firstInput[0];
            var elementsToRemove = int.Parse(firstInput[1]);
            var numberToFind = int.Parse(firstInput[2]);

            var numbersInStack = Console.ReadLine().Split(" ");

            var stackWithNumbers = new Stack<int>(Array.ConvertAll(numbersInStack, num => int.Parse(num)));

            for (int i = 0; i < elementsToRemove; i++)
            {
                stackWithNumbers.Pop();
            }

            if (stackWithNumbers.Contains(numberToFind))
            {
                Console.WriteLine("true");
                return;
            }
            if (stackWithNumbers.Count > 0)
            {
                Console.WriteLine(stackWithNumbers.Min());
                return;
            }

            Console.WriteLine("0");
        }
    }
}
