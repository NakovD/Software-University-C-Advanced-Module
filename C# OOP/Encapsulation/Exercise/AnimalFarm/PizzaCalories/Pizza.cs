using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int pizzaNameMinLength = 1;

        private const int pizzaNameMaxLength = 15;

        private const int toppingsMinValue = 0;

        private const int toppingsMaxValue = 10;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < pizzaNameMinLength || value.Length > pizzaNameMaxLength) throw new ArgumentException($"Pizza name should be between {pizzaNameMinLength} and {pizzaNameMaxLength} symbols.");
                name = value;
            }
        }

        private Dough dough;

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        private List<Topping> toppings;

        public int NumberOfToppings { get => this.toppings.Count; }

        public double TotalCalories { get => GetTotalCalories(); }

        private double GetTotalCalories()
        {
            var doughCalories = Dough.Calories;
            var allToppingsCalories = this.toppings.Sum(topping => topping.Calories);
            return doughCalories + allToppingsCalories;
        }

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            toppings = new List<Topping>();
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count < toppingsMinValue || toppings.Count > toppingsMaxValue) throw new Exception($"Number of toppings should be in range [{toppingsMinValue}..{toppingsMaxValue}].");
            this.toppings.Add(topping);
        }
    }
}
