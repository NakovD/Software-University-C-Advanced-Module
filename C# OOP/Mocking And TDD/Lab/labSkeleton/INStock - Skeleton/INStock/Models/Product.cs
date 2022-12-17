using INStock.Contracts;
using System;
using System.Diagnostics.CodeAnalysis;

namespace INStock.Models
{
    public class Product : IProduct
    {
        private string label;

        private decimal price;

        public string Label
        {
            get => label;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Product label should be a valid uniqie string!");
                label = value;
            }
        }

        public decimal Price
        {
            get => price;

            private set
            {
                if (value <= 0) throw new ArgumentException("Product price should be positive!");
                price = value;
            }
        }

        public int Quantity { get; private set; }

        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public int CompareTo([AllowNull] IProduct other)
        {
            if (Label == other.Label) return 0;

            return Label.CompareTo(other.Label);
        }
    }
}
