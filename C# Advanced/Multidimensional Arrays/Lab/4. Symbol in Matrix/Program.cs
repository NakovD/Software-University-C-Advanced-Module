using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new string[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                var characters = Console.ReadLine();
                for (int col = 0; col < characters.Length; col++)
                {
                    matrix[row, col] = characters[col].ToString();
                }
            }

            var symbol = Console.ReadLine();

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    var currentCharacter = matrix[row, col];
                    if (currentCharacter == symbol) { Console.WriteLine($"({row}, {col})"); return; }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
