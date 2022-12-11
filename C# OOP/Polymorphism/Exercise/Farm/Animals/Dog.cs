using System;
using System.Collections.Generic;
using System.Text;
using Farm.Contracts;
using Farm.FoodContracts;
using Farm.Foods;

namespace Farm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string livingRegion, string name, double weight) : base(livingRegion, name, weight)
        {
        }

        protected override double WeightIncrease => 0.40;

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override string EatFood(Food food)
        {
            if (food is Meat)
            {
                return base.EatFood(food);
            }

            return $"{GetType().Name} does not eat {food.GetType().Name}!";
        }
    }
}
