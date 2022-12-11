namespace P01_HarvestingFields
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}
