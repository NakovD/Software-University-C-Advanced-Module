namespace SnakeGame.Models.Food
{
    using Contracts;
    using Cell;

    public class BuffedFood : BaseCell, IFood
    {
        public int Points { get; private set; }

        public string Symbol { get; private set; }

        public BuffedFood(int xPosition, int yPosition) : base(xPosition, yPosition)
        {
            Points = 3;
            Symbol = "@";
        }
    }
}
