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
            DrawFirstLine();
            DrawSecondLine();
            DrawThirdLine();
        }

        private void DrawFirstLine()
        {
            var topOffset = 15;
            var lineLength = 40;

            for (int i = 0; i < lineLength; i++)
            {
                var newBorderCell = new BorderCell(i, topOffset);
                newBorderCell.Draw(borderSymbol);
                borderCells.Add(newBorderCell);
            }
        }

        private void DrawSecondLine()
        {
            var topOffset = 30;
            var lineLength = 80;
            var lineStart = Console.WindowWidth - 1 - lineLength;
            var lineEnd = Console.WindowWidth - 1;

            for (int i = lineStart; i < lineEnd; i++)
            {
                var newBorderCell = new BorderCell(i, topOffset);
                newBorderCell.Draw(borderSymbol);
                borderCells.Add(newBorderCell);
            }
        }

        private void DrawThirdLine()
        {
            var leftOffset = 150;
            var lineHeight = 40;
            var lineStart = Console.WindowHeight - 1 - lineHeight;
            var lineEnd = Console.WindowHeight - 1;

            for (int i = lineStart; i < lineEnd; i++)
            {
                var newBorderCell = new BorderCell(leftOffset, i);
                newBorderCell.Draw(borderSymbol);
                borderCells.Add(newBorderCell);
            }
        }
    }
}
