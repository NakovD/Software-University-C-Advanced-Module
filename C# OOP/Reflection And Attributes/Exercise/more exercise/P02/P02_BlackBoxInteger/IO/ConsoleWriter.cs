namespace P02_BlackBoxInteger.IO
{
    using Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void Write(object value) => Console.Write(value);
        public void WriteLine(object value) => Console.WriteLine(value);
    }
}
