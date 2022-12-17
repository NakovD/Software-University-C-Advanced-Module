namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => astronauts.AsReadOnly();

        public void Add(IAstronaut model) => astronauts.Add(model);

        public IAstronaut FindByName(string name) => astronauts.SingleOrDefault(a => a.Name == name);

        public bool Remove(IAstronaut model) => astronauts.Remove(model);
    }
}
