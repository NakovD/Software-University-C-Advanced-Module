using System;
using System.Collections.Generic;

namespace StacksAndQueues
{
    class ReverseAString
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            Stack<char> stringAsStack = new Stack<char>(inputString);

            foreach (char character in stringAsStack)
            {
                Console.Write(character);
            }
        }
    }
}
