using System;

namespace GenericBoxOfString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var currentLine = Console.ReadLine();
                var newBox = new Box<int>(int.Parse(currentLine));
                Console.WriteLine(newBox.ToString());
            }
        }
    }
}
