namespace Template.Models
{
    using System;

    internal class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the sourdough bread(35min).");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Mixing the ingredients for the sourdough bread.");
        }
    }
}
