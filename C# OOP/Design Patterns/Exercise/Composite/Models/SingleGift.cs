namespace Composite.Models
{
    internal class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price) : base(name, price)
        {
        }

        public override decimal CalculateTotalPrice() => Price;
    }
}
