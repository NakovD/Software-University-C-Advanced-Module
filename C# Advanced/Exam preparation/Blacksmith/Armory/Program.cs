using System;

namespace Armory
{
    internal class Program
    {
        private static int matrixSize;

        private static string[,] matrix;

        private static ArmyOfficer officer;

        private static Mirror firstMirror;

        private static Mirror secondMirror;

        private static bool gameOver = false;

        static void Main(string[] args)
        {
            var _matrixSize = int.Parse(Console.ReadLine());
            matrixSize = _matrixSize;

            ReadMatrix();

            ReadCommands();

            if (gameOver)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }

            Console.WriteLine($"The king paid {officer.CoinsForSwords} gold coins.");
            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void ReadCommands()
        {
            if (gameOver || officer.CoinsForSwords >= 65) return;

            var command = Console.ReadLine();

            MoveOfficer(command);
            ReadCommands();
        }

        private static void MoveOfficer(string command)
        {
            (int nextRow, int nextCol) = GetNextCoordinates(command);
            var areCoordinatesValid = ValidateCoordinates(nextRow, nextCol);
            if (!areCoordinatesValid)
            {
                gameOver = true;
                matrix[officer.Row, officer.Col] = "-";
                return;
            }
            var nextCoordinatesValue = matrix[nextRow, nextCol];
            UpdateOfficerCoordinates(nextRow, nextCol);
            if (nextCoordinatesValue == "-") return;
            if (nextCoordinatesValue == "M") { TeleportOfficer(); return; }
            int.TryParse(nextCoordinatesValue, out int swordValue);
            officer.CoinsForSwords += swordValue;
        }

        private static void TeleportOfficer()
        {
            if (officer.Row == firstMirror.Row && officer.Col == firstMirror.Col)
            {
                UpdateOfficerCoordinates(secondMirror.Row, secondMirror.Col);
                return;
            }

            UpdateOfficerCoordinates(firstMirror.Row, firstMirror.Col);

        }

        private static void UpdateOfficerCoordinates(int nextRow, int nextCol)
        {
            matrix[nextRow, nextCol] = "A";
            matrix[officer.Row, officer.Col] = "-";
            officer.Row = nextRow;
            officer.Col = nextCol;
        }

        private static bool ValidateCoordinates(int nextRow, int nextCol)
        {
            if (nextRow < 0 || nextRow >= matrixSize) return false;
            if (nextCol < 0 || nextCol >= matrixSize) return false;
            return true;
        }

        private static (int nextRow, int nextCol) GetNextCoordinates(string command)
        {
            command = command.ToLower();
            switch (command)
            {
                case "up": return (officer.Row - 1, officer.Col);
                case "down": return (officer.Row + 1, officer.Col);
                case "right": return (officer.Row, officer.Col + 1);
                default: return (officer.Row, officer.Col - 1);
            }
        }

        private static void ReadMatrix()
        {
            matrix = new string[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                var currentLine = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    var currentSymbol = currentLine[col].ToString();
                    matrix[row, col] = currentSymbol;
                    if (currentSymbol == "A") officer = new ArmyOfficer(row, col);
                    if (currentSymbol == "M" && firstMirror == null) firstMirror = new Mirror(row, col);
                    if (currentSymbol == "M") secondMirror = new Mirror(row, col);
                }
            }
        }
    }

    public class Mirror
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Mirror(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }

    public class ArmyOfficer
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int CoinsForSwords { get; set; }

        public ArmyOfficer(int row, int col)
        {
            Row = row;
            Col = col;
            CoinsForSwords = 0;
        }
    }
}
