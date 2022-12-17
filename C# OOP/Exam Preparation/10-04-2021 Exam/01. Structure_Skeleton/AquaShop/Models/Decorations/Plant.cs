namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int defaultCompoft = 5;

        private const decimal defaultPrice = 10;

        public Plant() : base(defaultCompoft, defaultPrice)
        {
        }
    }
}
