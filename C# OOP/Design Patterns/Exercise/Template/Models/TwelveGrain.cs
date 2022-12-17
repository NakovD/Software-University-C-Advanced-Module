namespace Template.Models
{
    using System;

    internal class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the twelve grain bread(15min).");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Mixing the ingredients for the twelve brain bread.");
        }
    }
}
