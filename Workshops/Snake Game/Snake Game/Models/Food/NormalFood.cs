namespace SnakeGame.Models.Food
{
    using Contracts;
    using Cell;

    public class NormalFood : BaseCell, IFood
    {
        public int Points { get; private set; }

        public string Symbol { get; private set; }

        public NormalFood(int xPosition, int yPosition) : base(xPosition, yPosition)
        {
            Points = 1;
            Symbol = "$";
        }
    }
}
