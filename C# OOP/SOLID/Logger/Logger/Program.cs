
namespace Logger
{
    using Contracts;
    using Enums;
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var cmdInterpreter = new CommandInterpreter();
            cmdInterpreter.ReadAppenders();

            var appenders = cmdInterpreter.Appenders.ToArray();
            ILogger logger = new Logger(appenders);

            var line = Console.ReadLine();

            while (line != "END")
            {
                var data = line.Split("|", StringSplitOptions.RemoveEmptyEntries);
                var reportLevel = data[0];

                if (reportLevel == "INFO") logger.Info(data[1], data[2]);
                if (reportLevel == "WARNING") logger.Warning(data[1], data[2]);
                if (reportLevel == "ERROR") logger.Error(data[1], data[2]);
                if (reportLevel == "CRITICAL") logger.Critical(data[1], data[2]);
                if (reportLevel == "FATAL") logger.Fatal(data[1], data[2]);

                line = Console.ReadLine();
            }

            Console.WriteLine(logger);
        }
    }
}
