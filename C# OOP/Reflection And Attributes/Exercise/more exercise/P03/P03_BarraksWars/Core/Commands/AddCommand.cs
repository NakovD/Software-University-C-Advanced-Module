namespace P03_BarraksWars.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public class AddCommand : Command
    {

        public AddCommand(string[] data, IRepository repository, IUnitFactory factory) : base(data, repository, factory)
        {
        }

        public override string Execute()
        {
            var unitType = Data[1];

            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);

            return $"{unitType} added!";

        }
    }
}
