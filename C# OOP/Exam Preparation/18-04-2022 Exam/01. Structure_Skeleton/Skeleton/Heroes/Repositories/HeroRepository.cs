namespace Heroes.Repositories
{
    using Heroes.Models.Contracts;
    using Heroes.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;

        public IReadOnlyCollection<IHero> Models => heroes.AsReadOnly();

        public HeroRepository()
        {
            heroes = new List<IHero>();
        }

        public void Add(IHero model) => heroes.Add(model);

        public IHero FindByName(string name) => heroes.SingleOrDefault(h => h.Name == name);

        public bool Remove(IHero model) => heroes.Remove(model);
    }
}
