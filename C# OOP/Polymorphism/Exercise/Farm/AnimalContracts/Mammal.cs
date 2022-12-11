using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Contracts
{
    public abstract class Mammal : Animal
    {
        public string LivingRegion { get; protected set; }

        public Mammal(string livingRegion, string name, double weight) : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
