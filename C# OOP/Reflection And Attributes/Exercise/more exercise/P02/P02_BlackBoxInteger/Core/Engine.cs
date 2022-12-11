namespace P02_BlackBoxInteger.Core
{
    using Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine : IEngine
    {
        private readonly IReader reader;

        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var line = reader.ReadLine();
            var type = typeof(BlackBoxInteger);
            var typeInstance = Activator.CreateInstance(type, true);

            while (line != "END")
            {
                var lineData = line.Split("_");
                var methodName = lineData[0];
                var methodIntArgument = lineData[1];

                var neededMethod = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
                if (neededMethod == null) { writer.WriteLine("The provided method doesn't exist!"); continue; }

                var privateInnerValue = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).SingleOrDefault();

                neededMethod.Invoke(typeInstance, new object[] { int.Parse(methodIntArgument) });

                writer.WriteLine(privateInnerValue.GetValue(typeInstance));

                line = reader.ReadLine();
            }
        }
    }
}
