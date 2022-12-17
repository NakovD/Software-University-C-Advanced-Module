using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Topping
    {
        private List<string> allowedTypes = new List<string>() { "Meat", "Veggies", "Cheese", "Sauce" };

        private const double minGrams = 1;

        private const double maxGrams = 50;

        private const double baseGramsModifier = 2;

        private string type;

        public string Type
        {
            get { return type; }
            set
            {
                var isTypeValid = allowedTypes.Any(type => type.ToLower() == value.ToLower());
                if (!isTypeValid) throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                type = value;
            }
        }

        private double weight;

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value < minGrams || value > maxGrams) throw new ArgumentException($"{this.Type} weight should be in the range [{minGrams}..{maxGrams}].");
                weight = value;
            }
        }

        public double Calories { get => GetCalories(); }

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        private double GetCalories()
        {
            var toppingTypeModifier = GetToppingModifier();

            return (baseGramsModifier * Weight) * toppingTypeModifier;
        }

        private double GetToppingModifier()
        {
            switch (Type.ToLower())
            {
                case "meat": return 1.2;
                case "veggies": return 0.8;
                case "cheese": return 1.1;
                default: return 0.9;
            }
        }
    }
}