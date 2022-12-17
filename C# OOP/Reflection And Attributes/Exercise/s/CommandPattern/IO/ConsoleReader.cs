namespace CommandPattern.IO
{
    using Contracts;

    using System;

    internal class ConsoleReader : IReader
    {
        public string Read() => Console.ReadLine();
    }
}
