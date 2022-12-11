namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var neededType = Assembly
                                .GetEntryAssembly()
                                .GetTypes()
                                .SingleOrDefault(t => t.Name.Contains(unitType) && typeof(IUnit).IsAssignableFrom(t));
            if (neededType == null) throw new InvalidOperationException("Invalid unit type!");

            var instance = Activator.CreateInstance(neededType) as IUnit;

            return instance;
        }
    }
}
