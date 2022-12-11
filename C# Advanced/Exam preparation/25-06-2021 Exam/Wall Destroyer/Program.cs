using System;
using System.Collections.Generic;

namespace Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new string[matrixSize, matrixSize];
            var player = ReadMatrix(matrix);
            ReadCommands(player, matrix);

            if (player.Electrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {player.Holes} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {player.Holes} hole(s) and he hit only {player.RodsHit} rod(s).");
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
                }
                Console.WriteLine();
            }
        }

        private static void ReadCommands(Player player, string[,] matrix)
        {
            var currentCommand = Console.ReadLine().ToLower();
            if (currentCommand == "end" || player.Electrocuted) return;
            MoveVanko(player, matrix, currentCommand);
            ReadCommands(player, matrix);
        }

        private static void MoveVanko(Player player, string[,] matrix, string command)
        {
            var nextRow = 0;
            var nextCol = 0;
            switch (command)
            {
                case "up":
                    nextRow = player.Row - 1;
                    nextCol = player.Col;
                    break;
                case "right":
                    nextRow = player.Row;
                    nextCol = player.Col + 1;
                    break;
                case "down":
                    nextRow = player.Row + 1;
                    nextCol = player.Col;
                    break;
                default:
                    nextRow = player.Row;
                    nextCol = player.Col - 1;
                    break;
            }
            var areCoordinatesValid = ValidateCoordinates(nextRow, nextCol, matrix);
            if (!areCoordinatesValid) return;
            var newCellValue = matrix[nextRow, nextCol].ToLower();
            if (newCellValue == "r") { Console.WriteLine("Vanko hit a rod!"); player.RodsHit++; return; }
            if (newCellValue == "*")
            {
                Console.WriteLine($"The wall is already destroyed at position [{nextRow}, {nextCol}]!");
                matrix[player.Row, player.Col] = "*";
                UpdatePlayerCoordinates(player, nextRow, nextCol);
                matrix[nextRow, nextCol] = "V";
                return;
            }
            if (newCellValue == "c") { player.Electrocuted = true; matrix[nextRow, nextCol] = "E"; }
            else matrix[nextRow, nextCol] = "V";
            matrix[player.Row, player.Col] = "*";
            player.Holes += 1;
            UpdatePlayerCoordinates(player, nextRow, nextCol);
        }

        private static void UpdatePlayerCoordinates(Player player, int nextRow, int nextCol)
        {
            player.Row = nextRow;
            player.Col = nextCol;
        }

        private static bool ValidateCoordinates(int nextRow, int nextCol, string[,] matrix)
        {
            if (nextRow < 0 || nextCol < 0) return false;
            if (nextRow >= matrix.GetLength(0) || nextCol >= matrix.GetLength(1)) return false;
            return true;
        }

        public static Player ReadMatrix(string[,] matrix)
        {
            var player = new Player(0, 0);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentLine = Console.ReadLine().ToCharArray();
                for (int col = 0; col < currentLine.Length; col++)
                {
                    var currentSymbol = currentLine[col].ToString();
                    matrix[row, col] = currentSymbol;
                    currentSymbol = currentSymbol.ToLower();
                    if (currentSymbol == "v")
                    {
                        player.Row = row;
                        player.Col = col;
                    }

                    if (currentSymbol == "-") player.TotalHoles += 1;
                }
            }

            return player;
        }
    }

    public class Cable
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Cable(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }

    public class Rod
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Rod(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }

    public class Player
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public bool Electrocuted { get; set; }

        public int RodsHit { get; set; }

        public int Holes { get; set; }

        public int TotalHoles { get; set; }

        public Player(int row, int col)
        {
            Row = row;
            Col = col;
            this.Electrocuted = false;
            this.Holes = 1;
            this.RodsHit = 0;
            this.TotalHoles = 0;
        }
    }
}
