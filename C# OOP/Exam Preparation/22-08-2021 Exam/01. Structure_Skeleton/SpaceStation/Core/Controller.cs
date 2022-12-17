namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text;

    public class Controller : IController
    {
        private AstronautRepository astronauts;

        private PlanetRepository planets;

        private int exploredPlanetsCount;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            var astronautType = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == type);
            if (astronautType == null) throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);

            IAstronaut astronaut;

            try
            {
                astronaut = Activator.CreateInstance(astronautType, astronautName) as IAstronaut;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = planets.FindByName(planetName);

            var validAstronauts = astronauts.Models.Where(a => a.Oxygen >= 60).ToList();

            if (!validAstronauts.Any()) throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);

            var misson = new Mission();

            misson.Explore(planet, validAstronauts);

            var deadAstronauts = validAstronauts.Where(a => a.Oxygen == 0).Count();

            exploredPlanetsCount = planets.Models.Where(p => !p.Items.Any()).Count();

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");

            var _astronauts = astronauts.Models;
            var astronautsAsString = string.Join(Environment.NewLine, _astronauts);
            sb.AppendLine(astronautsAsString);

            return sb.ToString().Trim();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronauts.FindByName(astronautName);
            if (astronaut == null) throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));

            astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
