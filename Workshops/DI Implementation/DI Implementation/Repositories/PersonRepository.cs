namespace DI_Implementation.Repositories
{
    using Loggers.Contracts;
    using Models.Person.Contracts;
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using DI_Implementation.Loggers;

    public class PersonRepository : IRepository<IPerson>
    {
        private List<IPerson> people;

        private ILogger logger;

        private PersonRepository()
        {
            people = new List<IPerson>();
        }

        public PersonRepository(ILogger logger) : this()
        {
            this.logger = logger;
        }

        public IReadOnlyCollection<IPerson> Models => people.AsReadOnly();

        public void Add(IPerson model)
        {
            people.Add(model);
            logger.Info($"New person was added with name: {model.Name}");
        }

        public IPerson? Find(string name)
        {
            var result = people.SingleOrDefault(p => p.Name == name);

            if (result == null) logger.Error($"No person with {name} name was found.");
            else logger.Info($"Found person with name: {name}");

            return result;
        }

        public bool Remove(IPerson model)
        {
            var result = people.Remove(model);

            if (result) logger.Info($"Successfully removed person with name: {model.Name}");
            else logger.Error($"No person with {model.Name} name was found.");

            return result;
        }
    }
}
