using System;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Read input data and fill the field
            var fieldSize = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine().Split(" ");
            var field = new string[fieldSize, fieldSize];
            var coalsAmount = 0;
            var coalsCollected = 0;
            Cell playerCoordinates = null;

            for (int fieldRow = 0; fieldRow < fieldSize; fieldRow++)
            {
                var currentRowColumns = Console.ReadLine().Split(" ");

                for (int fieldCol = 0; fieldCol < fieldSize; fieldCol++)
                {
                    var currentCell = currentRowColumns[fieldCol];
                    if (currentCell.ToLower() == "c") coalsAmount++;
                    if (currentCell.ToLower() == "s") playerCoordinates = new Cell(fieldRow, fieldCol);
                    field[fieldRow, fieldCol] = currentCell;
                }
            }

            #endregion

            #region Start reading the commands
            for (int i = 0; i < commands.Length; i++)
            {
                var currentCommand = commands[i];
                var nextCellCoordinates = GetNextCellCoordinates(playerCoordinates, currentCommand, field);
                if (nextCellCoordinates == null) continue;
                var nextCellValue = field[nextCellCoordinates.RowIndex, nextCellCoordinates.ColIndex].ToLower();
                playerCoordinates = nextCellCoordinates;
                if (nextCellValue == "*" || nextCellValue == "s") continue;
                if (nextCellValue == "c")
                {
                    coalsCollected++;
                    field[nextCellCoordinates.RowIndex, nextCellCoordinates.ColIndex] = "*";
                    if (coalsAmount == coalsCollected)
                    {
                        Console.WriteLine($"You collected all coals! ({nextCellCoordinates.RowIndex}, {nextCellCoordinates.ColIndex})");
                        return;
                    }
                    continue;
                }

                Console.WriteLine($"Game over! ({nextCellCoordinates.RowIndex}, {nextCellCoordinates.ColIndex})");
                return;

            }
            #endregion

            Console.WriteLine($"{coalsAmount - coalsCollected} coals left. ({playerCoordinates.RowIndex}, {playerCoordinates.ColIndex})");
        }
        #nullable enable
        static Cell? GetNextCellCoordinates(Cell currentPlayerCoordinates, string command, string[,] field)
        {
            var possibleRowIndex = 0;
            var possibleColIndex = 0;

            switch (command.ToLower())
            {
                case "up":
                    possibleRowIndex = currentPlayerCoordinates.RowIndex - 1;
                    possibleColIndex = currentPlayerCoordinates.ColIndex;
                    break;
                case "right":
                    possibleRowIndex = currentPlayerCoordinates.RowIndex;
                    possibleColIndex = currentPlayerCoordinates.ColIndex + 1;
                    break;
                case "down":
                    possibleRowIndex = currentPlayerCoordinates.RowIndex + 1;
                    possibleColIndex = currentPlayerCoordinates.ColIndex;
                    break;
                default:
                    possibleRowIndex = currentPlayerCoordinates.RowIndex;
                    possibleColIndex = currentPlayerCoordinates.ColIndex - 1;
                    break;
            }

            var areCoordinatesValid = ValidateCellCoordinates(possibleRowIndex, possibleColIndex, field);
            return areCoordinatesValid ? new Cell(possibleRowIndex, possibleColIndex) : null;
        }

        static bool ValidateCellCoordinates(int row, int col, string[,] field)
        {
            if (row < 0 || col < 0) return false;
            if (row >= field.GetLength(0) || col >= field.GetLength(1)) return false;
            return true;
        }
    }

    class Cell
    {
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }

        public Cell(int row, int col)
        {
            this.RowIndex = row;
            this.ColIndex = col;
        }
    }
}
