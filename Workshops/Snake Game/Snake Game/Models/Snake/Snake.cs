namespace SnakeGame.Models.Snake
{
    using Contracts;
    using Enums;

    using System;

    public class Snake : ISnake
    {
        private const int startingSnakeLength = 5;

        private const string snakeBodySymbol = "-";

        private const string snakeHeadSymbol = ">";

        private LinkedList<SnakePart> snakeBody;

        public SnakeDirection Direction { get; set; }

        public Snake()
        {
            Direction = SnakeDirection.Right;
            snakeBody = new LinkedList<SnakePart>();
        }

        public void Draw()
        {
            Draw(10, 10);
        }

        public void Draw(int startLeft, int startTop)
        {
            Console.CursorVisible = false;

            var startLeftI = startLeft;

            for (int i = 0; i < startingSnakeLength; i++)
            {
                var newSnakeBodyPart = new SnakePart(startLeftI, startTop);
                snakeBody.AddFirst(newSnakeBodyPart);
                newSnakeBodyPart.Draw(snakeBodySymbol);
                startLeftI += 1;
            }

            var snakeHead = new SnakePart(startLeftI, startTop);
            snakeBody.AddFirst(snakeHead);
            snakeHead.Draw(snakeHeadSymbol);
        }

        public void Move()
        {
            snakeBody.Last.Value.Clear();
            snakeBody.RemoveLast();
            snakeBody.First.Value.Draw(snakeBodySymbol);

            var newSnakeBodyPartX = 0;
            var newSnakeBodyPartY = 0;

            switch (Direction)
            {
                case SnakeDirection.Up:
                    newSnakeBodyPartX = snakeBody.First.Value.XPosition;
                    newSnakeBodyPartY = snakeBody.First.Value.YPosition - 1;
                    break;
                case SnakeDirection.Down:
                    newSnakeBodyPartX = snakeBody.First.Value.XPosition;
                    newSnakeBodyPartY = snakeBody.First.Value.YPosition + 1;
                    break;
                case SnakeDirection.Left:
                    newSnakeBodyPartX = snakeBody.First.Value.XPosition - 1;
                    newSnakeBodyPartY = snakeBody.First.Value.YPosition;
                    break;
                case SnakeDirection.Right:
                    newSnakeBodyPartX = snakeBody.First.Value.XPosition + 1;
                    newSnakeBodyPartY = snakeBody.First.Value.YPosition;
                    break;
            }

            var newHead = new SnakePart(newSnakeBodyPartX, newSnakeBodyPartY);
            snakeBody.AddFirst(newHead);
            newHead.Draw(snakeHeadSymbol);
        }
    }
}
