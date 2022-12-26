namespace SnakeGame.Models.Borders
{
    using Contracts;
    using Cell;

    using System.Collections.Generic;

    public class CrossBorder : IBorder
    {
        private int horizontalLineLength;

        private int verticalLineLength;

        private string borderSymbol = "!";

        public HashSet<BaseCell> borderCells { get; private set; }

        public CrossBorder()
        {
            borderCells= new HashSet<BaseCell>();
            horizontalLineLength = (int)(0.9 * Console.WindowWidth);
            verticalLineLength = (int)(0.9 * Console.WindowHeight);
        }

        public void Draw()
        {
            DrawHorizontalLine();
            DrawVerticalLine();
        }

        private void DrawHorizontalLine()
        {
            var start = (Console.WindowWidth - horizontalLineLength);

            var centerOfWindow = Console.WindowHeight / 2;

            for (int i = start; i < horizontalLineLength; i++)
            {
                var cell = new BorderCell(i, centerOfWindow);
                cell.Draw(borderSymbol);
                borderCells.Add(cell);
            }
        }

        private void DrawVerticalLine()
        {
            var start = (Console.WindowHeight - verticalLineLength);
            var centerOfWindow = Console.WindowWidth / 2;

            for (int i = start; i < verticalLineLength; i++)
            {
                var cell = new BorderCell(centerOfWindow, i);
                cell.Draw(borderSymbol);
                borderCells.Add(cell);
            }
        }
    }
}
