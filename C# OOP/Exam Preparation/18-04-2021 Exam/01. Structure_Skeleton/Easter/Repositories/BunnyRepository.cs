namespace Easter.Repositories
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunnies;

        public BunnyRepository()
        {
            bunnies = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => bunnies.AsReadOnly();

        public void Add(IBunny model) => bunnies.Add(model);

        public IBunny FindByName(string name) => bunnies.FirstOrDefault(b => b.Name == name);

        public bool Remove(IBunny model) => bunnies.Remove(model);
    }
}
