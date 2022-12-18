namespace SnakeGame.Models
{
    using Borders.Contracts;

    using System;
    using System.Text;

    public class BoxBorder : IBorder
    {
        private int consoleWidth;

        private int consoleHeight;

        private const string verticalBorderSymbol = "|";

        private const string horizontalBorderSymbolTop = "\u0305";

        private const string horizontalBorderSymbolBottom = "_";

        public BoxBorder()
        {
            consoleWidth = Console.WindowWidth - 1;
            consoleHeight = Console.WindowHeight - 1;
        }

        public void Draw()
        {
            DrawVerticalBorderLines();
            DrawHorizontalBorderLines();
        }

        private void DrawVerticalBorderLines()
        {
            var leftCursorPosition = consoleWidth - 1;

            for (int i = 0; i < consoleHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(verticalBorderSymbol);
                Console.SetCursorPosition(leftCursorPosition, i);
                Console.WriteLine(verticalBorderSymbol);
            }
        }

        private void DrawHorizontalBorderLines()
        {
            var topCursorPosition = consoleHeight - 1;

            Console.OutputEncoding = Encoding.Unicode;

            for (int i = 0; i < consoleWidth - 1; i++)
            {
                var index = i == 0 ? 1 : i;
                Console.SetCursorPosition(index, 0);
                Console.WriteLine(horizontalBorderSymbolTop);
                Console.SetCursorPosition(index, topCursorPosition);
                Console.WriteLine(horizontalBorderSymbolBottom);
            }
        }
    }
}
