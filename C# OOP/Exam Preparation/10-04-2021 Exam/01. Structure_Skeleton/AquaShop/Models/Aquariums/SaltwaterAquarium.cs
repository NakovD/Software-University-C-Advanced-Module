namespace AquaShop.Models.Aquariums
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int defaultCapacity = 25;

        public SaltwaterAquarium(string name) : base(name, defaultCapacity)
        {
        }
    }
}
