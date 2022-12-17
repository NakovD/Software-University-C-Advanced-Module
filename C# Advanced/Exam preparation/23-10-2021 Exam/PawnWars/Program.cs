using System;
using System.ComponentModel;
using System.Numerics;

namespace PawnWars
{
    enum Turns
    {
        White,
        Black
    }
    internal class Program
    {
        private static int matrixSize = 8;

        private static string[,] matrix = new string[matrixSize, matrixSize];

        private static bool gameOver = false;

        private static Turns currentTurn = Turns.White;

        private static Pawn lastCellCoordinates = new Pawn(0, 0);

        private static bool hasCaptured = false;

        static void Main(string[] args)
        {
            (Pawn black, Pawn white) = ReadMatrix();

            Play(black, white);

            var lastCellCode = GetLastCellCode();

            var winner = currentTurn == Turns.White ? "White" : "Black";

            if (hasCaptured)
            {
                Console.WriteLine($"Game over! {winner} capture on {lastCellCode}.");
            }
            else
            {
                Console.WriteLine($"Game over! {winner} pawn is promoted to a queen at {lastCellCode}.");
            }
        }

        private static string GetLastCellCode()
        {
            var row = matrixSize - lastCellCoordinates.Row;
            var col = string.Empty;

            switch (lastCellCoordinates.Col)
            {
                case 0:
                    col = "a";
                    break;
                case 1:
                    col = "b";
                    break;
                case 2:
                    col = "c";
                    break;
                case 3:
                    col = "d";
                    break;
                case 4:
                    col = "e";
                    break;
                case 5:
                    col = "f";
                    break;
                case 6:
                    col = "g";
                    break;
                default:
                    col = "h";
                    break;
            }

            return $"{col}{row}";
        }

        private static void Play(Pawn black, Pawn white)
        {
            if (currentTurn == Turns.White) MovePawnAndEliminateAtDiagonals(white);
            else MovePawnAndEliminateAtDiagonals(black);

            if (gameOver) return;

            currentTurn = currentTurn == Turns.White ? Turns.Black : Turns.White;

            Play(black, white);
        }

        private static void MovePawnAndEliminateAtDiagonals(Pawn pawn)
        {
            EliminateByDiagonal(pawn);
            var hasWon = MovePawn(pawn);
            if (hasWon) { gameOver = true; SetLastCellCoordinates(pawn.Row, pawn.Col); }
        }

        private static void EliminateByDiagonal(Pawn pawn)
        {
            if (currentTurn == Turns.White)
            {
                var leftDiagonal = GetDiagonal("left", pawn);
                if (leftDiagonal != null)
                {
                    var leftDiagonalValue = matrix[leftDiagonal.Row, leftDiagonal.Col];
                    if (leftDiagonalValue == "b")
                    {
                        gameOver = true;
                        SetLastCellCoordinates(leftDiagonal.Row, leftDiagonal.Col);
                        hasCaptured = true;
                        return;
                    }
                }

                var rightDiagonal = GetDiagonal("right", pawn);
                if (rightDiagonal != null)
                {
                    var rightDiagonalValue = matrix[rightDiagonal.Row, rightDiagonal.Col];
                    if (rightDiagonalValue == "b")
                    {
                        gameOver = true;
                        SetLastCellCoordinates(rightDiagonal.Row, rightDiagonal.Col);
                        hasCaptured = true;
                        return;
                    }
                }

            }
            else
            {
                var leftDiagonal = GetDiagonal("left", pawn);
                if (leftDiagonal != null)
                {
                    var leftDiagonalValue = matrix[leftDiagonal.Row, leftDiagonal.Col];
                    if (leftDiagonalValue == "w")
                    {
                        gameOver = true;
                        SetLastCellCoordinates(leftDiagonal.Row, leftDiagonal.Col);
                        hasCaptured = true;
                        return;
                    }
                }
                
                var rightDiagonal = GetDiagonal("right", pawn);
                if (rightDiagonal != null)
                {
                    var rightDiagonalValue = matrix[rightDiagonal.Row, rightDiagonal.Col];
                    if (rightDiagonalValue == "w")
                    {
                        gameOver = true;
                        SetLastCellCoordinates(rightDiagonal.Row, rightDiagonal.Col);
                        hasCaptured = true;
                        return;
                    }
                }
            }
        }

        private static void SetLastCellCoordinates(int row, int col)
        {
            lastCellCoordinates.Row = row;
            lastCellCoordinates.Col = col;
        }

        private static Diagonal GetDiagonal(string diagonal, Pawn pawn)
        {
            (int row, int col) = GetDiagonalCoordinates(diagonal, pawn);
            var areCoordinatesValid = ValidateCoordinate(row) && ValidateCoordinate(col);
            if (!areCoordinatesValid) return null;
            return new Diagonal(row, col);
        }

        private static (int row, int col) GetDiagonalCoordinates(string diagonal, Pawn pawn)
        {
            if (currentTurn == Turns.White)
            {
                if (diagonal == "left") return (pawn.Row - 1, pawn.Col - 1);
                return (pawn.Row - 1, pawn.Col + 1);
            }

            if (diagonal == "left") return (pawn.Row + 1, pawn.Col - 1);
            return (pawn.Row + 1, pawn.Col + 1);
        }

        private static bool ValidateCoordinate(int cellCoordinate)
        {
            return cellCoordinate >= 0 && cellCoordinate < matrixSize;
        }


        private static bool MovePawn(Pawn pawn)
        {
            var nextRow = currentTurn == Turns.White ? pawn.Row - 1 : pawn.Row + 1;
            var nextCol = pawn.Col;
            var isNextRowValid = ValidateCoordinate(nextRow);

            if (isNextRowValid)
            {
                matrix[pawn.Row, pawn.Col] = "-";
                pawn.Row = nextRow;
                pawn.Col = nextCol;
                if (currentTurn == Turns.White) matrix[pawn.Row, pawn.Col] = "w";
                else matrix[pawn.Row, pawn.Col] = "b";
            }

            return !isNextRowValid;
        }

        private static (Pawn, Pawn) ReadMatrix()
        {
            Pawn blackPawn = null;
            Pawn whitePawn = null;

            for (int row = 0; row < matrixSize; row++)
            {
                var currentLine = Console.ReadLine();

                for (int col = 0; col < matrixSize; col++)
                {
                    var currentCharacter = currentLine[col].ToString();
                    matrix[row, col] = currentCharacter;
                    if (currentCharacter == "b")
                    {
                        blackPawn = new Pawn(row, col);
                        continue;
                    }
                    if (currentCharacter == "w")
                    {
                        whitePawn = new Pawn(row, col);
                        continue;
                    }
                }
            }

            return (blackPawn, whitePawn);
        }
    }

    public class Pawn
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Pawn(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }

    public class Diagonal
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public Diagonal(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
