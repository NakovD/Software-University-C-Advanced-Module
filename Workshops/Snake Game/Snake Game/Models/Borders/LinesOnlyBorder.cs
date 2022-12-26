namespace SnakeGame.Models.Borders
{
    using Contracts;
    using Cell;

    using System;
    using System.Collections.Generic;

    public class LinesOnlyBorder : IBorder
    {
        private const string borderSymbol = "*";

        public HashSet<BaseCell> borderCells { get; private set; }

        public LinesOnlyBorder()
        {
            borderCells = new HashSet<BaseCell>();
        }

        public void Draw()
        {
            DrawTopVerticalLine();
            DrawBottomVerticalLine();
            DrawTopHorizontalLine();
            DrawBottomHorizontalLine();
        }

        private void DrawTopVerticalLine()
        {
            var x = (int)(Console.WindowWidth * 0.2);
            var lineHeight = (int)(Console.WindowHeight * 0.4);

            for (int i = 0; i < lineHeight; i++)
            {
                var newBorderCell = new BorderCell(x, i);
                newBorderCell.Draw(borderSymbol);
                borderCells.Add(newBorderCell);
            }
        }

        private void DrawBottomVerticalLine()
        {
            var x = Console.WindowWidth - (int)(Console.WindowWidth * 0.2);
            var lineHeight = (int)(Console.WindowHeight * 0.4);

            var startIndex = Console.WindowHeight - lineHeight;
            for (int i = startIndex; i < Console.WindowHeight; i++)
            {
                var newBorderCell = new BorderCell(x, i);
                newBorderCell.Draw(borderSymbol);
                borderCells.Add(newBorderCell);
            }
        }

        private void DrawTopHorizontalLine()
        {
            var y = (int)(Console.WindowHeight * 0.4);
            var lineWidth = (int)(Console.WindowWidth * 0.4);

            var startIndex = Console.WindowWidth - lineWidth;
            for (int i = startIndex; i < Console.WindowWidth; i++)
            {
                var cell = new BorderCell(i, y);
                cell.Draw(borderSymbol);
                borderCells.Add(cell);
            }
        }

        private void DrawBottomHorizontalLine()
        {
            var y = Console.WindowHeight - (int)(Console.WindowHeight * 0.4);
            var lineWidth = (int)(Console.WindowWidth * 0.4);

            for (int i = 0; i < lineWidth; i++)
            {
                var cell = new BorderCell(i, y);
                cell.Draw(borderSymbol);
                borderCells.Add(cell);
            }
        }

    }
}
