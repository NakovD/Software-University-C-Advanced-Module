namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public IReadOnlyCollection<IPlanet> Models => planets.AsReadOnly();

        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }

        public void AddItem(IPlanet model) => planets.Add(model);

        public IPlanet FindByName(string name) => planets.SingleOrDefault(planet => planet.Name == name);

        public bool RemoveItem(string name)
        {
            var neededPlanet = FindByName(name);

            if (neededPlanet == null) return false;

            planets.Remove(neededPlanet);

            return true;
        }
    }
}
