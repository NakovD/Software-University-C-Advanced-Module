namespace SnakeGame.Models.Cell.Contracts
{
    public interface ICell
    {
        int XPosition { get; }

        int YPosition { get; }

        public void Draw(string character);

        public void Clear();
    }
}
