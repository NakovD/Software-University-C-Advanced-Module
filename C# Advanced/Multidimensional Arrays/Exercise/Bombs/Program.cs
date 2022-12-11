using System;
using System.Linq;
using System.Text;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Read input
            var sizeOfMatrix = int.Parse(Console.ReadLine());
            var matrix = new int[sizeOfMatrix, sizeOfMatrix];

            #endregion

            #region Fill matrix

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                var currentRowColumns = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    var currentCellValue = currentRowColumns[col];
                    matrix[row, col] = currentCellValue;
                }
            }

            #endregion

            #region Read and explode the bombs

            var bombs = Console.ReadLine().Split(" ");

            for (int bombIndex = 0; bombIndex < bombs.Length; bombIndex++)
            {
                var bombCoordinates = bombs[bombIndex].Split(",");
                var bombRowIndex = int.Parse(bombCoordinates[0]);
                var bombColIndex = int.Parse(bombCoordinates[1]);
                ExplodeBomb(bombRowIndex, bombColIndex, matrix);
            }

            #endregion

            #region Get the alive cells and their sum

            var aliveCellsAmount = 0;
            var sumOfAliveCells = 0;
            var finalMatrixString = new StringBuilder();

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    var currentCell = matrix[row, col];
                    finalMatrixString.Append(currentCell + " ");
                    if (currentCell <= 0) continue;
                    aliveCellsAmount++;
                    sumOfAliveCells += currentCell;
                }
                finalMatrixString.Append("\n");
            }

            #endregion

            #region Print the required output
            Console.WriteLine($"Alive cells: {aliveCellsAmount}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");
            Console.WriteLine(finalMatrixString.ToString());
            #endregion
        }

        static void ExplodeBomb(int bombRowIndex, int bombColIndex, int[,] matrix)
        {
            var bombPower = matrix[bombRowIndex, bombColIndex];
            if (bombPower <= 0) return;
            matrix[bombRowIndex, bombColIndex] = 0;
            var adjacentCells = GetAllAdjacentCells(bombRowIndex, bombColIndex);
            ExplodeValidAdjacentCells(adjacentCells, bombPower, matrix);
        }

        static Cell[] GetAllAdjacentCells(int bombRowIndex, int bombColIndex)
        {
            var adjacentCells = new Cell[] {
                new Cell(bombRowIndex - 1, bombColIndex - 1),       //top left
                new Cell(bombRowIndex - 1, bombColIndex),       //top
                new Cell(bombRowIndex - 1, bombColIndex + 1),       //top right
                new Cell(bombRowIndex, bombColIndex - 1),       //left
                new Cell(bombRowIndex, bombColIndex + 1),       //right
                new Cell(bombRowIndex + 1, bombColIndex - 1),       //bottom left
                new Cell(bombRowIndex + 1, bombColIndex),       //bottom
                new Cell(bombRowIndex + 1, bombColIndex + 1),   //bottom right
            };

            return adjacentCells;
        }

        static void ExplodeValidAdjacentCells(Cell[] adjacentCells, int bombPower, int[,] matrix)
        {
            foreach (var cell in adjacentCells)
            {
                var areCellCoordinatesValid = ValidateCellCoordinates(cell.RowIndex, cell.CollIndex, matrix);
                if (!areCellCoordinatesValid) continue;
                //remove the bomb value from the valid cell;
                var currentCellValue = matrix[cell.RowIndex, cell.CollIndex];
                if (currentCellValue <= 0) continue;
                matrix[cell.RowIndex, cell.CollIndex] = currentCellValue - bombPower;
            }
        }

        static bool ValidateCellCoordinates(int row, int col, int[,] matrix)
        {
            if (row < 0 || col < 0) return false;
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1)) return false;
            return true;
        }
    }

    class Cell
    {
        public int RowIndex { get; set; }
        public int CollIndex { get; set; }


        public Cell(int row, int col)
        {
            this.RowIndex = row;
            this.CollIndex = col;
        }
    }
}
