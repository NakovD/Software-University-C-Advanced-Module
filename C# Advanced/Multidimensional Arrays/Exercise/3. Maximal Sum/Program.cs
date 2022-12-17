using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine().Split(" ");
            var matrixRows = int.Parse(matrixSizes[0]);
            var matrixCols = int.Parse(matrixSizes[1]);

            var matrix = new string[matrixRows, matrixCols];

            for (int row = 0; row < matrixRows; row++)
            {
                var currentRowCols = Console.ReadLine().Split(" ");
                for (int col = 0; col < matrixCols; col++)
                {
                    var currentElement = currentRowCols[col];
                    matrix[row, col] = currentElement;
                }
            }


            var input = Console.ReadLine().Split(" ");

            while (!input[0].Contains("END"))
            {
                var command = input[0].ToString();
                if (command != "swap") Console.WriteLine("Invalid input!");
                var coordinates = input.Skip(1).ToArray();
                var _input = input;
                input = Console.ReadLine().Split(" ");
                if (coordinates.Length != 4) { Console.WriteLine("Invalid input!"); continue; };
                var firstCellRow = int.Parse(_input[1]);
                var firstCellCol = int.Parse(_input[2]);
                var secondCellRow = int.Parse(_input[3]);
                var secondCellCol = int.Parse(_input[4]);
                var areCellsCoordinatesValid = ValidateCoordinates(coordinates, matrixRows, matrixCols);
                if (!areCellsCoordinatesValid) { Console.WriteLine("Invalid input!"); continue; }
                var firstValue = matrix[firstCellRow, firstCellCol];
                var secondValue = matrix[secondCellRow, secondCellCol];

                matrix[firstCellRow, firstCellCol] = secondValue;
                matrix[secondCellRow, secondCellCol] = firstValue;
                PrintMatrix(matrix);
                
            }
        }
        static void PrintMatrix(string [,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        static bool ValidateCoordinates(string[] coordinates, int matrixRows, int matrixCols)
        {
            var firstCellRow = int.Parse(coordinates[0]);
            var firstCellCol = int.Parse(coordinates[1]);
            var secondCellRow = int.Parse(coordinates[2]);
            var secondCellCol = int.Parse(coordinates[3]);

            var firstCellRowValidation = firstCellRow > matrixRows || firstCellRow < 0;
            var firstCellColValidation = firstCellCol > matrixCols || firstCellCol < 0;
            var secondCellRowValidation = secondCellRow > matrixRows || secondCellRow < 0;
            var secondCellColValidation = secondCellCol > matrixCols || secondCellCol < 0;

            if (firstCellRowValidation || firstCellColValidation || secondCellRowValidation || secondCellColValidation) return false;

            return true;
        }
    }
}
