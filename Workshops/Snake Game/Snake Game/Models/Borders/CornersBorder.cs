namespace SnakeGame.Models.Borders
{
    using Contracts;
    using Cell;

    using System.Collections.Generic;

    public class CornersBorder : IBorder
    {
        private int cornerWidth;

        private int cornerHeight;

        private const string borderSymbol = "*";

        private HashSet<BaseCell> borderCells;

        public IReadOnlyCollection<BaseCell> BorderCells => borderCells.ToList().AsReadOnly();

        public CornersBorder()
        {
            borderCells = new HashSet<BaseCell>();
            cornerWidth = Console.WindowWidth / 7;
            cornerHeight = Console.WindowHeight / 4;
        }

        public void Draw()
        {
            DrawTopLeftCorner();
            DrawTopRightCorner();
            DrawBottomLeftCorner();
            DrawBottomRightCorner();
        }

        private void DrawTopLeftCorner()
        {

            for (int i = 0; i < cornerWidth; i++)
            {
                var horizontalCell = new BorderCell(i, 0);
                horizontalCell.Draw(borderSymbol);
                borderCells.Add(horizontalCell);
            }

            for (int i = 0; i < cornerHeight; i++)
            {
                var verticalCell = new BorderCell(0, i);
                verticalCell.Draw(borderSymbol);
                borderCells.Add(verticalCell);
            }
        }

        private void DrawTopRightCorner()
        {
            var startIndex = Console.WindowWidth - cornerWidth;

            for (int i = startIndex; i < Console.WindowWidth; i++)
            {
                var horizontalCell = new BorderCell(i, 0);
                horizontalCell.Draw(borderSymbol);
                borderCells.Add(horizontalCell);
            }

            for (int i = 0; i < cornerHeight; i++)
            {
                var verticalCell = new BorderCell(Console.WindowWidth - 1, i);
                verticalCell.Draw(borderSymbol);
                borderCells.Add(verticalCell);
            }
        }

        private void DrawBottomLeftCorner()
        {
            for (int i = 0; i < cornerWidth; i++)
            {
                var horizontalCell = new BorderCell(i, Console.WindowHeight - 1);
                horizontalCell.Draw(borderSymbol);
                borderCells.Add(horizontalCell);
            }

            var startIndex = Console.WindowHeight - cornerHeight;

            for (int i = startIndex; i < Console.WindowHeight; i++)
            {
                var verticalCell = new BorderCell(0, i);
                verticalCell.Draw(borderSymbol);
                borderCells.Add(verticalCell);
            }
        }

        private void DrawBottomRightCorner()
        {
            var startIndex = Console.WindowWidth - cornerWidth;
            for (int i = startIndex; i < Console.WindowWidth; i++)
            {
                var horizontalCell = new BorderCell(i, Console.WindowHeight - 1);
                horizontalCell.Draw(borderSymbol);
                borderCells.Add(horizontalCell);
            }

            var verticalStartIndex = Console.WindowHeight - cornerHeight;
            for (int i = verticalStartIndex; i < Console.WindowHeight; i++)
            {
                var verticalCell = new BorderCell(Console.WindowWidth - 1, i);
                verticalCell.Draw(borderSymbol);
                borderCells.Add(verticalCell);
            }
        }
    }
}
