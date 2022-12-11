using System;
using System.Linq;

namespace MatrixAndJaggedArraysLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var matrixRows = input[0];
            var matrixCols = input[1];

            var matrix = new int[matrixRows, matrixCols];

            var matrixSum = 0;

            for (int row = 0; row < matrixRows; row++)
            {
                var currentCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrixCols; col++)
                {
                    matrix[row, col] = currentCols[col];
                    matrixSum += currentCols[col];
                }
            }

            Console.WriteLine(matrixRows);
            Console.WriteLine(matrixCols);
            Console.WriteLine(matrixSum);

        }
    }
}
