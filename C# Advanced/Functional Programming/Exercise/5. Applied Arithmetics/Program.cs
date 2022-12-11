using System;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse);
            var command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                var commandToLower = command.ToLower();
                command = Console.ReadLine();
                if (commandToLower.Contains("print"))
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    continue;
                }

                var arithmeticOperation = GetArithmeticOperation(commandToLower);
                numbers = numbers.Select(arithmeticOperation);
            }
        }


        static Func<int, int> GetArithmeticOperation(string command)
        {
            if (command.Contains("add")) return n => n + 1;
            if (command.Contains("multiply")) return n => n * 2;
            return n => n - 1;
        }
    }
}
