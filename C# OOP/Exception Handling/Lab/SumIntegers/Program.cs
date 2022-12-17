using System;

namespace SumIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numsUnparsed = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            long sum = 0;

            foreach (var item in numsUnparsed)
            {
                try
                {
                    sum += TryParsingElement(item);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{item}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{item}' is out of range!");
                }
                Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }

        private static int TryParsingElement(string item)
        {
            var number = int.Parse(item);
            return number;
        }
    }
}
