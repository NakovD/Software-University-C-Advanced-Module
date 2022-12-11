using System;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine().Split(" ");
            var mainMatrixRows = int.Parse(matrixSizes[0]);
            var mainMatrixCols = int.Parse(matrixSizes[1]);
            var mainMatrix = new string[mainMatrixRows, mainMatrixCols];
            var numberMatricesOfSameElements = 0;
            var innerMatrixRows = 2;
            var innerMatrixCols = 2;

            for (int row = 0; row < mainMatrixRows; row++)
            {
                var currentCols = Console.ReadLine().Split(" ");
                for (int col = 0; col < mainMatrixCols; col++)
                {
                    var currentColValue = currentCols[col];
                    mainMatrix[row, col] = currentColValue;
                }
            }

            for (int row = 0; row < mainMatrixRows; row++)
            {
                for (int col = 0; col < mainMatrixCols; col++)
                {
                    var innerMatrixHasOneSymbol = true;
                    var currentInnerMatrixRows = row + innerMatrixRows;
                    var currentInnerMatrixCols = col + innerMatrixCols;
                    var currentSymbol = mainMatrix[row, col];

                    if (currentInnerMatrixRows > mainMatrixRows || currentInnerMatrixCols > mainMatrixCols) continue;
                    for (int innerMatrixRow = row; innerMatrixRow < currentInnerMatrixRows; innerMatrixRow++)
                    {
                        for (int innerMatrixCol = col; innerMatrixCol < currentInnerMatrixCols; innerMatrixCol++)
                        {
                            var innerMatrixCurrentSymbol = mainMatrix[innerMatrixRow, innerMatrixCol];
                            if (innerMatrixCurrentSymbol != currentSymbol)
                            {
                                innerMatrixHasOneSymbol = false; break;
                            }
                        }

                        if (!innerMatrixHasOneSymbol) break;
                    }

                    if (innerMatrixHasOneSymbol) numberMatricesOfSameElements++;
                }
            }

            Console.WriteLine(numberMatricesOfSameElements);
        }
    }
}
