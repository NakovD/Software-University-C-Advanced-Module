using System;
using System.Linq;
using System.Collections.Generic;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currentLine = Console.ReadLine();
            var customStack = new CustomStack<int>();

            while (!currentLine.ToLower().Contains("end"))
            {
                var currentData = currentLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                currentLine = Console.ReadLine();
                var command = currentData[0].ToString().ToLower();

                if (command == "pop")
                {
                    if (customStack.Count > 0) customStack.Pop();
                    else Console.WriteLine("No elements");
                    continue;
                }

                var elementToAddInTheStack = currentData
                                                    .Skip(1)
                                                    .Select(num => num = num.Replace(",", ""))
                                                    .Select(int.Parse);

                foreach (var num in elementToAddInTheStack)
                {
                    customStack.Push(num);
                }
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
