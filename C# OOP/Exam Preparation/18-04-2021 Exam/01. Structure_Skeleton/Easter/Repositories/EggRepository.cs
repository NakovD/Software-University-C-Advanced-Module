﻿namespace Easter.Repositories
{
    using Easter.Models.Eggs.Contracts;
    using Easter.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs;

        public EggRepository()
        {
            eggs = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => eggs.AsReadOnly();

        public void Add(IEgg model) => eggs.Add(model);

        public IEgg FindByName(string name) => eggs.FirstOrDefault(b => b.Name == name);

        public bool Remove(IEgg model) => eggs.Remove(model);
    }
}
