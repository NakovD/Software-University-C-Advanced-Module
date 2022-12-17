using System;
using System.Collections.Generic;
using System.Text;
using Farm.Contracts;
using Farm.FoodContracts;
using Farm.Foods;

namespace Farm.Animals
{
    public class Mouse : Mammal
    {
        private const double weightIncrease = 0.10;

        public Mouse(string livingRegion, string name, double weight) : base(livingRegion, name, weight)
        {
        }

        protected override double WeightIncrease => 0.10;

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override string EatFood(Food food)
        {
            if (food is Vegetable || food is Fruit)
            {
                return base.EatFood(food);
            }

            return $"{GetType().Name} does not eat {food.GetType().Name}!";
        }
    }
}
