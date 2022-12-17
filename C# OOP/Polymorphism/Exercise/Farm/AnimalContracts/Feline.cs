using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Contracts
{
    public abstract class Feline : Mammal
    {
        public string Breed { get; private set; }

        public Feline(string breed, string livingRegion, string name, double weight) : base(livingRegion, name, weight)
        {
            Breed = breed;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
