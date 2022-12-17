namespace DI_Implementation.Loggers
{
    using Contracts;
    using DI_Implementation.Models.Person.Contracts;
    using DI_Implementation.Repositories.Contracts;
    using System;

    public class ConsoleLogger : ILogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        public void Fatal(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        public void Info(string message)
        {
            Console.ResetColor();

            Console.WriteLine(message);
        }

        public void Warn(string message)
        {
            Console.ForegroundColor= ConsoleColor.Yellow;

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
