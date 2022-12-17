using System;

namespace TheBattleofTheFiveArmies
{
    internal class Program
    {
        private static Army army;

        private static int matrixSize;

        private static char[,] matrix;

        private static bool gameOver = false;

        private static bool hasReachedMordod = false;

        static void Main(string[] args)
        {
            var armyArmor = int.Parse(Console.ReadLine());
            var matrixRows = int.Parse(Console.ReadLine());

            matrixSize = matrixRows;

            army = new Army(armyArmor, 0, 0);

            ReadMatrix();

            ReadCommands();

            if (army.Armor <= 0 && !hasReachedMordod)
            {
                Console.WriteLine($"The army was defeated at {army.Row};{army.Col}.");
            }
            else
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {army.Armor}");
            }


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
            if (gameOver || army.Armor <= 0) return;

            var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (commands.Length == 0) ReadCommands();
            else
            {
                var direction = commands[0];
                var spawnCoordinates = (int.Parse(commands[1]), int.Parse(commands[2]));

                SpawnEnemy(spawnCoordinates);

                MoveArmy(direction);

                ReadCommands();
            }
        }

        private static void MoveArmy(string direction)
        {
            (int nextRow, int nextCol) = GetCoordinates(direction);
            var areCoordinatesValid = ValidateCoordinates(nextRow, nextCol);
            army.Armor--;
            if (!areCoordinatesValid || string.IsNullOrEmpty(matrix[nextRow, nextCol].ToString())) return;
            var nextCellValue = matrix[nextRow, nextCol];
            UpdateArmyCoordinates(nextRow, nextCol);
            if (nextCellValue == '-') return;
            if (nextCellValue == 'O') { BattleOrcs(); return; }
            if (nextCellValue == 'M') { WinGame(); return; }

        }

        private static void WinGame()
        {
            gameOver = true;
            matrix[army.Row, army.Col] = '-';
            hasReachedMordod = true;
        }

        private static void UpdateArmyCoordinates(int nextRow, int nextCol)
        {
            matrix[army.Row, army.Col] = '-';
            army.Row = nextRow;
            army.Col = nextCol;
            matrix[nextRow, nextCol] = 'A';
        }

        private static void BattleOrcs()
        {
            army.Armor -= 2;
            if (army.Armor <= 0)
            {
                matrix[army.Row, army.Col] = 'X';
                gameOver = true;
            }
        }

        private static bool ValidateCoordinates(int nextRow, int nextCol)
        {
            if (nextRow < 0 || nextRow >= matrixSize) return false;
            if (nextCol < 0 || nextCol >= matrixSize) return false;
            return true;
        }

        private static (int nextRow, int nextCol) GetCoordinates(string direction)
        {
            direction = direction.ToLower();
            switch (direction)
            {
                case "up": return (army.Row - 1, army.Col);
                case "down": return (army.Row + 1, army.Col);
                case "right": return (army.Row, army.Col + 1);
               default: return (army.Row, army.Col - 1);
            }
        }

        private static void SpawnEnemy((int row, int col) spawnCoordinates)
        {
            var areCoordinatesValid = ValidateCoordinates(spawnCoordinates.row, spawnCoordinates.col);
            if (!areCoordinatesValid) return;
            matrix[spawnCoordinates.row, spawnCoordinates.col] = 'O';  
        }

        private static void ReadMatrix()
        {
            matrix = new char[matrixSize, matrixSize];
            
            for (int row = 0; row < matrixSize; row++)
            {
                var currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    var currentSymbol = currentRow[col];
                    matrix[row, col] = currentSymbol;
                    if (currentSymbol == 'A')
                    {
                        army.Row = row;
                        army.Col = col;
                    }
                }
            }
        }
    }

    public class Army
    {
        public int Armor { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public Army(int armor, int row, int col)
        {
            Armor = armor;
            Row = row;
            Col = col;
        }
    }
}
