namespace CommandPattern.Core
{
    using Contracts;

    using CommandPattern.IO.Contracts;
    using CommandPattern.IO;
    using System;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        private readonly IReader reader;

        private readonly IWriter writer;

        private Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public Engine(ICommandInterpreter commandInterpreter) : this()
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            var line = reader.Read();

            while (!line.Contains("Exit"))
            {
                try
                {
                    var result = commandInterpreter.Read(line);
                    writer.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                line = reader.Read();
            }
        }
    }
}
