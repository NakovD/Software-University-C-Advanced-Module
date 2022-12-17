namespace Heroes.Models.Map
{
    using Contracts;
    using Heroes;
    using System.Collections.Generic;
    using System.Linq;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = players.Where(player => player.GetType() == typeof(Knight));
            var barbarians = players.Where(player => player.GetType() == typeof(Barbarian));

            while (knights.Any(k => k.IsAlive) && barbarians.Any(b => b.IsAlive))
            {
                foreach (var knight in knights)
                {
                    if (!knight.IsAlive) continue;

                    foreach (var barbarian in barbarians)
                    {
                        if (!barbarian.IsAlive) continue;
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (!barbarian.IsAlive) continue;

                    foreach (var knight in knights)
                    {
                        if (!knight.IsAlive) continue;
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                    }
                }
            }

            var knightsAreWinners = knights.Any(k => k.IsAlive);

            if (knightsAreWinners)
            {
                var knigthsCasualties = knights.Where(knight => !knight.IsAlive);

                return $"The knights took {knigthsCasualties.Count()} casualties but won the battle.";
            }
            else
            {
                var barbariansCasualties = barbarians.Where(barbarian => !barbarian.IsAlive);
                return $"The barbarians took {barbariansCasualties.Count()} casualties but won the battle.";
            }
        }
    }
}
