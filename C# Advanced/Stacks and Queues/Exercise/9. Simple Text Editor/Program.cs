using System;
using System.Collections.Generic;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var numOfOperations = int.Parse(Console.ReadLine());
            var text = string.Empty;
            var previousState = new Stack<string>();

            for (int i = 0; i < numOfOperations; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var operation = input[0];

                switch (operation)
                {
                    case "1":
                        var textToAdd = input[1];
                        previousState.Push(text);
                        text = text + textToAdd;
                        break;

                    case "2":
                        var amountToErase = int.Parse(input[1]);
                        previousState.Push(text);
                        text = text.Substring(0, text.Length - amountToErase);
                        break;
                    case "3":
                        var elementIndex = int.Parse(input[1]);
                        Console.WriteLine(text[elementIndex - 1]);
                        break;
                    default:
                        text = previousState.Pop();
                        break;
                }
            }
        }
    }
}
