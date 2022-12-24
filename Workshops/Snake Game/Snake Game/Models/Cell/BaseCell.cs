namespace SnakeGame.Models.Cell
{
    using Contracts;

    using System;

    public abstract class BaseCell : ICell, IEquatable<BaseCell>
    {
        public int XPosition { get; private set; }

        public int YPosition { get; private set; }

        public BaseCell(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public void Draw(string character)
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.Write(character);
        }

        public void Clear()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.Write(" ");
        }

        public bool Equals(BaseCell other) => XPosition == other.XPosition && YPosition == other.YPosition;
    }
}
