namespace CarRacing.Repositories
{
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> racers;

        public IReadOnlyCollection<IRacer> Models => racers.AsReadOnly();

        public RacerRepository()
        {
            racers = new List<IRacer>();
        }

        public void Add(IRacer model)
        {
            if (model == null) throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);

            racers.Add(model);
        }

        public IRacer FindBy(string property) => racers.SingleOrDefault(racer => racer.Username == property);

        public bool Remove(IRacer model) => racers.Remove(model);
    }
}
