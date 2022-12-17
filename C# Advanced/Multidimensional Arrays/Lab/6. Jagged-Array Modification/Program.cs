using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixRows = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[matrixRows][];

            for (int row = 0; row < matrixRows; row++)
            {
                var currentCols = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                jaggedArr[row] = currentCols;
            }

            var input = Console.ReadLine().Split(" ");

            while (input[0] != "END")
            {
                var command = input[0];
                var neededRow = int.Parse(input[1]);
                var neededCol = int.Parse(input[2]);
                var value = int.Parse(input[3]);

                input = Console.ReadLine().Split(" ");

                if (neededRow >= jaggedArr.Length || neededRow < 0) { Console.WriteLine("Invalid coordinates"); continue; }
                var neededArray = jaggedArr[neededRow];
                if (neededCol >= neededArray.Length || neededCol < 0) { Console.WriteLine("Invalid coordinates"); continue; }

                var currentValue = jaggedArr[neededRow][neededCol];

                switch (command)
                {
                    case "Add":
                        jaggedArr[neededRow][neededCol] = currentValue + value;
                        break;
                    default:
                        jaggedArr[neededRow][neededCol] = currentValue - value;
                        break;
                }
            }

            for (int row = 0; row < jaggedArr.Length; row++)
            {
                var currentCols = jaggedArr[row];
                Console.WriteLine(string.Join(" ", currentCols));
            }
        }
    }
}
