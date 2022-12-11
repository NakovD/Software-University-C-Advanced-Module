using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var lengthOfInput = input.Length;
            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            var stack = new Stack<string>();
            var isBalanced = true;

            for (int i = 0; i < lengthOfInput; i++)
            {
                var currentSymbol = input[i].ToString();
                if (currentSymbol == "(" || currentSymbol == "{" || currentSymbol == "[")
                {
                    stack.Push(currentSymbol);
                }
                if (currentSymbol == ")" || currentSymbol == "}" || currentSymbol == "]")
                {
                    var comparation = CompareOppositeParentheses(stack.Pop(), currentSymbol);
                    if (comparation) continue;
                    isBalanced = false;
                    break;
                }
            }

            if (isBalanced) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }

        static bool CompareOppositeParentheses(string firstParentheses, string secondParentheses)
        {
            if (firstParentheses == "{")
            {
                return secondParentheses == "}" ? true : false;
            }
            if (firstParentheses == "[")
            {
                return secondParentheses == "]" ? true : false;
            }

            return secondParentheses == ")" ? true : false;
        }
    }
}
