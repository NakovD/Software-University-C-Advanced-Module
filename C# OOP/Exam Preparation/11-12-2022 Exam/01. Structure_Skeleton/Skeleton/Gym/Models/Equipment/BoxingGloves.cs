namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double boxingGlovesWeight = 227;

        private const decimal boxingGlovesPrice = 120;

        public BoxingGloves() : base(boxingGlovesWeight, boxingGlovesPrice)
        {
        }
    }
}
