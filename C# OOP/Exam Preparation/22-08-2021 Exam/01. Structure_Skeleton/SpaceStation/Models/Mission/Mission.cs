namespace SpaceStation.Models.Mission
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            var validAstronauts = astronauts.Where(a => a.CanBreath);

            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath)
                {
                    var item = planet.Items.FirstOrDefault();
                    if (item == null) return;
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                }
            }
        }
    }
}
