using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class HeroFactory : IHeroFactory
    {
        public BaseHero CreateHero(string type, string name)
        {
            switch (type)
            {
                case "Druid": return new Druid(name);
                case "Paladin": return new Paladin(name);
                case "Rogue": return new Rogue(name);
                case "Warrior": return new Warrior(name);
                default: return null;
            }
        }
    }
}
