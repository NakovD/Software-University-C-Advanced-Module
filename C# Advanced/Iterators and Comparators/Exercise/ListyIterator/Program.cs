using System;
using System.Linq;

namespace ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listIterator = null;
            ReadCommands(listIterator);
        }

        private static void ReadCommands(ListyIterator<string> listyIterator)
        {
            var currentLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var currentCommand = currentLine[0].ToLower();
            var stuffToPrint = string.Empty;
            if (currentCommand == "end") return;
            if (currentCommand == "create") listyIterator = new ListyIterator<string>(currentLine.Skip(1));
            if (currentCommand == "hasnext") stuffToPrint = listyIterator.HasNext().ToString();
            if (currentCommand == "move") stuffToPrint = listyIterator.Move().ToString();
            if (currentCommand == "printall") listyIterator.PrintAll();
            try
            {
                if (currentCommand == "print") listyIterator.Print();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (!string.IsNullOrEmpty(stuffToPrint)) Console.WriteLine(stuffToPrint);
            ReadCommands(listyIterator);
        }
    }
}
