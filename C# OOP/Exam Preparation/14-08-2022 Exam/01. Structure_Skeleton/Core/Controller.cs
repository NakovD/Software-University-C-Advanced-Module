namespace PlanetWars.Core
{
    using Contracts;
    using Models.Planets.Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Utilities.Messages;
    using Repositories;
    using Repositories.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var (doesPlanetExist, planet) = ValidatePlanet(planetName);
            if (!doesPlanetExist) throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));

            var (doesMilitaryUnitExist, type) = ValidateType(unitTypeName);
            if (!doesMilitaryUnitExist) throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));

            var doesPlanetAlreadyHaveThisUnit = planet.Army.Any(unit => unit.GetType().Name == unitTypeName);
            if (doesPlanetAlreadyHaveThisUnit) throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));

            var newUnit = Activator.CreateInstance(type) as IMilitaryUnit;

            planet.Spend(newUnit.Cost);

            planet.AddUnit(newUnit);

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var (doesPlanetExist, planet) = ValidatePlanet(planetName);
            if (!doesPlanetExist) throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));

            var doesPlanetAlreadyHaveThisWeapon = planet.Weapons.Any(unit => unit.GetType().Name == weaponTypeName);
            if (doesPlanetAlreadyHaveThisWeapon) throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));

            var (doesWeaponExist, type) = ValidateType(weaponTypeName);
            if (!doesWeaponExist) throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));

            IWeapon newWeapon;

            try
            {
                newWeapon = Activator.CreateInstance(type, destructionLevel) as IWeapon;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }


            planet.Spend(newWeapon.Price);

            planet.AddWeapon(newWeapon);

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            var (doestPlanetExist, existingPlanet) = ValidatePlanet(name);
            if (doestPlanetExist) return string.Format(OutputMessages.ExistingPlanet, name);

            var planet = new Planet(name, budget);

            planets.AddItem(planet);

            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            var planetsData = planets.Models;

            var orderedPlanets = planetsData.OrderByDescending(planet => planet.MilitaryPower).ThenBy(planet => planet.Name);

            foreach (var item in orderedPlanets)
            {
                sb.AppendLine(item.PlanetInfo());
            }

            return sb.ToString().Trim();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var (_, firstPlanet) = ValidatePlanet(planetOne);
            var (_, secondPlanet) = ValidatePlanet(planetTwo);

            IPlanet winner = GetWinner(firstPlanet, secondPlanet);

            if (winner == null)
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                secondPlanet.Spend(secondPlanet.Budget / 2);
                return OutputMessages.NoWinner;
            }


            var loser = firstPlanet.Name == winner.Name ? secondPlanet : firstPlanet;

            winner.Spend(winner.Budget / 2);

            winner.Profit(loser.Budget / 2);

            var sumOfLoserUnits = loser.Army.Sum(mUnit => mUnit.Cost);
            var sumOfLoserWeapons = loser.Weapons.Sum(weapon => weapon.Price);

            winner.Profit(sumOfLoserUnits + sumOfLoserWeapons);

            planets.RemoveItem(loser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }

        private IPlanet GetWinner(IPlanet firstPlanet, IPlanet secondPlanet)
        {
            if (firstPlanet.MilitaryPower != secondPlanet.MilitaryPower)
            {
                return firstPlanet.MilitaryPower > secondPlanet.MilitaryPower ? firstPlanet : secondPlanet;
            }

            var doesFirstPlanetHaveNuclear = firstPlanet.Weapons.Any(weapon => weapon.GetType() == typeof(NuclearWeapon));
            var doesSecondPlanetHaveNuclear = secondPlanet.Weapons.Any(weapon => weapon.GetType() == typeof(NuclearWeapon));

            if (doesFirstPlanetHaveNuclear != doesSecondPlanetHaveNuclear)
            {
                return doesFirstPlanetHaveNuclear ? firstPlanet : secondPlanet;
            }

            return null;
        }

        public string SpecializeForces(string planetName)
        {
            var (doesPlanetExist, planet) = ValidatePlanet(planetName);
            if (!doesPlanetExist) throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));

            var thereAreNoMilitaryUnits = planet.Army.Count == 0;
            if (thereAreNoMilitaryUnits) throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);

            planet.Spend(1.25);

            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        private (bool, IPlanet) ValidatePlanet(string name)
        {
            var neededPlanet = planets.FindByName(name);

            if (neededPlanet == null) return (false, null);

            return (true, neededPlanet);
        }

        private (bool, Type) ValidateType(string typeName)
        {
            var neededType = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(type => type.Name == typeName);

            if (neededType == null) return (false, null);

            return (true, neededType);
        }
    }
}
