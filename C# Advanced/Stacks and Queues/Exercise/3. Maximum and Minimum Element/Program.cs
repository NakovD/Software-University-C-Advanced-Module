using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var queries = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < queries; i++)
            {
                var currentQuery = Console.ReadLine().Split(" ");
                var command = currentQuery[0];

                switch (command)
                {
                    case "1":
                        var numberToAddInStack = int.Parse(currentQuery[1]);
                        stack.Push(numberToAddInStack);
                        break;
                    case "2":
                        if (stack.Count > 0) stack.Pop();
                        break;
                    case "3":
                        if (stack.Count > 0) Console.WriteLine(stack.Max());

                        break;
                    default:
                        if (stack.Count > 0) Console.WriteLine(stack.Min());
                        break;
                }

            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
