using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PlayCatch
{
    public class Program
    {
        private static int exCaught = 0;

        private static int[] integers;

        static void Main(string[] args)
        {
            integers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            ReadCommands();

            Console.WriteLine(string.Join(", ", integers));
        }

        private static void ReadCommands()
        {
            if (exCaught == 3) return;

            var line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var command = line[0];

            line = line.Skip(1).ToArray();

            try
            {
                switch (command)
                {
                    case "Replace":
                        ReplaceElement(line);
                        break;
                    case "Print":
                        PrintPartOfCollection(line);
                        break;
                    default:
                        PrintElement(line);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("The variable is not in the correct format!");
                exCaught++;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The index does not exist!");
                exCaught++;
            }

            ReadCommands();
        }

        private static void PrintElement(string[] line)
        {
            var index = int.Parse(line[0]);

            Console.WriteLine(integers[index]);
        }

        private static void PrintPartOfCollection(string[] line)
        {
            var startIndex = int.Parse(line[0]);
            var endIndex = int.Parse(line[1]);

            ValidateIndex(startIndex);
            ValidateIndex(endIndex);

            for (int i = startIndex; i < endIndex + 1; i++)
            {
                Console.Write(integers[i]);
                if (i != endIndex) Console.Write(", ");
            }
            Console.WriteLine();
        }

        private static void ValidateIndex(int index)
        {
            var num = integers[index];
        }

        private static void ReplaceElement(string[] arguments)
        {
            var index = int.Parse(arguments[0]);
            var newElement = int.Parse(arguments[1]);

            integers[index] = newElement;
        }
    }

}
