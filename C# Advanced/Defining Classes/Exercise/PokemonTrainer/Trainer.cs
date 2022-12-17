using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public string Name { get; set; }

        public int BadgesCount { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name)
        {
            Name = name;
            BadgesCount = 0;
            Pokemons = new List<Pokemon>();
        }
    }
}
