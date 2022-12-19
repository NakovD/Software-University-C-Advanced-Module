﻿namespace SnakeGame.Models.Snake
{
    using Contracts;
    using Enums;

    using System;
    using System.Collections.ObjectModel;

    public class Snake : ISnake
    {
        private const int startingSnakeLength = 4;

        private LinkedList<SnakePart> snakeBody;

        private SnakeDirection direction;

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

            for (int i = 0; i < startingSnakeLength; i++)
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

        public void Move()
        {
            snakeBody.Last.Value.Clear();
            snakeBody.RemoveLast();
            snakeBody.First.Value.Draw(GetSnakeSymbolBasedOnDirection("snakeBodyHorizontal"));

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
            snakeBody.AddFirst(newHead);
            snakeBody.First.Next.Value.Draw(bodySymbol);
            newHead.Draw(headSymbol);

        }

        private static string GetSnakeSymbolBasedOnDirection(string instruction)
        {
            switch (instruction)
            {

                case "snakeBodyHorizontal": return "—";
                case "snakeBodyVertical": return "|";
                case "snakeHeadUp": return "\u02C4"; ;
                case "snakeHeadDown": return "\u02C5"; ;
                case "snakeHeadLeft": return "<";
                default: return ">";
            }
        }
    }
}