namespace CommandPattern.Core
{
    using Contracts;

    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {

        public string Read(string args)
        {
            var commandData = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var commandName = commandData[0];
            var commandArgs = commandData.Skip(1).ToArray();

            var currentTypes = Assembly.GetEntryAssembly().GetTypes();

            var neededCommandType = currentTypes.SingleOrDefault(t => t.Name.Contains(commandName) && !t.IsAbstract);

            if (neededCommandType == null) throw new InvalidOperationException("This command doesn't exist!");

            var commandInstance = Activator.CreateInstance(neededCommandType) as ICommand;

            var result = commandInstance.Execute(commandArgs);

            return result;
        }
    }
}
