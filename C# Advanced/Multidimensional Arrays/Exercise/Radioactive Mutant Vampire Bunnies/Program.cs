using System;
using System.Collections.Generic;
using System.Linq;

namespace Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Read input data

            var lairDimensions = Console.ReadLine().Split(" ");
            var lairRows = int.Parse(lairDimensions[0]);
            var lairCols = int.Parse(lairDimensions[1]);
            var lair = new string[lairRows, lairCols];
            var rabbitsCoordinates = new List<Cell>();
            Cell playerCoordinates = null;

            #endregion

            #region Fill lair

            for (int row = 0; row < lairRows; row++)
            {
                var currentRowColumns = Console.ReadLine();

                for (int col = 0; col < currentRowColumns.Length; col++)
                {
                    var currentColValue = currentRowColumns[col].ToString();
                    if (currentColValue == "B") rabbitsCoordinates.Add(new Cell(row, col));
                    if (currentColValue == "P")
                    {
                        currentColValue = ".";
                        playerCoordinates = new Cell(row, col);
                    }
                    lair[row, col] = currentColValue;
                }
            }

            #endregion

            #region Read player turns

            var commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                var currentCommand = commands[i].ToString();
                var nextCellCoordinates = GetNextCell(currentCommand, playerCoordinates, lair);
                if (nextCellCoordinates == null)
                {
                    SpreadBunnies(ref rabbitsCoordinates, lair, null);
                    PrintLair(lair);
                    Console.WriteLine($"won: {playerCoordinates.RowIndex} {playerCoordinates.Colindex}");
                    break;
                }
                var nextCellValue = lair[nextCellCoordinates.RowIndex, nextCellCoordinates.Colindex];
                playerCoordinates = nextCellCoordinates;
                if (nextCellValue == "B")
                {
                    SpreadBunnies(ref rabbitsCoordinates, lair, null);
                    PlayerLost(lair, playerCoordinates);
                    break;
                }
                var hasBunniesReachedThePlayer = SpreadBunnies(ref rabbitsCoordinates, lair, playerCoordinates);
                if (!hasBunniesReachedThePlayer) continue;
                PlayerLost(lair, playerCoordinates);
                break;
            }

            #endregion
        }
        #nullable enable
        static bool SpreadBunnies(ref List<Cell> rabbitsCoordinates, string[,] lair, Cell? playerCoordinates)
        {
            var newRabbitsCoordinates = new List<Cell>();
            var bunniesReachedThePlayer = false;

            foreach (var rabbitCell in rabbitsCoordinates)
            {
                var allSpreadCells = new List<Cell> {
                    new Cell(rabbitCell.RowIndex - 1, rabbitCell.Colindex),
                    new Cell(rabbitCell.RowIndex, rabbitCell.Colindex + 1),
                    new Cell(rabbitCell.RowIndex + 1, rabbitCell.Colindex),
                    new Cell(rabbitCell.RowIndex, rabbitCell.Colindex - 1)
                    };

                foreach (var spreadCell in allSpreadCells)
                {
                    var isCurrentCellValid = ValidateCellCoordinates(spreadCell.RowIndex, spreadCell.Colindex, lair);
                    if (!isCurrentCellValid) continue;
                    var isRabbitAlreadyAdded = newRabbitsCoordinates.Any(spreadedCell => spreadedCell.RowIndex == spreadCell.RowIndex && spreadedCell.Colindex == spreadCell.Colindex);
                    if (isRabbitAlreadyAdded) continue;
                    newRabbitsCoordinates.Add(spreadCell);
                    lair[spreadCell.RowIndex, spreadCell.Colindex] = "B";
                    if (playerCoordinates == null) continue;
                    var isPlayerInThisCell = playerCoordinates.RowIndex == spreadCell.RowIndex && playerCoordinates.Colindex == spreadCell.Colindex;
                    if (isPlayerInThisCell) bunniesReachedThePlayer = true;
                }
            }

            rabbitsCoordinates = newRabbitsCoordinates;

            return bunniesReachedThePlayer;
        }
        #nullable enable
        static Cell? GetNextCell(string command, Cell currentPlayerCoordinates, string[,] lair)
        {
            Cell? possibleNextCell = null;

            switch (command)
            {
                case "U":
                    possibleNextCell = new Cell(currentPlayerCoordinates.RowIndex - 1, currentPlayerCoordinates.Colindex);
                    break;
                case "R":
                    possibleNextCell = new Cell(currentPlayerCoordinates.RowIndex, currentPlayerCoordinates.Colindex + 1);
                    break;
                case "D":
                    possibleNextCell = new Cell(currentPlayerCoordinates.RowIndex + 1, currentPlayerCoordinates.Colindex);
                    break;
                default:
                    possibleNextCell = new Cell(currentPlayerCoordinates.RowIndex, currentPlayerCoordinates.Colindex - 1);
                    break;
            }

            var isPlayerInTheLair = ValidateCellCoordinates(possibleNextCell.RowIndex, possibleNextCell.Colindex, lair);

            //if the next cell coordinates are outside the lair(invalid) the player has won and the game will stop. If they are valid he is still in the lair and the game continues

            return isPlayerInTheLair ? possibleNextCell : null;
        }

        static bool ValidateCellCoordinates(int row, int col, string[,] lair)
        {
            if (row < 0 || col < 0) return false;
            if (row >= lair.GetLength(0) || col >= lair.GetLength(1)) return false;
            return true;
        }

        static void PrintLair(string[,] lair)
        {
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void PlayerLost(string[,] lair, Cell playerCoordinates)
        {
            PrintLair(lair);
            Console.WriteLine($"dead: {playerCoordinates.RowIndex} {playerCoordinates.Colindex}");
        }
    }

    class Cell
    {
        public int RowIndex { get; set; }
        public int Colindex { get; set; }

        public Cell(int row, int col)
        {
            this.RowIndex = row;
            this.Colindex = col;
        }
    }
}
