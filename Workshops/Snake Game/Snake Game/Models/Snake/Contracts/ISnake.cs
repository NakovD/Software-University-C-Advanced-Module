namespace SnakeGame.Models.Snake.Contracts
{
    using Cell;
    using Cell.Contracts;
    using Enums;

    public interface ISnake
    {
        IReadOnlyCollection<BaseCell> SnakeCells { get; }

        SnakeDirection Direction { get; set; }

        void Draw();

        ICell Move();

        void Grow();
    }
}
