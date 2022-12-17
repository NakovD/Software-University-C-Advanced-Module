using Farm.Animals;
using Farm.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farm
{
    public class AnimalFactory
    {
        public Animal GetAnimal(string type, string name, double weight, string livingRegion = null, string breed = null, double wingSize = 0)
        {
            switch (type)
            {
                case "Owl": return new Owl(wingSize, name, weight);
                case "Hen": return new Hen(wingSize, name, weight);
                case "Mouse": return new Mouse(livingRegion, name, weight);
                case "Dog": return new Dog(livingRegion, name, weight);
                case "Cat": return new Cat(breed, livingRegion, name, weight);
                case "Tiger": return new Tiger(breed, livingRegion, name, weight);
                default: return null;
            }
        }
    }
}
