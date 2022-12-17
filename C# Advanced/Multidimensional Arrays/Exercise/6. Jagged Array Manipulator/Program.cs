using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Read input and fill the jagged array 
            var rows = int.Parse(Console.ReadLine());
            var jaggedArr = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentColumns = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                jaggedArr[row] = currentColumns;
            }
            #endregion

            #region Analyze the jagged array
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                var currentRow = jaggedArr[row];
                var nextRowIndex = row + 1;
                if (nextRowIndex == jaggedArr.Length) break; //we reached the last row, so break is fine
                var nextRow = jaggedArr[nextRowIndex];
                if (currentRow.Length == nextRow.Length)
                {
                    jaggedArr[row] = currentRow.Select(num => num * 2).ToArray();
                    jaggedArr[nextRowIndex] = nextRow.Select(num => num * 2).ToArray();
                    continue;
                }
                jaggedArr[row] = currentRow.Select(num => num / 2).ToArray();
                jaggedArr[nextRowIndex] = nextRow.Select(num => num / 2).ToArray();
            }
            #endregion

            #region Read commands
            var input = Console.ReadLine();

            while (!input.Contains("End"))
            {
                var _input = input.Split(" ");
                var command = _input[0];
                var row = int.Parse(_input[1]);
                var col = int.Parse(_input[2]);
                var value = int.Parse(_input[3]);
                var areCoordinatesValid = ValidateMatrixCoordinates(jaggedArr, row, col);
                input = Console.ReadLine();

                if (!areCoordinatesValid) continue;     //continue if the coordinates are invalid

                var neededElement = jaggedArr[row][col];

                if (command == "Add")
                {
                    var addedValue = neededElement + value;
                    jaggedArr[row][col] = addedValue;
                    continue;
                }

                //If the code reaches here we know this is substract command
                var substractedValue = neededElement - value;
                jaggedArr[row][col] = substractedValue;
            }

            #endregion

            #region Printing final jagged array
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                var currentRowColumns = string.Join(" ", jaggedArr[row]);
                Console.WriteLine(currentRowColumns);
            }
            #endregion
        }

        static bool ValidateMatrixCoordinates(int[][] jaggedArr, int row, int col)
        {
            if (row < 0 || col < 0) return false;

            if (row >= jaggedArr.Length) return false;

            var neededArr = jaggedArr[row];

            if (col >= neededArr.Length) return false;

            return true;
        }
    }
}
