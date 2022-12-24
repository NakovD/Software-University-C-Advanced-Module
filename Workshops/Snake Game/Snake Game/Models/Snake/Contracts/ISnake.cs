namespace SnakeGame.Models.Snake.Contracts
{
    using Enums;
    using Cell.Contracts;

    public interface ISnake
    {
        SnakeDirection Direction { get; set; }

        void Draw();

        void Draw(int startLeft, int startTop);

        ICell Move();

        void Grow();
    }
}
