namespace SnakeGame.Models.Snake.Contracts
{
    public interface ISnakePart
    {
        int XPosition { get; }

        int YPosition { get; }

        public void Draw(string character);

        public void Clear();
    }
}
