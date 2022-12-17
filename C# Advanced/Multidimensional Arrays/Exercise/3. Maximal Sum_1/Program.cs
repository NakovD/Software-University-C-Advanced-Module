using System;
using System.Linq;

namespace _3._Maximal_Sum_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Read input and parse data
            var mainMatrixDimensions = Console.ReadLine().Split(" ");
            var mainMatrixRows = int.Parse(mainMatrixDimensions[0]);
            var mainMatrixCols = int.Parse(mainMatrixDimensions[1]);
            var mainMatrix = new int[mainMatrixRows, mainMatrixCols];
            var innerMatrixRows = 3;
            var innerMatrixCols = 3;
            #endregion

            #region Fill matrix with data

            for (int row = 0; row < mainMatrixRows; row++)
            {
                var currentRowColumns = Console.ReadLine().Trim().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < mainMatrixCols; col++)
                {
                    mainMatrix[row, col] = currentRowColumns[col];
                }
            }

            #endregion

            #region Walk through the main and inner matrices

            var innerMatrixMaxSum = int.MinValue;
            var innerMatrixMinRow = int.MinValue;
            var innerMatrixMinCol = int.MinValue;

            for (int row = 0; row < mainMatrixRows; row++)
            {
                for (int col = 0; col < mainMatrixCols; col++)
                {
                    var currentElement = mainMatrix[row, col];
                    var innerMatrixMaxRow = row + innerMatrixRows;
                    var innerMatrixMaxCol = col + innerMatrixCols;

                    if (innerMatrixMaxRow > mainMatrixRows || innerMatrixMaxCol > mainMatrixCols) break;

                    var currentInnerMatrixSum = 0;

                    for (int innerMatrixRow = row; innerMatrixRow < innerMatrixMaxRow; innerMatrixRow++)
                    {
                        for (int innerMatrixCol = col; innerMatrixCol < innerMatrixMaxCol; innerMatrixCol++)
                        {
                            var currentNumber = mainMatrix[innerMatrixRow, innerMatrixCol];
                            currentInnerMatrixSum += currentNumber;
                        }
                    }
                    CompareCurrentMatrixSumAndCoordinatesToMax(currentInnerMatrixSum, ref innerMatrixMaxSum, row, col, ref innerMatrixMinRow, ref innerMatrixMinCol);

                }
            }
            #endregion

            #region Print the max sum and the founded inned max matrix
            Console.WriteLine($"Sum = {innerMatrixMaxSum}");

            for (int row = innerMatrixMinRow; row < innerMatrixMinRow + innerMatrixRows; row++)
            {
                for (int col = innerMatrixMinCol; col < innerMatrixMinCol + innerMatrixCols; col++)
                {
                    Console.Write(mainMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }
            #endregion
        }

        static void CompareCurrentMatrixSumAndCoordinatesToMax(int currentSum, ref int maxSum, int currentMinRow, int currentMinCol, ref int maxMinRow, ref int maxMinCol)
        {
            if (currentSum <= maxSum) return;

            maxSum = currentSum;
            maxMinRow = currentMinRow;
            maxMinCol = currentMinCol;
        }
    }
}
