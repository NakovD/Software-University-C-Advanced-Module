using System;
using System.Collections.Generic;
using System.Text;

namespace MergeSort
{
    //public class MergeSorter
    //{
    //    public static int[] MergeSort(int[] array)
    //    {
    //        if (array.Length == 1)
    //        {
    //            return array;
    //        }
    //        var middle = array.Length / 2;
    //        var leftArray = SplitArray(array, 0, middle);
    //        var rightArray = SplitArray(array, middle, array.Length);

    //        var mergedArray = MergeSortedArrays(MergeSort(leftArray), MergeSort(rightArray));

    //        return mergedArray;

    //    }

    //    private static int[] MergeSortedArrays(int[] firstArray, int[] secondArray)
    //    {
    //        var mergedArray = new int[firstArray.Length + secondArray.Length];
    //        var mergedArrayIndex = 0;
    //        var firstArrayIndex = 0;
    //        var secondArrayIndex = 0;

    //        while (true)
    //        {
    //            if (firstArrayIndex < firstArray.Length && secondArrayIndex < secondArray.Length)
    //            {
    //                var firstArrayElement = firstArray[firstArrayIndex];
    //                var secondArrayElement = secondArray[secondArrayIndex];
    //                if (firstArrayElement < secondArrayElement)
    //                {
    //                    mergedArray[mergedArrayIndex++] = firstArrayElement;
    //                    firstArrayIndex++;
    //                }
    //                else
    //                {
    //                    mergedArray[mergedArrayIndex++] = secondArrayElement;
    //                    secondArrayIndex++;
    //                }
    //            }
    //            else if (firstArrayIndex < firstArray.Length)
    //            {
    //                mergedArray[mergedArrayIndex++] = firstArray[firstArrayIndex++];
    //            }
    //            else if (secondArrayIndex < secondArray.Length)
    //            {
    //                mergedArray[mergedArrayIndex++] = secondArray[secondArrayIndex++];
    //            }
    //            else
    //            {
    //                return mergedArray;
    //            }
    //        }
    //    }

    //    private static int[] SplitArray(int[] array, int arrayStart, int arrayEnd)
    //    {
    //        var newArrayLength = arrayStart == 0 ? arrayEnd : array.Length - arrayStart;
    //        var newArray = new int[newArrayLength];
    //        var newArrayIndex = 0;

    //        for (int i = arrayStart; i < arrayEnd; i++)
    //        {
    //            newArray[newArrayIndex] = array[i];
    //            newArrayIndex++;
    //        }

    //        return newArray;
    //    }
    //}
}
