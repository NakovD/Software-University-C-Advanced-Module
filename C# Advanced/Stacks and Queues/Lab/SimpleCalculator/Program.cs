using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ");
            var stackWithStrings = new Stack<string>(input.Reverse());
            var result = 0;
            var shouldNextElementBeNegative = false;

            while (stackWithStrings.Count > 0)
            {
                var currentElement = stackWithStrings.Pop();

                if (currentElement == "-")
                {
                    shouldNextElementBeNegative = true;
                    continue;
                }
                if (currentElement == "+")
                {
                    shouldNextElementBeNegative = false;
                    continue;
                }
                var parsedNumber = int.Parse(currentElement);
                var currentNumber = shouldNextElementBeNegative ? parsedNumber * -1 : parsedNumber;
                result += currentNumber;
            }

            Console.WriteLine(result);
        }
    }
}
