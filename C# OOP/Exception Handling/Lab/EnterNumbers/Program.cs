using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    public class Program
    {
        private static List<int> numbers = new List<int>();

        private static int min = 1;

        private static int max = 100;

        private static int lastNumber = 1;

        static void Main(string[] args)
        {
            ReadNumber(min, max);

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static void ReadNumber(int min, int max)
        {
            while (numbers.Count != 10)
            {
                try
                {
                    var possibleNumber = Console.ReadLine();
                    var isNumber = int.TryParse(possibleNumber, out var number);

                    if (!isNumber) throw new ArgumentException("Invalid Number!");

                    if (number <= min || number <= lastNumber || number >= max) throw new ArgumentException($"Your number is not in range {lastNumber} - 100!");

                    numbers.Add(number);
                    lastNumber = number;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                
            }
        }
    }
}
