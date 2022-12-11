using System;
using System.Collections.Generic;

namespace WorkshopListStackQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customList = new CustomList<int>();

            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);
            customList.Add(5);
            customList.Add(6);
            customList.Add(7);
            customList.Add(8);
            customList.Add(9);
            customList.Add(10);

            customList.Insert(5, 11);

            Console.WriteLine(customList[4]);
        }
    }
}
