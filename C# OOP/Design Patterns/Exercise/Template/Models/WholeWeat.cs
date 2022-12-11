namespace Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class WholeWeat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the whole weat bread(20min).");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Mixing the ingredients for the whole weat bread.");
        }
    }
}
