using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialNumbers = Console.ReadLine().Split(" ");
            var stackWithNumbers = new Stack<int>(Array.ConvertAll(initialNumbers, num => int.Parse(num)));
            var command = string.Empty;

            var ADD_COMMAND = "add";

            while (command != "end") {
                var input = Console.ReadLine().ToLower();
                command = input.Split(" ")[0];
                
                if (command == "add")
                {
                    var numbers = input.Replace(ADD_COMMAND + " ", "").Split(" ");
                    foreach (var number in numbers)
                    {
                        stackWithNumbers.Push(int.Parse(number));
                    }
                }
                if (command == "remove")
                {
                    var itemsToRemove = int.Parse(input.Split(" ")[1]);
                    if (itemsToRemove > stackWithNumbers.Count) continue;
                    for (int i = 0; i < itemsToRemove; i++)
                    {
                        stackWithNumbers.Pop();
                    }
                }
            }

            Console.WriteLine("Sum: " + stackWithNumbers.Sum());
        }
    }
}
