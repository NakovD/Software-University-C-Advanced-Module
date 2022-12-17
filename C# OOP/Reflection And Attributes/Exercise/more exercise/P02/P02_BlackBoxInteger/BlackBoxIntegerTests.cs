namespace P02_BlackBoxInteger
{
    using IO;
    using IO.Contracts;
    using Core;
    using Core.Contracts;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            IReader consoleReader = new ConsoleReader();
            IWriter consoleWriter = new ConsoleWriter();

            IEngine engine = new Engine(consoleReader, consoleWriter);

            engine.Run();
        }
    }
}
