namespace SnakeGame.Core
{
    using Contracts;
    using Enums;
    using Infrastucture;
    using Models;
    using Models.Borders;
    using Models.Borders.Contracts;
    using Models.Cell.Contracts;
    using Models.Cell;
    using Models.Food;
    using Models.Food.Contracts;
    using Models.Snake;

    using System;
    using System.Text;

    public class GameEngine : IEngine
    {
        private IFood currentFood;

        private IBorder border;

        private FoodGenerator foodGenerator;

        private Snake snake;

        private int points;

        public GameEngine()
        {
            foodGenerator = new FoodGenerator();
            snake = new Snake();
            border = new EmptyBorder();
            Console.OutputEncoding = Encoding.Unicode;
        }

        public void Run()
        {
            ConsoleSetup.Configure();

            border = new BoxBorder();

            border.Draw();

            GenerateFood();

            snake.Draw();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var direction = ReadKeys();
                    snake.Direction = direction;
                }

                var newSnakeHeadPosition = (BaseCell)snake.Move();

                try
                {
                    CheckForInteraction(newSnakeHeadPosition);
                    Thread.Sleep(50);
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Game over!");
                    Console.WriteLine($"Score: {points}");
                    Console.WriteLine($"Reason for game over: {ex.Message}");
                    break;
                }

            }
        }

        private void CheckForInteraction(BaseCell newSnakeHeadPosition)
        {
            if (newSnakeHeadPosition == null) throw new Exception("You hit yourself!"); //snake hit herself

            if (border.borderCells.Any(bc => bc.Equals(newSnakeHeadPosition))) throw new Exception("You hit the border!"); //snake hit the border

            var foodCell = (BaseCell)currentFood;

            if (newSnakeHeadPosition.Equals(foodCell))  //snake found food
            {
                points += currentFood.Points;
                snake.Grow();
                GenerateFood();
            }

            //nothing happened - snake just moved one place further
        }

        private void GenerateFood()
        {
            var newFood = foodGenerator.Generate(border.borderCells);
            currentFood = newFood;
            var newFoodCell = (ICell)currentFood;
            newFoodCell.Draw(currentFood.Symbol);
        }

        private SnakeDirection ReadKeys()
        {
            var key = Console.ReadKey().Key;

            SnakeDirection newDirection;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    newDirection = SnakeDirection.Up;
                    break;
                case ConsoleKey.DownArrow:
                    newDirection = SnakeDirection.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    newDirection = SnakeDirection.Left;
                    break;
                default:
                    newDirection = SnakeDirection.Right;
                    break;
            }

            return newDirection;
        }
    }
}
