namespace P01_HarvestingFields.IO
{
    using Contracts;

    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
