using System;
using System.Collections.Generic;
using System.Text;
using Farm.Contracts;
using Farm.FoodContracts;
using Farm.Foods;

namespace Farm.Animals
{
    public class Owl : Bird
    {

        public Owl(double wingSize, string name, double weight) : base(wingSize, name, weight)
        {
        }

        protected override double WeightIncrease => 0.25;

        public override string AskForFood()
        {
            return "Hoot Hoot";
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
