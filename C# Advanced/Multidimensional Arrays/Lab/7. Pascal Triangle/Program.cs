using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var pascalTriangleSize = int.Parse(Console.ReadLine());
            var jaggedArr = new long[pascalTriangleSize][];
            jaggedArr[0] = new long[] { 1 };
            Console.WriteLine(jaggedArr[0][0]);

            for (long row = 1; row < pascalTriangleSize; row++)
            {
                var currentColsArrayLength = row + 1;
                var currentCols = new long[currentColsArrayLength];
                jaggedArr[row] = currentCols;
                for (long col = 0; col < currentColsArrayLength; col++)
                {
                    var previousArrayIndex = row - 1;
                    var previousRowArray = jaggedArr[previousArrayIndex];
                    long numberAboveLeft = 0;
                    var numberAboveLeftIndex = col - 1;
                    if (numberAboveLeftIndex >= 0 && numberAboveLeftIndex < previousRowArray.Length) numberAboveLeft = previousRowArray[numberAboveLeftIndex];
                    long numberAbove = 0;
                    var numberAboveIndex = col;
                    if (numberAboveIndex >= 0 && numberAboveIndex < previousRowArray.Length) numberAbove = previousRowArray[numberAboveIndex];
                    var currentNumb = numberAboveLeft + numberAbove;
                    currentCols[col] = currentNumb;
                    Console.Write(currentNumb + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
