using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Array.Sort(input, new CustomComparator());
            Console.WriteLine(string.Join(" ", input));
        }
    }


    public class CustomComparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 == 0)
            {
                if (x > y) return 1;

                else if(x < y)  return -1;

                return 0;
            }
            else if (x % 2 != 0 && y % 2 != 0)
            {
                if (x > y) return 1;

                else if (x < y) return -1;

                return 0;
            }
            else if (x % 2 == 0 && y % 2 != 0) return -1;
            else return 1;
        }
    }
}
