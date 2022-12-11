using System;
using System.Collections.Concurrent;
using System.Linq;

namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            QuickSorter.QuickSort(array, 0, array.Length - 1);
            Console.WriteLine(String.Join(" ", array));
        }
    }

    public class QuickSorter
    {
        public static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end || start < 0 || end < 0) return;

            var pivotIndex = Partition(array, start, end);

            QuickSort(array, start, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, end);

        }

        private static int Partition(int[] array, int start, int end)
        {
            var pivot = array[end];

            var pivotIndex = start;

            for (int i = start; i < end; i++)
            {
                if (array[i] <= pivot)
                {
                    Swap(array, i, pivotIndex);
                    pivotIndex++;
                }

            }

            Swap(array, pivotIndex, end);
            return pivotIndex;
        }

        private static void Swap(int[] array, int i, int pivotIndex)
        {
            var temp = array[i];
            array[i] = array[pivotIndex];
            array[pivotIndex] = temp;
        }
    }
}
