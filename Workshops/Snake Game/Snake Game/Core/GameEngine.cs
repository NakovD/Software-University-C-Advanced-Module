namespace SnakeGame.Core
{
    using Contracts;
    using Enums;
    using Infrastucture;
    using Models;
    using Models.Food;
    using Models.Food.Contracts;
    using Models.Cell;
    using Models.Cell.Contracts;
    using Models.Snake;
    using Models.Borders.Contracts;

    using System;

    public class GameEngine : IEngine
    {
        private IFood currentFood;

        private FoodGenerator foodGenerator;

        private int points;

        public GameEngine()
        {
            foodGenerator = new FoodGenerator();
        }

        public void Run()
        {
            ConsoleSetup.Configure();

            IBorder boxBorder = new BoxBorder();
            boxBorder.Draw();

            GenerateFood();

            var snake = new Snake();
            snake.Draw();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var direction = ReadKeys();
                    snake.Direction = direction;
                }

                try
                {
                    var newSnakeHeadPosition = (BaseCell)snake.Move();
                    var foodCell = (BaseCell)currentFood;
                    if (newSnakeHeadPosition.Equals(foodCell))
                    {
                        points += currentFood.Points;
                        snake.Grow();
                        GenerateFood();
                    }
                    Thread.Sleep(50);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"Score: {points}");
                    break;
                }
            }

        }

        private void GenerateFood()
        {
            var newFood = foodGenerator.Generate();
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
