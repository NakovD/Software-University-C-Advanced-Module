namespace SnakeGame.Models.Borders
{
    using Borders.Contracts;
    using Cell;

    using System.Collections.Generic;

    public class EmptyBorder : IBorder
    {
        private HashSet<BaseCell> borderCells;

        public IReadOnlyCollection<BaseCell> BorderCells => borderCells.ToList().AsReadOnly();

        public EmptyBorder()
        {
            borderCells = new HashSet<BaseCell>();
        }

        public void Draw()
        {
        }
    }
}
