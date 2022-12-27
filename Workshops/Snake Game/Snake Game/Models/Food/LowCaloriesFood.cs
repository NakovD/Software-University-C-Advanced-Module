namespace SnakeGame.Models.Food
{
    using Cell;
    using Contracts;

    internal class HighCaloriesFood : BaseCell, IFood
    {
        public int Points { get; private set; }

        public string Symbol { get; private set; }

        public HighCaloriesFood(int xPosition, int yPosition) : base(xPosition, yPosition)
        {
            Points = 2;
            Symbol = "#";
        }
    }
}
