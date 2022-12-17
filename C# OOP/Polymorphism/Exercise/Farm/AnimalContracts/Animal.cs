using Farm.FoodContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farm.Contracts
{
    public abstract class Animal
    {
        protected abstract double WeightIncrease { get; }

        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public abstract string AskForFood();

        public virtual string EatFood(Food food)
        {
            IncreaseWeight(food.Quantity);
            IncreaseFood(food.Quantity);

            return string.Empty;
        }

        protected void IncreaseFood(int amount)
        {
            FoodEaten += amount;
        }

        protected void IncreaseWeight(int foodQuantity)
        {
            Weight += foodQuantity * WeightIncrease;
        }
    }
}
