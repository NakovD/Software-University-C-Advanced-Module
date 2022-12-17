using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var finalIndex = 10000000;

            var fwatch = new Stopwatch();

            var swatch = new Stopwatch();

            var index = 0;

            var array = new int[finalIndex];

            fwatch.Start();
            do
            {
                index++;
            } while (index < finalIndex);
            //foreach (var item in array)
            //{
            //    index++;
            //}

            //for (int i = 0; i < finalIndex; i++)
            //{
            //    index++;
            //}

            fwatch.Stop();
            Console.WriteLine(fwatch.ElapsedTicks);

        }
    }
}
