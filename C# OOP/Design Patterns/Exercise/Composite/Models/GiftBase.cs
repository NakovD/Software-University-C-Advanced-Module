namespace Composite.Models
{
    internal abstract class GiftBase
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        protected GiftBase(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public abstract decimal CalculateTotalPrice();
    }
}
