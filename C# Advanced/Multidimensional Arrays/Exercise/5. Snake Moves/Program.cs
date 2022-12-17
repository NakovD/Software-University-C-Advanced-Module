using System;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var stairsDimensions = Console.ReadLine().Split(" ");
            var snake = Console.ReadLine();
            var stairsRows = int.Parse(stairsDimensions[0]);
            var stairsCols = int.Parse(stairsDimensions[1]);
            var stairs = new string[stairsRows, stairsCols];
            var snakeCounter = 0;

            for (int row = 0; row < stairsRows; row++)
            {
                var isColumnReversed = row % 2 != 0 ? true : false;
                if (isColumnReversed)
                {
                    for (int reverseCol = stairsCols - 1; reverseCol >= 0; reverseCol--)
                    {
                        AddSnakePartToMatrix(stairs, row, reverseCol, snake, ref snakeCounter);
                    }
                    continue;
                }
                for (int col = 0; col < stairsCols; col++)
                {
                    AddSnakePartToMatrix(stairs, row, col, snake, ref snakeCounter);
                }
            }

            for (int row = 0; row < stairsRows; row++)
            {
                for (int col = 0; col < stairsCols; col++)
                {
                    Console.Write(stairs[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void AddSnakePartToMatrix(string [,] matrix, int row, int col, string snake, ref int snakeCounter)
        {
            if (snakeCounter >= snake.Length) snakeCounter = 0;
            matrix[row, col] = snake[snakeCounter].ToString();
            snakeCounter++;
        }
    }
}
