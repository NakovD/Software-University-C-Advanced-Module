using System;

namespace HelpAMole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new string[matrixSize, matrixSize];
            var mole = new Mole(0, 0);
            var portals = new Portal[2];
            ReadMatrix(matrixSize, matrix, mole, portals);
            ReadCommands(matrix, mole, portals);

            var firstOutput = string.Empty;
            var secondOutput = string.Empty;

            if (mole.MolePoints >= 25)
            {
                firstOutput = "Yay! The Mole survived another game!";
                secondOutput = $"The Mole managed to survive with a total of {mole.MolePoints} points.";
            }
            else
            {
                firstOutput = "Too bad! The Mole lost this battle!";
                secondOutput = $"The Mole lost the game with a total of {mole.MolePoints} points.";
            }

            Console.WriteLine(firstOutput);
            Console.WriteLine(secondOutput);
            PrintMatrix(matrix);
        }

        public static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static void ReadCommands(string[,] matrix, Mole mole, Portal[] portals)
        {
            var command = Console.ReadLine().ToLower();
            if (command == "end" || mole.MolePoints >= 25) return;
            MoveMole(command, matrix, mole, portals);
            ReadCommands(matrix, mole, portals);
        }

        public static void MoveMole(string command, string[,] matrix, Mole mole, Portal[] portals)
        {
            var newRow = 0;
            var newCol = 0;
            switch (command)
            {
                case "up":
                    newRow = mole.MoleRow - 1;
                    newCol = mole.MoleColumn;
                    break;
                case "right":
                    newRow = mole.MoleRow;
                    newCol = mole.MoleColumn + 1;
                    break;
                case "down":
                    newRow = mole.MoleRow + 1;
                    newCol = mole.MoleColumn;
                    break;
                default:
                    newRow = mole.MoleRow;
                    newCol = mole.MoleColumn - 1;
                    break;
            }

            var areCoordinatesValid = ValidateCoordinates(newRow, newCol, matrix);
            if (!areCoordinatesValid) { Console.WriteLine($"Don't try to escape the playing field!"); return; }
            var newCellValue = matrix[newRow, newCol];
            matrix[newRow, newCol] = "M";
            matrix[mole.MoleRow, mole.MoleColumn] = "-";
            mole.MoleRow = newRow;
            mole.MoleColumn = newCol;
            if (newCellValue == "-") return;
            if (newCellValue.ToLower() == "s") { TeleportMole(newRow, newCol, mole, matrix, portals); return; }
            var points = int.Parse(newCellValue);
            mole.MolePoints += points;
        }

        public static void TeleportMole(int currentTeleportRow, int currentTeleportCol, Mole mole, string[,] matrix, Portal[] portals)
        {
            mole.MolePoints -= 3;
            var _newRow = 0;
            var _newCol = 0;

            if (portals[0].PortalRow == currentTeleportRow && portals[0].PortalColumn == currentTeleportCol)
            {
                _newRow = portals[1].PortalRow;
                _newCol = portals[1].PortalColumn;
            }
            else
            {
                _newRow = portals[0].PortalRow;
                _newCol = portals[0].PortalColumn;
            }

            mole.MoleRow = _newRow;
            mole.MoleColumn = _newCol;
            matrix[_newRow, _newCol] = "M";
            matrix[currentTeleportRow, currentTeleportCol] = "-";
        }

        public static bool ValidateCoordinates(int row, int col, string[,] matrix)
        {
            if (row >= matrix.GetLength(0) || row < 0) return false;
            if (col >= matrix.GetLength(1) || col < 0) return false;

            return true;
        }

        static void ReadMatrix(int matrixSize, string[,] matrix, Mole mole, Portal[] portals)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < line.Length; j++)
                {
                    var currentCell = line[j].ToString();
                    matrix[i, j] = currentCell;
                    if (currentCell.ToLower() == "m")
                    {
                        mole.MoleRow = i;
                        mole.MoleColumn = j;
                    }

                    if (currentCell.ToLower() == "s")
                    {
                        var newPortal = new Portal(i, j);
                        if (portals[0] == null) portals[0] = newPortal;
                        portals[1] = newPortal;
                    }
                }
            }
        }
    }

    public class Mole
    {
        public int MolePoints { get; set; }

        public int MoleRow { get; set; }

        public int MoleColumn { get; set; }


        public Mole(int moleRow, int moleColumn)
        {
            MolePoints = 0;
            MoleRow = moleRow;
            MoleColumn = moleColumn;
        }
    }

    public class Portal
    {
        public int PortalRow { get; set; }

        public int PortalColumn { get; set; }
        public Portal(int portalRow, int portalColumn)
        {
            PortalRow = portalRow;
            PortalColumn = portalColumn;
        }
    }
}
