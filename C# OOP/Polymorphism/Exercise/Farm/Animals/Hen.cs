using System;
using System.Collections.Generic;
using System.Text;
using Farm.Contracts;
using Farm.FoodContracts;

namespace Farm.Animals
{
    public class Hen : Bird
    {

        public Hen(double wingSize, string name, double weight) : base(wingSize, name, weight)
        {
        }

        protected override double WeightIncrease => 0.35;

        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
