using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine();
            var indexes = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                string currentCharacter = expression[i].ToString();

                if (currentCharacter == "(")
                {
                    indexes.Push(i);
                }

                if (currentCharacter == ")")
                {
                    var currentExprStart = indexes.Pop();
                    Console.WriteLine(expression.Substring(currentExprStart, i - currentExprStart + 1));
                }
            } 
        }
    }
}
