namespace Prototype.Models
{
    using System;

    public class Sandwich : SandwichPrototype
    {
        private string meat;

        private string cheese;

        private string bread;

        private string vegetables;

        public Sandwich(string meat, string cheese, string bread, string vegetables)
        {
            this.meat = meat;
            this.cheese = cheese;
            this.bread = bread;
            this.vegetables = vegetables;
        }

        public override SandwichPrototype Clone()
        {
            Console.WriteLine($"Clonning sandwich with this ingredients: {GetIngredientsList()}");
            return MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngredientsList()
        {
            return $"Meat: {meat}, Cheese: {cheese}, Bread: {bread}, Veggies: {vegetables}.";
        }
    }
}
