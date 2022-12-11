using System;
using System.Collections.Generic;

namespace _2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ");
            var firstSetElements = int.Parse(input[0]);
            var secondSetElements = int.Parse(input[1]);
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            var elementsInBothSets = new HashSet<int>();

            var index = 0;

            while (index < firstSetElements + secondSetElements)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                index++;
                if (index <= firstSetElements)
                {
                    firstSet.Add(currentNumber);
                    continue;
                }

                secondSet.Add(currentNumber);
            }

            foreach (var number in firstSet)
            {
                var secondSetContainsThisNumber = secondSet.Contains(number);
                if (secondSetContainsThisNumber) elementsInBothSets.Add(number);
            }

            Console.WriteLine(string.Join(" ", elementsInBothSets));
        }
    }
}
