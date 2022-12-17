using System;
using System.Globalization;
using System.Linq;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sortedArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var neededNum = int.Parse(Console.ReadLine());
            var index = BinarySearcher.BinarySearch(sortedArray, neededNum);
            Console.WriteLine(index);
        }
    }

    public class BinarySearcher
    {
        public static int BinarySearch(int[] sortedArray, int neededNum)
        {
            sortedArray = sortedArray.OrderBy(x => x).ToArray();
            var start = 0;
            var end = sortedArray.Length - 1;

            while (start <= end)
            {
                int middle = start + (end - start) / 2;
                if (neededNum < sortedArray[middle])
                {
                    end = middle - 1;
                }
                else if (neededNum > sortedArray[middle])
                {
                    start = middle + 1;
                }
                else { return middle; }
            }

            return -1;
        }
    }
}
