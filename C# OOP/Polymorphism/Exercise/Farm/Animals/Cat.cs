using System;
using System.Collections.Generic;
using System.Text;
using Farm.Contracts;
using Farm.FoodContracts;
using Farm.Foods;

namespace Farm.Animals
{
    public class Cat : Feline
    {
        public Cat(string breed, string livingRegion, string name, double weight) : base(breed, livingRegion, name, weight)
        {
        }

        protected override double WeightIncrease => 0.30;

        public override string AskForFood()
        {
            return "Meow";
        }

        public override string EatFood(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                return base.EatFood(food);
            }

            return $"{GetType().Name} does not eat {food.GetType().Name}!";
        }
    }
}
