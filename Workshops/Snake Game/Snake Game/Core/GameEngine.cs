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
        private int gameSpeed;

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

            ShowIntroScreen();

            StartGame();
        }

        private void StartGame()
        {
            InitialSetup();

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
                    Thread.Sleep(gameSpeed);
                }
                catch (Exception ex)
                {
                    ShowGameOverScreen(ex.Message);
                    break;
                }

            }
        }

        private void ShowGameOverScreen(string message)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Game over!");
            Console.WriteLine($"Score: {points}");
            Console.WriteLine($"Reason for game over: {message}");
        }

        private void InitialSetup()
        {
            border.Draw();

            GenerateFood();

            snake.Draw();
        }

        private void ShowIntroScreen()
        {
            Console.WriteLine("Hello and Welcome to the game!");
            MakeUserChooseSpeed();
            Console.SetCursorPosition(0, 7);
            MakeUserChooseLevel();
            Console.Clear();
        }

        private void MakeUserChooseLevel()
        {
            Console.WriteLine("Please select a level:");
            Console.WriteLine("We have the following levels:\nClassic\nBox\nBorders\nCross\nLabyrinth\nMaze");
            Console.WriteLine("Write the level you selected:");
            ReadLevel();
        }

        private void MakeUserChooseSpeed()
        {
            Console.WriteLine("Please select speed for the snake:");
            Console.WriteLine("We have the following speeds:\nSlow = 1\nMedium = 2\nFast = 3");
            Console.Write("Choose you preference(with numpad): ");
            var speed = ReadSpeed();
            if (speed == 1) gameSpeed = 250;
            if (speed == 2) gameSpeed = 150;
            if (speed == 3) gameSpeed = 50;
        }

        private void ReadLevel()
        {
            var hasUserSelectedLevel = false;
            (int x, int y) = Console.GetCursorPosition();

            while (!hasUserSelectedLevel)
            {
                var data = Console.ReadLine();
                IBorder level = GetLevel(data);
                if (level == null)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(new string(' ', Console.WindowWidth - 1));
                    Console.SetCursorPosition(x, y);
                    continue;
                }

                hasUserSelectedLevel = true;
                border = level;
            }
        }

        private IBorder GetLevel(string data)
        {
            data = data.ToLower();
            switch (data)
            {
                case "classic": return new EmptyBorder();
                case "box": return new BoxBorder();
                case "borders": return new CornersBorder();
                case "cross": return new CrossBorder();
                case "labyrinth": return new LinesOnlyBorder();
                case "maze": return new MazeBorder();
                default: return null;
            }
        }

        private int ReadSpeed()
        {
            (int x, int y) = Console.GetCursorPosition();
            var hasChosenCorrectSpeed = false;
            var speed = 0;

            while (!hasChosenCorrectSpeed)
            {
                var key = Console.ReadKey().Key;
                if (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                    Console.SetCursorPosition(x, y);
                    continue;
                }
                hasChosenCorrectSpeed = true;
                if (key == ConsoleKey.D1) speed = 1;
                else if (key == ConsoleKey.D2) speed = 2;
                else speed = 3;
            }

            return speed;
        }

        private void CheckForInteraction(BaseCell newSnakeHeadPosition)
        {
            if (newSnakeHeadPosition == null) throw new Exception("You hit yourself!"); //snake hit herself

            if (border.BorderCells.Any(bc => bc.Equals(newSnakeHeadPosition))) throw new Exception("You hit the border!"); //snake hit the border

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
            var takenCells = border.BorderCells.Concat(snake.SnakeCells);
            var newFood = foodGenerator.Generate(takenCells);
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
