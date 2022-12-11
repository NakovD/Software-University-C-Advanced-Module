using System;
using System.Linq;

namespace TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new string[matrixSize, matrixSize];
            var boarEatenTruffles = 0;
            var trufflesState = new Truffles();
            ReadMatrix(matrix);
            ReadCommands(matrix, trufflesState, ref boarEatenTruffles);

            Console.WriteLine($"Peter manages to harvest {trufflesState.BlackTruffles} black, {trufflesState.SummerTruffles} summer, and {trufflesState.WhiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarEatenTruffles} truffles.");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(string[,] matrix)
        {
            var matrixRows = matrix.GetLength(0);
            var matrixCols = matrix.GetLength(1);

            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixCols; col++)
                {
                    Console.Write(matrix[row, col]);
                    if (col + 1 != matrixCols) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static void ReadCommands(string[,] matrix, Truffles trufflesState, ref int eatenTruffles)
        {
            var command = Console.ReadLine();

            if (command == "Stop the hunt") return;

            var arguments = command.Split(" ").Skip(1).ToArray();

            var row = int.Parse(arguments[0]);
            var col = int.Parse(arguments[1]);

            if (command.Contains("Collect"))
            {
                CollectTruffle(row, col, trufflesState, matrix);
            }

            if (command.Contains("Wild_Boar"))
            {
                var direction = arguments[2];
                MoveBoar(row, col, direction, ref eatenTruffles, matrix);
            }

            ReadCommands(matrix, trufflesState, ref eatenTruffles);
        }

        private static void MoveBoar(int row, int col, string direction, ref int eatenTruffles, string[,] matrix)
        {


            if (direction == "up" || direction == "down")
            {
                if (direction == "up")
                {
                    for (int i = row; i >= 0; i -= 2)
                    {
                        EatTruffle(i, col, matrix, ref eatenTruffles);
                        if (i - 2 < 0) break;
                    }
                }
                else
                {
                    for (int i = row; i < matrix.GetLength(0); i += 2)
                    {
                        EatTruffle(i, col, matrix, ref eatenTruffles);
                        if (i + 2 >= matrix.GetLength(0)) break;
                    }
                }
            }
            else
            {
                if (direction == "left")
                {
                    for (int i = col; i >= 0; i -= 2)
                    {
                        EatTruffle(row, i, matrix, ref eatenTruffles);
                        if (i - 2 < 0) break;
                    }
                }
                else
                {
                    for (int i = col; i < matrix.GetLength(1); i += 2)
                    {
                        EatTruffle(row, i, matrix, ref eatenTruffles);
                        if (i + 2 >= matrix.GetLength(0)) break;
                    }
                }
            }




        }

        private static void EatTruffle(int row, int col, string[,] matrix, ref int eatenTruffles)
        {
            var currentCellValue = matrix[row, col];
            if (currentCellValue == "B" || currentCellValue == "S" || currentCellValue == "W")
            {
                matrix[row, col] = "-";
                eatenTruffles++;
            }
        }

        private static void CollectTruffle(int row, int col, Truffles trufflesState, string[,] matrix)
        {
            var areCoordinatesValid = ValidateCoordinates(row, col, matrix);
            if (!areCoordinatesValid) return;
            var cellValue = matrix[row, col];
            if (cellValue == "-") return;
            if (cellValue == "B") trufflesState.BlackTruffles++;
            if (cellValue == "S") trufflesState.SummerTruffles++;
            if (cellValue == "W") trufflesState.WhiteTruffles++;
            matrix[row, col] = "-";
        }

        private static bool ValidateCoordinates(int row, int col, string[,] matrix)
        {
            if (row < 0 || col < 0) return false;
            if (row > matrix.GetLength(0) || col > matrix.GetLength(1)) return false;

            return true;
        }

        private static void ReadMatrix(string[,] matrix)
        {
            var matrixRowLength = matrix.GetLength(0);
            var matrixColLength = matrix.GetLength(1);

            for (int row = 0; row < matrixRowLength; row++)
            {
                var currentCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrixColLength; col++)
                {
                    matrix[row, col] = currentCol[col].ToString();
                }
            }
        }
    }

    public class Truffles
    {
        public int BlackTruffles { get; set; }

        public int SummerTruffles { get; set; }

        public int WhiteTruffles { get; set; }

        public Truffles()
        {
            BlackTruffles = 0;
            SummerTruffles = 0;
            WhiteTruffles = 0;
        }
    }
}
