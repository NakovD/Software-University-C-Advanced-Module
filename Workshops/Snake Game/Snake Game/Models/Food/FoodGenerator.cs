namespace SnakeGame.Models.Food
{
    using Cell;
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

        public IFood Generate(IEnumerable<BaseCell> takenCells)
        {
            (int foodXCoordinates, int foodYCoordinates) = GetCoordinatesOfAFreeCell(takenCells);

            var allFoodTypes = Assembly
                                    .GetExecutingAssembly()
                                    .GetTypes()
                                    .Where(t => !t.IsAbstract && typeof(IFood).IsAssignableFrom(t)).ToList();

            var randomFoodTypeIndex = random.Next(1, allFoodTypes.Count + 1);

            var randomFoodType = allFoodTypes[randomFoodTypeIndex - 1];

            var food = Activator.CreateInstance(randomFoodType, new object[] { foodXCoordinates, foodYCoordinates }) as IFood;

            return food;
        }

        private (int foodXCoordinates, int foodYCoordinates) GetCoordinatesOfAFreeCell(IEnumerable<BaseCell> takenCells)
        {
            var hasFound = false;
            var foodXCoordinate = 0;
            var foodYCoordinate = 0;

            while (!hasFound)
            {
                var possibleXCoordinates = random.Next(min, xMax);
                var possibleYCoordinates = random.Next(min, yMax);

                var areCoordinatesTaken = takenCells.Any(c => c.XPosition == possibleXCoordinates && c.YPosition == possibleYCoordinates);

                if (areCoordinatesTaken) continue;

                foodXCoordinate = possibleXCoordinates;
                foodYCoordinate = possibleYCoordinates;
                break;
            }

            return (foodXCoordinate, foodYCoordinate);
        }
    }
}
