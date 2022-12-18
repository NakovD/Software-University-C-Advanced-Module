namespace SnakeGame.Models.Snake
{
    using Contracts;

    public class SnakePart : ISnakePart
    {
        public int XPosition { get; private set; }

        public int YPosition { get; private set; }

        public SnakePart(int xPosition, int yPosition)
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
    }
}
