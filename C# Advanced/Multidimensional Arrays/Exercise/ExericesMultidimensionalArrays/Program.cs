using System;
using System.Linq;

namespace ExericesMultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                var currentCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < currentCols.Length; col++)
                {
                    var currentCol = currentCols[col];
                    matrix[row, col] = currentCol;
                }
            }

            var backwardIndex = matrixSize;
            var firstDiagonalSum = 0;
            var secondDiagonalSum = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    var currentEl = matrix[row, col];
                    if (row == col) firstDiagonalSum += currentEl;
                    if (col == matrixSize - row - 1) secondDiagonalSum += currentEl;
                }
            }

            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}
