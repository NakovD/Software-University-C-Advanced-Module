using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var matrixRows = input[0];
            var matrixCols = input[1];

            var matrix = new int[matrixRows, matrixCols];

            for (int row = 0; row < matrixRows; row++)
            {
                var currentCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrixCols; col++)
                {
                    matrix[row, col] = currentCols[col];
                }
            }

            for (int col = 0; col < matrixCols; col++)
            {
                var sum = 0;
                for (int row = 0; row < matrixRows; row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
