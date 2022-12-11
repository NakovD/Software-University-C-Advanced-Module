namespace P01_HarvestingFields.IO
{
    using Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void Write(object value) => Console.Write(value);

        public void WriteLine(object value) => Console.WriteLine(value);
    }
}
