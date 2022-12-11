using System;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException($"{nameof(this.Name)} cannot be empty");
                name = value;
            }
        }

        private int cost;

        public int Cost
        {
            get { return cost; }
            private set
            {
                if (value < 0) throw new ArgumentException("Money cannot be negative");
                cost = value;
            }
        }

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}