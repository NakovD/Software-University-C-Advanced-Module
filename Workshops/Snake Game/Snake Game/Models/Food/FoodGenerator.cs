namespace SnakeGame.Models.Food
{
    using Contracts;

    public class FoodGenerator
    {
        private Random random;

        private const int min = 0;

        private int xMax = Console.WindowWidth;

        private int yMax = Console.WindowHeight;

        public FoodGenerator()
        {
            random = new Random();
        }

        public IFood Generate()
        {
            var foodXCoordinates = random.Next(min, xMax);
            var foodYCoordinates = random.Next(min, yMax);
            var food = new NormalFood(foodXCoordinates, foodYCoordinates);
            return food;
        }
    }
}
