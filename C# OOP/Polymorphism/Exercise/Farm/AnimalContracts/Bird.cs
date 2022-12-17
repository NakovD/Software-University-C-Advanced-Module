using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Contracts
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; protected set; }

        public Bird(double wingSize, string name, double weight) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
