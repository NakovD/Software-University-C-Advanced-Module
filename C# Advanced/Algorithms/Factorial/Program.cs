using System;

namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            var factorial = Factorial(number);

            Console.WriteLine(factorial);
        }

        private static long Factorial(int number)
        {
            if (number == 0) return 1;

            return number * Factorial(number - 1);
        }
    }
}
