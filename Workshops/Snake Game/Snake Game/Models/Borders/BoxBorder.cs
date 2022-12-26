namespace SnakeGame.Models
{
    using Borders;
    using Borders.Contracts;
    using Cell;

    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoxBorder : IBorder
    {
        private int consoleWidth;

        private int consoleHeight;

        private const string verticalBorderSymbol = "|";

        private const string horizontalBorderSymbolTop = "\u0305";

        private const string horizontalBorderSymbolBottom = "_";

        public HashSet<BaseCell> borderCells { get; private set; }

        public BoxBorder()
        {
            consoleWidth = Console.WindowWidth - 1;
            consoleHeight = Console.WindowHeight - 1;
            borderCells = new HashSet<BaseCell>();
        }

        public void Draw()
        {
            DrawVerticalBorderLines();
            DrawHorizontalBorderLines();
        }

        private void DrawVerticalBorderLines()
        {
            var leftCursorPosition = consoleWidth;

            for (int i = 0; i <= consoleHeight; i++)
            {
                var leftBorderCell = new BorderCell(0, i);
                leftBorderCell.Draw(verticalBorderSymbol);
                var rightBorderCell = new BorderCell(leftCursorPosition, i);
                rightBorderCell.Draw(verticalBorderSymbol);
                borderCells.Add(leftBorderCell);
                borderCells.Add(rightBorderCell);
            }
        }

        private void DrawHorizontalBorderLines()
        {
            var topCursorPosition = consoleHeight;

            for (int i = 0; i < consoleWidth; i++)
            {
                var index = i == 0 ? 1 : i;

                var topBorderCell = new BorderCell(index, 0);
                topBorderCell.Draw(horizontalBorderSymbolTop);
                var bottomBorderCell = new BorderCell(index, topCursorPosition);
                bottomBorderCell.Draw(horizontalBorderSymbolBottom);
                borderCells.Add(topBorderCell);
                borderCells.Add(bottomBorderCell);
            }
        }
    }
}
