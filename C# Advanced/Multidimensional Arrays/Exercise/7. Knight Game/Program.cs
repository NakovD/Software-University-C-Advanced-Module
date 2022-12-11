using System;

namespace _7._Knight_Game
{
    class Program
    {
        const int maxKnightTargets = 8;
        static void Main(string[] args)
        {
            #region Read input data
            var chessBoardSize = int.Parse(Console.ReadLine());
            var chessBoard = new string[chessBoardSize, chessBoardSize];
            #endregion

            #region Fill chessboard

            for (int row = 0; row < chessBoardSize; row++)
            {
                var currentRowColumns = Console.ReadLine();
                for (int col = 0; col < chessBoardSize; col++)
                {
                    var currentCharacter = currentRowColumns[col];
                    chessBoard[row, col] = currentCharacter.ToString();
                }
            }

            #endregion;

            #region Analyze the chessboard

            var indexOfRemovedKnights = 0;

            while (true)
            {
                var noKnightsCanBeHit = true;
                var maxTargets = int.MinValue;
                var knightWithMaxTargets = new int[2];

                for (int row = 0; row < chessBoardSize; row++)
                {
                    for (int col = 0; col < chessBoardSize; col++)
                    {
                        var currentCharacter = chessBoard[row, col];
                        if (currentCharacter == "0" || currentCharacter == "removed knight") continue;
                        var knightsThatThisOneWillHit = KnightsThatThisKnightCanHit(row, col, chessBoard);
                        if (knightsThatThisOneWillHit == 0) continue;
                        if (knightsThatThisOneWillHit > maxTargets)
                        {
                            //the first knight to be removed is the one with the most targerts; then then next one, until no knight has targets
                            maxTargets = knightsThatThisOneWillHit;
                            //save the knight with the max target coordinates
                            knightWithMaxTargets[0] = row;
                            knightWithMaxTargets[1] = col;
                        }
                        noKnightsCanBeHit = false;
                    }
                }
                if (noKnightsCanBeHit) break;
                //remove the target with the max target and move on
                chessBoard[knightWithMaxTargets[0], knightWithMaxTargets[1]] = "removed knight";
                indexOfRemovedKnights++;
            }

            Console.WriteLine(indexOfRemovedKnights);
            #endregion
        }

        static int KnightsThatThisKnightCanHit(int knightRowIndex, int knightColIndex, string[,] chessboard)
        {
            var knightsThatThisOneWillHit = 0;

            var arrayWithAllPossibleTargets = new KnightPosition[maxKnightTargets] {
                new KnightPosition(knightRowIndex - 2, knightColIndex - 1),     //top left
                new KnightPosition(knightRowIndex - 1, knightColIndex - 2),     //middle-top left
                new KnightPosition(knightRowIndex + 1, knightColIndex - 2),     //middle-bot left
                new KnightPosition(knightRowIndex + 2, knightColIndex - 1),     //bot left
                new KnightPosition(knightRowIndex - 2, knightColIndex + 1),     //top right
                new KnightPosition(knightRowIndex - 1, knightColIndex + 2),     //middle-top right
                new KnightPosition(knightRowIndex + 1, knightColIndex + 2),     //middle-bot right
                new KnightPosition(knightRowIndex + 2, knightColIndex + 1)      //bot left
            };

            foreach (var possibleKnight in arrayWithAllPossibleTargets)
            {
                var areCoordinatesValid = ValidateCoordinates(possibleKnight.rowIndex, possibleKnight.colIndex, chessboard);
                if (!areCoordinatesValid) continue;
                var positionValue = chessboard[possibleKnight.rowIndex, possibleKnight.colIndex];
                if (positionValue == "0" || positionValue == "removed knight") continue;
                knightsThatThisOneWillHit++;
            }

            return knightsThatThisOneWillHit;
        }

        static bool ValidateCoordinates(int row, int col, string[,] matrix)
        {
            if (row < 0 || col < 0) return false;
            if (row >= matrix.GetLength(0) || col >= matrix.GetLength(1)) return false;

            return true;
        }
    }

    class KnightPosition
    {
        public int rowIndex { get; set; }
        public int colIndex { get; set; }

        public KnightPosition(int row, int col)
        {
            this.rowIndex = row;
            this.colIndex = col;
        }
    }
}
