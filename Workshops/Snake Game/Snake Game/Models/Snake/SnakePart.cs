namespace SnakeGame.Models.Snake
{
    using Cell;
    using Contracts;

    public class SnakePart : BaseCell, ISnakePart
    {
        public SnakePart(int xPosition, int yPosition) : base(xPosition, yPosition)
        {
        }
    }
}
