namespace SpaceStation.Models.Planets
{
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;

    public class Planet : IPlanet
    {
        private List<string> items;

        public ICollection<string> Items => items;

        private string name;

        public string Name
        {
            get => name;

            private set
            {
                //note this can be a problem;
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(Name), ExceptionMessages.InvalidPlanetName);
                name = value;
            }
        }

        public Planet(string name)
        {
            Name = name;
            items = new List<string>();
        }
    }
}
