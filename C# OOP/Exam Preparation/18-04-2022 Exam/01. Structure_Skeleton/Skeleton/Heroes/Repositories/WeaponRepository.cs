namespace Heroes.Repositories
{
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WeaponRepository : IRepository<IWeapon>
    {

        private List<IWeapon> weapons;

        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }

        public void Add(IWeapon model) => weapons.Add(model);

        public IWeapon FindByName(string name) => weapons.SingleOrDefault(w => w.Name == name);

        public bool Remove(IWeapon model) => weapons.Remove(model);
    }
}
