namespace SnakeGame.Models.Borders.Contracts
{
    using Cell;

    public interface IBorder
    {
        IReadOnlyCollection<BaseCell> BorderCells { get; }

        void Draw();
    }
}
