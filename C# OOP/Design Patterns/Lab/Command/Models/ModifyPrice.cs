namespace Command.Models
{
    using Command.Contracts;
    using System.Collections.Generic;

    public class ModifyPrice
    {
        private readonly List<ICommand> commands;

        private ICommand command;

        public ModifyPrice()
        {
            commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => this.command = command;

        public void Invoke()
        {
            commands.Add(command);
            command.Execute();
        }
    }
}
