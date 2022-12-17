using System;
using System.Linq;

namespace _5._Square_with_Maximum_Sum
{
    class Program
    {
        static int minInnerMatrixRow = int.MaxValue;
        static int minInnerMatrixCol = int.MaxValue;
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var matrixRows = input[0];
            var matrixCols = input[1];
            var innerMatrixRows = 2;
            var innerMatrixCols = 2;

            var matrix = new int[matrixRows, matrixCols];

            for (int row = 0; row < matrixRows; row++)
            {
                var currentCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < currentCols.Length; col++)
                {
                    matrix[row, col] = currentCols[col];
                }
            }


            var biggestInnerMatrixSum = 0;

            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixCols; col++)
                {
                    var currentElementMatrix = matrix[row, col];
                    var innerMatrixSum = 0;
                    var newInnerMatrixRows = row + innerMatrixRows;
                    var newInnerMatrixCols = col + innerMatrixCols;
                    if (newInnerMatrixRows > matrixRows || newInnerMatrixCols > matrixCols) break;
                    for (int innerMatrixRow = row; innerMatrixRow < newInnerMatrixRows; innerMatrixRow++)
                    {
                        for (int innerMatrixCol = col; innerMatrixCol < newInnerMatrixCols; innerMatrixCol++)
                        {
                            var currentElementInnerMatrix = matrix[innerMatrixRow, innerMatrixCol];
                            innerMatrixSum += currentElementInnerMatrix;
                        }
                    }

                    biggestInnerMatrixSum = GetTopLeftBiggestInnerMatrixSum(innerMatrixSum, biggestInnerMatrixSum, row, col);
                }
            }

            for (int biggestInnerMatrixRow = minInnerMatrixRow; biggestInnerMatrixRow < minInnerMatrixRow + innerMatrixRows; biggestInnerMatrixRow++)
            {
                for (int biggestInnerMatrixCol = minInnerMatrixCol; biggestInnerMatrixCol < minInnerMatrixCol + innerMatrixCols; biggestInnerMatrixCol++)
                {
                    Console.Write($"{matrix[biggestInnerMatrixRow, biggestInnerMatrixCol]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(biggestInnerMatrixSum);
        }

        static int GetTopLeftBiggestInnerMatrixSum(int newSum, int currentBigSum, int currentRow, int currentCol)
        {
            if (newSum > currentBigSum)
            {
                //var isNewSumTheMostTopLeftOne = CompareBiggestInnerMatrixRowAndCol(currentRow, currentCol);
                //if (!isNewSumTheMostTopLeftOne) return currentBigSum;
                minInnerMatrixRow = currentRow;
                minInnerMatrixCol = currentCol;
                return newSum;
            }

            return currentBigSum;
        }
    }
}
