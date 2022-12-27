namespace SnakeGame.Models.Borders
{
    using Contracts;
    using Cell;

    using System.Collections.Generic;
    using System;

    public class MazeBorder : IBorder
    {
        private const string borderSymbol = "*";

        public HashSet<BaseCell> borderCells { get; private set; }

        public MazeBorder()
        {
            borderCells = new HashSet<BaseCell>();
        }

        public void Draw()
        {
            DrawBottomPart();
            DrawTopRightPart();
            DrawTopLeftPart();
        }

        private void DrawTopLeftPart()
        {
            DrawTopLeftCorner();

            var bottomLineStart = 0;
            var bottomLineEnd = (int)(Console.WindowWidth * 0.45);
            var bottomLineY = (int)(Console.WindowHeight * 0.4);

            for (int i = bottomLineStart; i < bottomLineEnd; i++)
            {
                CreateCellDrawItAndAddItInCollection(i, bottomLineY);
            }

            var verticalLineStart = 0;
            var verticalLineEnd = bottomLineY + 1;
            var verticalLineX = bottomLineEnd;

            for (int i = verticalLineStart; i < verticalLineEnd; i++)
            {
                CreateCellDrawItAndAddItInCollection(verticalLineX, i);
            }


            var horizontalLineStart = (int)(Console.WindowWidth * 0.2);
            var horizontalLineEnd = bottomLineEnd;
            var horizontalLineY = 0;

            for (int i = horizontalLineStart; i < horizontalLineEnd; i++)
            {
                CreateCellDrawItAndAddItInCollection(i, horizontalLineY);
            }
        }

        private void DrawTopLeftCorner()
        {
            var cornerWidth = (int)(Console.WindowWidth * 0.1);

            for (int i = 0; i < cornerWidth; i++)
            {
                CreateCellDrawItAndAddItInCollection(i, 0);
                if (i > cornerWidth / 2) continue;
                CreateCellDrawItAndAddItInCollection(0, i);
            }
        }

        private void DrawTopRightPart()
        {
            var topLineStart = (int)(Console.WindowWidth * 0.45);
            var topLineEnd = (int)(Console.WindowWidth * 0.8);
            var topLineY = 0;

            for (int i = topLineStart; i < topLineEnd; i++)
            {
                CreateCellDrawItAndAddItInCollection(i, topLineY);
            }

            var bottomLineStart = (int)(Console.WindowWidth * 0.65);
            var bottomLineEnd = Console.WindowWidth;
            var bottomLineY = (int)(Console.WindowHeight * 0.4);

            for (int i = bottomLineStart; i < bottomLineEnd; i++)
            {
                CreateCellDrawItAndAddItInCollection(i, bottomLineY);
            }
        }

        private void DrawBottomPart()
        {
            var horizontalLineEnd = Console.WindowWidth - 1;
            var horizontalLineY = Console.WindowHeight - (int)(Console.WindowHeight * 0.4);

            for (int i = 0; i < horizontalLineEnd; i++)
            {
                CreateCellDrawItAndAddItInCollection(i, horizontalLineY);
            }

            var verticalLineEnd = Console.WindowHeight;
            var verticaLineX = (int)(Console.WindowWidth * 0.7);

            for (int i = horizontalLineY; i < verticalLineEnd; i++)
            {
                CreateCellDrawItAndAddItInCollection(verticaLineX, i);
            }
        }

        private void CreateCellDrawItAndAddItInCollection(int x, int y)
        {
            var cell = new BorderCell(x, y);
            cell.Draw(borderSymbol);
            borderCells.Add(cell);
        }
    }
}
