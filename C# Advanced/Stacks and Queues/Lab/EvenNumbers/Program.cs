using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ");
            var queue = new Queue<int>(Array.ConvertAll(input, number => int.Parse(number)));
            var evenNums = new Queue<int>();
            

            foreach (var item in queue)
            {
                if (item % 2 == 0) evenNums.Enqueue(item);
            }

            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}
