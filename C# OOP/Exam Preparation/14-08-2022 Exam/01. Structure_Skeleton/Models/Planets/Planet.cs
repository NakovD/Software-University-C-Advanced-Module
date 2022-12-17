namespace PlanetWars.Models.Planets
{
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Planet : IPlanet
    {
        private UnitRepository unitRepository;

        private WeaponRepository weaponRepository;

        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidPlanetName);

                name = value;
            }
        }

        private double budget;

        public double Budget
        {
            get => budget;

            private set
            {
                if (value < 0) throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);

                budget = value;
            }
        }

        public double MilitaryPower { get => CalculateMilitaryPower(); }

        private double CalculateMilitaryPower()
        {
            double totalAmount = Army.Sum(mUnit => mUnit.EnduranceLevel) + Weapons.Sum(weapon => weapon.DestructionLevel);

            var hasAnonymousImpactUnit = Army.Any(mUnit => mUnit.GetType() == typeof(AnonymousImpactUnit));

            if (hasAnonymousImpactUnit) totalAmount = totalAmount * 1.3;

            var hasNuclearWeapon = Weapons.Any(weapon => weapon.GetType() == typeof(NuclearWeapon));

            if (hasNuclearWeapon) totalAmount = totalAmount * 1.45;

            return Math.Round(totalAmount, 3);
        }

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            unitRepository = new UnitRepository();
            weaponRepository = new WeaponRepository();
        }

        public IReadOnlyCollection<IMilitaryUnit> Army { get => unitRepository.Models; }

        public IReadOnlyCollection<IWeapon> Weapons { get => weaponRepository.Models; }

        public void AddUnit(IMilitaryUnit unit) => unitRepository.AddItem(unit);

        public void AddWeapon(IWeapon weapon) => weaponRepository.AddItem(weapon);

        public string PlanetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {budget} billion QUID");

            var forces = Army.Any() ? string.Join(", ", Army.Select(mUnit => mUnit.GetType().Name)) : "No units";
            sb.AppendLine($"--Forces: {forces}");

            var weapons = Weapons.Any() ? string.Join(", ", Weapons.Select(weapon => weapon.GetType().Name)) : "No weapons";
            sb.AppendLine($"--Combat equipment: {weapons}");

            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void Profit(double amount) => budget += amount;

        public void Spend(double amount)
        {
            if (amount > budget) throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);

            budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var item in Army)
            {
                item.IncreaseEndurance();
            }
        }
    }
}
