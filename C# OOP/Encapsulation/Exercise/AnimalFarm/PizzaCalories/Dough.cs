using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Dough
    {
        private List<string> allowedTypesOfFlour = new List<string>() { "White", "Wholegrain" };

        private List<string> allowedBakingTechs = new List<string>() { "Chewy", "Crispy", "Homemade" };

        private const double minGrams = 1;

        private const double maxGrams = 200;

        private const int baseWeightModifier = 2;

        private string flour;

        public string Flour
        {
            get { return flour; }
            private set
            {
                var isTypeValid = allowedTypesOfFlour.Any(type => type.ToLower() == value.ToLower());
                if (!isTypeValid) throw new ArgumentException("Invalid type of dough.");
                flour = value;
            }
        }

        private string bakingTechnique;

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                var isBakeTechValid = allowedBakingTechs.Any(bakeTech => bakeTech.ToLower() == value.ToLower());
                if (!isBakeTechValid) throw new ArgumentException($"Invalid type of dough.");
                bakingTechnique = value;
            }
        }

        private double weight;

        public double Weight
        {
            get => weight;

            set
            {
                if (value < minGrams || value > maxGrams) throw new Exception($"Dough weight should be in the range [{minGrams}..{maxGrams}].");
                weight = value;
            }
        }

        public double Calories { get => GetCalories(); }

        public Dough(string flour, string bakingTechnique, double weight)
        {
            Flour = flour;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private double GetCalories()
        {
            double flourTypeModifier = GetFlourTypeModifier();
            double bakingTechniqueModifier = GetBakingTechModifier();
            return (baseWeightModifier * weight) * flourTypeModifier * bakingTechniqueModifier;
        }

        private double GetBakingTechModifier()
        {
            switch (bakingTechnique.ToLower())
            {
                case "crispy": return 0.9;
                case "chewy": return 1.1;
                default: return 1;
            }
        }

        private double GetFlourTypeModifier()
        {
            switch (Flour.ToLower())
            {
                case "white": return 1.5;
                default: return 1;
            }
        }
    }
}