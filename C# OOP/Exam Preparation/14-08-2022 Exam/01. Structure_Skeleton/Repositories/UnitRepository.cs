namespace PlanetWars.Repositories
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> militaryUnits;

        public IReadOnlyCollection<IMilitaryUnit> Models => militaryUnits.AsReadOnly();

        public UnitRepository()
        {
            militaryUnits = new List<IMilitaryUnit>();
        }

        public void AddItem(IMilitaryUnit model) => militaryUnits.Add(model);

        public IMilitaryUnit FindByName(string name) => militaryUnits.SingleOrDefault(mUnit => mUnit.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            var neededMilitaryUnit = FindByName(name);

            if (neededMilitaryUnit == null) return false;

            militaryUnits.Remove(neededMilitaryUnit);

            return true;
        }
    }
}
