namespace Formula1.Repositories
{
    using Formula1.Models.Contracts;
    using Formula1.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => races.AsReadOnly();

        public void Add(IRace model) => races.Add(model);

        public IRace FindByName(string name) => races.FirstOrDefault(race => race.RaceName == name);

        public bool Remove(IRace model) => races.Remove(model);
    }
}
