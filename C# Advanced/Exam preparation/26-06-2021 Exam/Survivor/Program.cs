using System;

namespace Survivor
{
    internal class Program
    {
        private static int matrixSize;

        private static string[][] jaggedArray;

        private static int playerTokens = 0;

        private static int opponentTokens = 0;

        static void Main(string[] args)
        {
            var _beachSize = int.Parse(Console.ReadLine());
            matrixSize = _beachSize;

            ReadMatrix();

            ReadCommands();

            PrintMatrix();

            Console.WriteLine($"Collected tokens: {playerTokens}");

            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static void ReadCommands()
        {
            var currentCommand = Console.ReadLine().ToLower();
            if (currentCommand == "gong") return;
            var isPlayerTurn = currentCommand.Contains("find");

            if (isPlayerTurn) ExecutePlayerTurn(currentCommand);
            else ExecuteOpponentTurn(currentCommand);

            ReadCommands();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                Console.WriteLine(String.Join(" ", jaggedArray[row]));
            }
        }

        private static void ExecuteOpponentTurn(string command)
        {
            var commandData = command.Split(" ");
            var row = int.Parse(commandData[1]);
            var col = int.Parse(commandData[2]);
            var direction = commandData[3];
            var areCoordinatesValid = ValidateCoordinates(row, col);
            if (!areCoordinatesValid) return;
            var cellValue = jaggedArray[row][col];
            if (cellValue == "T")
            {
                opponentTokens += 1;
                jaggedArray[row][col] = "-";
            }
            ExecuteOpponentAdditionalMoves(direction, row, col);
        }

        private static void ExecuteOpponentAdditionalMoves(string direction, int row, int col)
        {
            for (int index = 1; index < 4; index++)
            {
                (int nextRow, int nextCol) = GetNextCellCoordinates(direction, row, col);
                var areCoordinatesValid = ValidateCoordinates(nextRow, nextCol);
                if (!areCoordinatesValid) continue;
                var nextCellValue = jaggedArray[nextRow][nextCol];
                if (nextCellValue == "T")
                {
                    opponentTokens += 1;
                    jaggedArray[nextRow][nextCol] = "-";
                }
                row = nextRow;
                col = nextCol;
            }
        }

        private static (int nextRow, int nextCol) GetNextCellCoordinates(string direction, int row, int col)
        {
            switch (direction)
            {
                case "up": return (row - 1, col);
                case "down": return (row + 1, col);
                case "right": return (row, col + 1);
                default: return (row, col - 1);
            }
        }

        private static void ExecutePlayerTurn(string command)
        {
            var commandData = command.Split(" ");
            var row = int.Parse(commandData[1]);
            var col = int.Parse(commandData[2]);
            var areCoordinatesValid = ValidateCoordinates(row, col);
            if (!areCoordinatesValid) return;
            var cellValue = jaggedArray[row][col];
            if (cellValue == "T")
            {
                playerTokens += 1;
                jaggedArray[row][col] = "-";
            }
        }

        private static bool ValidateCoordinates(int row, int col)
        {
            if (row < 0 || row >= matrixSize) return false;
            var neededColArray = jaggedArray[row];
            if (col < 0 || col >= neededColArray.Length) return false;
            return true;
        }

        private static void ReadMatrix()
        {
            jaggedArray = new string[matrixSize][];

            for (int row = 0; row < matrixSize; row++)
            {
                var currentRow = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                jaggedArray[row] = currentRow;
            }
        }
    }
}
