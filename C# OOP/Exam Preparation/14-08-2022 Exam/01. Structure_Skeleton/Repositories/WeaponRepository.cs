namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories.Contracts;
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

        public void AddItem(IWeapon model) => weapons.Add(model);

        public IWeapon FindByName(string name) => weapons.SingleOrDefault(weapon => weapon.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            var neededWeapon = FindByName(name);

            if (neededWeapon == null) return false;

            weapons.Remove(neededWeapon);

            return true;
        }
    }
}
