using System;

namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 38, 27, 43, 3, 9, 82, 10, 12, 13, 12 };

            var sortedArray = MergeSorter.MergeSort(array);

            Console.WriteLine(string.Join(Environment.NewLine, sortedArray));
        }
    }
}
