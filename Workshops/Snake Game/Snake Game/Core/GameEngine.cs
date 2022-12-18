namespace SnakeGame.Core
{
    using Contracts;
    using Enums;
    using Infrastucture;
    using Models;
    using Models.Snake;
    using Models.Borders.Contracts;
    using Models.Snake.Contracts;

    using System;

    public class GameEngine : IEngine
    {
        public void Run()
        {
            ConsoleSetup.Configure();

            IBorder boxBorder = new BoxBorder();
            boxBorder.Draw();

            var snake = new Snake();
            snake.Draw();

            while (true)
            {
                Thread.Sleep(50);
                if (Console.KeyAvailable)
                {
                    var direction = ReadKeys();
                    snake.Direction = direction;
                }

                snake.Move();
            }

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
