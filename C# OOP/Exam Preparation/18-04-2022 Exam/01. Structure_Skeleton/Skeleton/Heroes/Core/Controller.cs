namespace Heroes.Core
{
    using Heroes.Core.Contracts;
    using Heroes.Models.Contracts;
    using Heroes.Models.Heroes;
    using Heroes.Models.Map;
    using Heroes.Repositories;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml.Linq;

    public class Controller : IController
    {
        private HeroRepository heroes;

        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var hero = heroes.FindByName(heroName);
            if (hero == null) throw new InvalidOperationException($"Hero {heroName} does not exist.");

            var weapon = weapons.FindByName(weaponName);
            if (weapon == null) throw new InvalidOperationException($"Weapon {weaponName} does not exist.");

            if (hero.Weapon != null) throw new InvalidOperationException($"Hero {heroName} is well-armed.");

            hero.AddWeapon(weapon);

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            var hero = heroes.FindByName(name);
            if (hero != null) throw new InvalidOperationException($"The hero {name} already exists.");

            var heroType = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == type);
            if (heroType == null) throw new InvalidOperationException("Invalid hero type.");

            //maybe check if it is abstract;
            IHero newHero;

            try
            {
                newHero = Activator.CreateInstance(heroType, name, health, armour) as IHero;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }

            var isKnight = newHero.GetType() == typeof(Knight);

            heroes.Add(newHero);

            if (isKnight) return $"Successfully added Sir {name} to the collection.";


            return $"Successfully added Barbarian {name} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            var weapon = weapons.FindByName(name);
            if (weapon != null) throw new InvalidOperationException($"The weapon {name} already exists.");

            var weaponType = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(t => t.Name == type);
            if (weaponType == null) throw new InvalidOperationException("Invalid weapon type.");

            IWeapon newWeapon;
            try
            {
                newWeapon = Activator.CreateInstance(weaponType, name, durability) as IWeapon;
            }
            catch (TargetInvocationException ex)
            {

                throw ex.InnerException;
            }

            weapons.Add(newWeapon);

            return $"A {newWeapon.GetType().Name.ToLower()} {newWeapon.Name} is added to the collection.";
        }

        public string HeroReport()
        {
            var sb = new StringBuilder();

            var orderedHeroes = heroes.Models.OrderBy(h => h.GetType().Name).ThenByDescending(h => h.Health).ThenBy(h => h.Name);

            var heroesString = string.Join(Environment.NewLine, orderedHeroes);

            sb.Append(heroesString);

            return sb.ToString().Trim();
        }

        public string StartBattle()
        {
            var map = new Map();

            var validHeroes = heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();

            var result = map.Fight(validHeroes);

            return result;
        }
    }
}
