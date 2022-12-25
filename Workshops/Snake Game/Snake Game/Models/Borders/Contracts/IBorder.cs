namespace SnakeGame.Models.Borders.Contracts
{
    using Cell;

    public interface IBorder
    {
        HashSet<BaseCell> borderCells { get; }

        void Draw();
    }
}
