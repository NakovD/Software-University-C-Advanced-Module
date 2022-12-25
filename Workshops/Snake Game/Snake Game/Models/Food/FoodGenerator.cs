namespace SnakeGame.Models.Food
{
    using Contracts;

    using System.Reflection;

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

            var allFoodTypes = Assembly
                                    .GetExecutingAssembly()
                                    .GetTypes()
                                    .Where(t => !t.IsAbstract && typeof(IFood).IsAssignableFrom(t)).ToList();

            var randomFoodTypeIndex = random.Next(1, allFoodTypes.Count + 1);

            var randomFoodType = allFoodTypes[randomFoodTypeIndex - 1];

            var food = Activator.CreateInstance(randomFoodType, new object[] { foodXCoordinates, foodYCoordinates }) as IFood;

            return food;
        }
    }
}
