using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixRows = int.Parse(Console.ReadLine());
            var matrix = new int[matrixRows, matrixRows];
            var diagonalSum = 0;

            for (int row = 0; row < matrixRows; row++)
            {
                var cols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols.Length; col++)
                {
                    matrix[row, col] = cols[col];
                    if (row == col) diagonalSum += cols[col];
                }
            }

            Console.WriteLine(diagonalSum);
        }
    }
}
