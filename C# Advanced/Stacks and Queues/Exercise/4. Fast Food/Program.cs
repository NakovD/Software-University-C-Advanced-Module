using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            var food = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split(" ");
            var ordersQueue = new Queue<int>(Array.ConvertAll(orders, order => int.Parse(order)));

            Console.WriteLine(ordersQueue.Max());

            while (food > 0)
            {
                if (ordersQueue.Count == 0) break;
                var currentOrder = ordersQueue.Peek();
                if (food - currentOrder < 0) break;
                food = food - currentOrder;
                ordersQueue.Dequeue();
            }

            if (ordersQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                var ordersAsString = string.Join(" ", ordersQueue);
                Console.WriteLine($"Orders left: {ordersAsString}");
            }
        }
    }
}
