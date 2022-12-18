namespace SnakeGame.Models.Snake.Contracts
{
    using Enums;

    public interface ISnake
    {
        SnakeDirection Direction { get; set; }

        void Draw();

        void Draw(int startLeft, int startTop);

        void Move();
    }
}
