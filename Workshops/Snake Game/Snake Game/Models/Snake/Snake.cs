namespace SnakeGame.Models.Snake
{
    using Contracts;
    using Enums;
    using Cell;
    using Cell.Contracts;

    using System;

    public class Snake : ISnake
    {
        private const int startingSnakeLength = 5;

        private bool snakeAteHerself;

        private LinkedList<SnakePart> snakeBody;

        private SnakeDirection direction;

        public IReadOnlyCollection<BaseCell> SnakeCells => snakeBody.ToList().AsReadOnly();

        public int SnakeLength { get; set; }

        public SnakeDirection Direction
        {
            get => direction;

            set
            {
                bool isNewDirectionValid = ValidateNewDirection(direction, value);
                if (!isNewDirectionValid) return;
                direction = value;
            }
        }

        private bool ValidateNewDirection(SnakeDirection current, SnakeDirection _new)
        {
            if (current == SnakeDirection.Up && _new == SnakeDirection.Down) return false;

            if (current == SnakeDirection.Down && _new == SnakeDirection.Up) return false;

            if (current == SnakeDirection.Right && _new == SnakeDirection.Left) return false;

            if (current == SnakeDirection.Left && _new == SnakeDirection.Right) return false;

            return true;
        }

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

            var snakeLenghtWithoutHead = startingSnakeLength - 1;

            for (int i = 0; i < snakeLenghtWithoutHead; i++)
            {
                var newSnakeBodyPart = new SnakePart(startLeftI, startTop);
                snakeBody.AddFirst(newSnakeBodyPart);
                newSnakeBodyPart.Draw(GetSnakeSymbolBasedOnDirection("snakeBodyHorizontal"));
                startLeftI += 1;
            }

            var snakeHead = new SnakePart(startLeftI, startTop);
            snakeBody.AddFirst(snakeHead);
            snakeHead.Draw(GetSnakeSymbolBasedOnDirection("snakeHeadRight"));
        }

        public ICell Move()
        {
            snakeBody.Last.Value.Clear();
            snakeBody.RemoveLast();

            Grow();

            var newHead = snakeBody.First.Value;

            if (snakeAteHerself) return null;

            return newHead;
        }

        public void Grow()
        {
            var newSnakePartX = 0;
            var newSnakePartY = 0;
            var bodySymbol = string.Empty;
            var headSymbol = string.Empty;

            switch (Direction)
            {
                case SnakeDirection.Up:
                    newSnakePartX = snakeBody.First.Value.XPosition;
                    newSnakePartY = snakeBody.First.Value.YPosition - 1;
                    bodySymbol = GetSnakeSymbolBasedOnDirection("snakeBodyVertical");
                    headSymbol = GetSnakeSymbolBasedOnDirection("snakeHeadUp");
                    break;
                case SnakeDirection.Down:
                    newSnakePartX = snakeBody.First.Value.XPosition;
                    newSnakePartY = snakeBody.First.Value.YPosition + 1;
                    bodySymbol = GetSnakeSymbolBasedOnDirection("snakeBodyVertical");
                    headSymbol = GetSnakeSymbolBasedOnDirection("snakeHeadDown");
                    break;
                case SnakeDirection.Left:
                    newSnakePartX = snakeBody.First.Value.XPosition - 1;
                    newSnakePartY = snakeBody.First.Value.YPosition;
                    bodySymbol = GetSnakeSymbolBasedOnDirection("snakeBodyHorizontal");
                    headSymbol = GetSnakeSymbolBasedOnDirection("snakeHeadLeft");
                    break;
                case SnakeDirection.Right:
                    newSnakePartX = snakeBody.First.Value.XPosition + 1;
                    newSnakePartY = snakeBody.First.Value.YPosition;
                    bodySymbol = GetSnakeSymbolBasedOnDirection("snakeBodyHorizontal");
                    headSymbol = GetSnakeSymbolBasedOnDirection("snakeHeadRight");
                    break;
            }

            var newHead = new SnakePart(newSnakePartX, newSnakePartY);

            snakeAteHerself = snakeBody.Any(sbp => sbp.Equals(newHead));

            try
            {
                newHead.Draw(headSymbol);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                newHead = GetNewHead(newSnakePartX, newSnakePartY);
                newHead.Draw(headSymbol);
            }

            snakeBody.AddFirst(newHead);
            snakeBody.First.Next.Value.Draw(bodySymbol);
        }

        private SnakePart GetNewHead(int previousHeadX, int previousHeadY)
        {
            switch (Direction)
            {
                case SnakeDirection.Right: return new SnakePart(0, previousHeadY);
                case SnakeDirection.Left: return new SnakePart(Console.WindowWidth - 1, previousHeadY);
                case SnakeDirection.Up: return new SnakePart(previousHeadX, Console.WindowHeight - 1);
                default: return new SnakePart(previousHeadX, 0);
            }
        }

        private static string GetSnakeSymbolBasedOnDirection(string instruction)
        {
            switch (instruction)
            {

                case "snakeBodyHorizontal": return "—";
                case "snakeBodyVertical": return "|";
                case "snakeHeadUp": return "\u02C4"; ;
                case "snakeHeadDown": return "\u02C5";
                case "snakeHeadLeft": return "<";
                default: return ">";
            }
        }
    }
}
