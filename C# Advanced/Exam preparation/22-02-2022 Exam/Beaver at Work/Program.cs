using System;
using System.Collections.Generic;
using System.Linq;

namespace Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new string[matrixSize, matrixSize];
            var beaver = new Beaver();

            ReadMatrix(matrix, beaver);

            ReadCommands(matrix, beaver);

            if (beaver.AllWoodBranches > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {beaver.AllWoodBranches} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {beaver.WoodCollected.Count} wood branches: {string.Join(", ", beaver.WoodCollected)}.");
            }

            PrintMatrix(matrix);

        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                    if (col != matrix.GetLength(1) - 1) Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static void ReadCommands(string[,] matrix, Beaver beaver)
        {
            var currentCommand = Console.ReadLine().Trim().ToLower();

            if (currentCommand == "end" || beaver.AllWoodBranches == 0) return;

            (int nextRow, int nextCol) = GetNextCellCoordinates(currentCommand, beaver);
            MoveBeaver(nextRow, nextCol, currentCommand, matrix, beaver);

            ReadCommands(matrix, beaver);

        }

        private static void MoveBeaver(int nextRow, int nextCol, string direction, string[,] matrix, Beaver beaver)
        {
            var areCoordinatesValid = ValidateCoordinates(nextRow, nextCol, matrix.GetLength(0));
            if (!areCoordinatesValid)
            {
                if (beaver.WoodCollected.Count > 0)
                {
                    beaver.WoodCollected.RemoveAt(beaver.WoodCollected.Count - 1);
                }
                return;
            }
            var cellValue = matrix[nextRow, nextCol];
            if (cellValue == "-") { UpdateBeaverCoordinates(beaver, nextRow, nextCol, matrix); return; }
            if (cellValue == "F") { SwimBeaver((nextRow, nextCol), direction, beaver, matrix); return; }
            beaver.WoodCollected.Add(cellValue);
            beaver.AllWoodBranches--;
            UpdateBeaverCoordinates(beaver, nextRow, nextCol, matrix);
        }

        private static void SwimBeaver((int nextRow, int nextCol) value, string direction, Beaver beaver, string[,] matrix)
        {
            UpdateBeaverCoordinates(beaver, value.nextRow, value.nextCol, matrix);
            (int newBeaverRow, int newBeaverCol) = GetCoordinatesAfterSwimming(value.nextRow, value.nextCol, direction, matrix.GetLength(0));
            var newCellValue = matrix[newBeaverRow, newBeaverCol];
            UpdateBeaverCoordinates(beaver, newBeaverRow, newBeaverCol, matrix);
            if (newCellValue == "-") return;
            beaver.WoodCollected.Add(newCellValue);
            beaver.AllWoodBranches--;
        }

        private static (int newBeaverRow, int newBeaverCol) GetCoordinatesAfterSwimming(int nextRow, int nextCol, string direction, int matrixSize)
        {
            if (direction == "right")
            {
                if (nextCol == matrixSize - 1) return (nextRow, 0);
                return (nextRow, matrixSize - 1);
            }
            else if (direction == "left")
            {
                if (nextCol == 0) return (nextRow, matrixSize - 1);
                return (nextRow, 0);
            }
            else if (direction == "down")
            {
                if (nextRow == matrixSize - 1) return (0, nextCol);
                return (matrixSize - 1, nextCol);
            }
            else
            {
                if (nextRow == 0) return (matrixSize - 1, nextCol);
                return (0, nextCol);
            }
        }

        private static void UpdateBeaverCoordinates(Beaver beaver, int nextRow, int nextCol, string[,] matrix)
        {
            matrix[beaver.Row, beaver.Col] = "-";
            beaver.Row = nextRow;
            beaver.Col = nextCol;
            matrix[nextRow, nextCol] = "B";
        }

        private static bool ValidateCoordinates(int nextRow, int nextCol, int matrixLength)
        {
            if (nextRow < 0 || nextCol < 0) return false;
            if (nextRow >= matrixLength || nextCol >= matrixLength) return false;
            return true;
        }

        private static (int, int) GetNextCellCoordinates(string currentCommand, Beaver beaver)
        {
            switch (currentCommand)
            {
                case "up": return (beaver.Row - 1, beaver.Col);
                case "right": return (beaver.Row, beaver.Col + 1);
                case "down": return (beaver.Row + 1, beaver.Col);
                default: return (beaver.Row, beaver.Col - 1);
            }
        }

        private static void ReadMatrix(string[,] matrix, Beaver beaver)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var currentCellValue = currentLine[col];
                    matrix[row, col] = currentCellValue;
                    if (currentCellValue == "B")
                    {
                        beaver.Row = row;
                        beaver.Col = col;
                        continue;
                    }
                    if (currentCellValue != "F" && currentCellValue != "-") beaver.AllWoodBranches++;
                }
            }
        }
    }


    public class Beaver
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public List<string> WoodCollected { get; set; }

        public int AllWoodBranches { get; set; }

        public Beaver()
        {
            Row = 0;
            Col = 0;
            WoodCollected = new List<string>();
            AllWoodBranches = 0;
        }
    }
}
