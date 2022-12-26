namespace SnakeGame.Models.Borders
{
    using Borders.Contracts;
    using Cell;

    using System.Collections.Generic;

    public class EmptyBorder : IBorder
    {
        public HashSet<BaseCell> borderCells { get; private set; }

        public EmptyBorder()
        {
            borderCells = new HashSet<BaseCell>();
        }

        public void Draw()
        {
        }
    }
}
