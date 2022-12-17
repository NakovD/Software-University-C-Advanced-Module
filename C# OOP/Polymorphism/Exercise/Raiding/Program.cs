using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        private static List<BaseHero> heroes = new List<BaseHero>();
        static void Main(string[] args)
        {
            var neededHeroes = int.Parse(Console.ReadLine());
            var heroFactory = new HeroFactory();

            while (heroes.Count < neededHeroes)
            {
                var heroName = Console.ReadLine();
                var heroType = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(heroName)) continue;
                var hero = heroFactory.CreateHero(heroType, heroName);
                if (hero is null) { Console.WriteLine("Invalid hero!"); continue; }
                heroes.Add(hero);
            }

            var bossPower = long.Parse(Console.ReadLine());
            long heroesPower = heroes.Sum(hero => hero.Power);

            heroes.ForEach(hero => Console.WriteLine(hero.CastAbility()));

            if (heroesPower >= bossPower) Console.WriteLine("Victory!");
            else Console.WriteLine("Defeat...");
        }
    }
}
