using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new Queue<string>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End") break;
                if (input == "Paid")
                {
                    Console.WriteLine(string.Join("\n", customers));
                    customers.Clear();
                    continue;
                }
                customers.Enqueue(input);
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
