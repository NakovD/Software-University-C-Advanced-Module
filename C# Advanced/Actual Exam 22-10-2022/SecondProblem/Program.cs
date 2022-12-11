using System;

namespace SecondProblem
{
    internal class Program
    {
        private static string[,] matrix;

        private static int matrixSize;

        private static int totalKm = 0;

        private static Tunnel firstTunnel;

        private static Tunnel secondTunnel;

        private static Player player = new Player(0, 0);

        private static bool gameOver = false;

        static void Main(string[] args)
        {
            var _matrixSize = int.Parse(Console.ReadLine());

            var racingCarNumber = Console.ReadLine();

            matrixSize = _matrixSize;

            ReadMatrix();

            ReadCommands();

            matrix[player.Row, player.Col] = "C";

            if (gameOver)
            {
                Console.WriteLine($"Racing car {racingCarNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingCarNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {totalKm} km.");

            PrintMatrix();
        }

        private static void ReadCommands()
        {
            var currentCommand = Console.ReadLine().ToLower();

            if (currentCommand == "end" || gameOver) return;

            MoveCar(currentCommand);

            ReadCommands();
        }

        private static void MoveCar(string command)
        {
            (int nextRow, int nextCol) = GetNextCellCoordinates(command);
            var areCoordinatesValid = ValidateCoordinates(nextRow, nextCol);
            if (!areCoordinatesValid) return;
            var cellValue = matrix[nextRow, nextCol];
            UpdateCarCoordinates(nextRow, nextCol);
            totalKm += 10;
            if (cellValue == ".") return;
            if (cellValue == "F") { 
                gameOver = true;
                return;
            }
            if (cellValue == "T") { MoveCarThroughTunnel(nextRow, nextCol); }
        }

        private static void MoveCarThroughTunnel(int nextRow, int nextCol)
        {
            totalKm += 20;
            if (firstTunnel.Row == nextRow && firstTunnel.Col == nextCol)
            {
                UpdateCarCoordinates(secondTunnel.Row, secondTunnel.Col);
            }
            else
            {
                UpdateCarCoordinates(firstTunnel.Row, firstTunnel.Col);
            }
        }

        private static void UpdateCarCoordinates(int nextRow, int nextCol)
        {
            matrix[player.Row, player.Col] = ".";
            player.Row = nextRow;
            player.Col = nextCol;
        }

        private static bool ValidateCoordinates(int nextRow, int nextCol)
        {
            if (nextRow < 0 || nextRow >= matrixSize) return false;
            if (nextCol < 0 || nextCol >= matrixSize) return false;
            return true;
        }

        private static (int nextRow, int nextCol) GetNextCellCoordinates(string command)
        {
            command = command.ToLower();

            switch (command)
            {
                case "up": return (player.Row - 1, player.Col);
                case "down": return (player.Row + 1, player.Col);
                case "right": return (player.Row, player.Col + 1);
                default: return (player.Row, player.Col - 1);
            }
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

        private static void ReadMatrix()
        {
            matrix = new string[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                var currentRowValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrixSize; col++)
                {
                    var currentValue = currentRowValues[col].ToString();
                    matrix[row, col] = currentValue;
                    if (currentValue == "T" && firstTunnel == null)
                    {
                        firstTunnel = new Tunnel(row, col);
                    }
                    if (currentValue == "T" && firstTunnel != null)
                    {
                        secondTunnel = new Tunnel(row, col);
                    }

                }
            }
        }
    }

    public class Tunnel
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Tunnel(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }

    public class Player
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Player(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
