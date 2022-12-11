using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception($"{nameof(this.Name)} cannot be empty");
                name = value;
            }
        }

        private int money;

        public int Money
        {
            get { return money; }
            private set
            {
                if (value < 0) throw new Exception($"{nameof(this.Money)} cannot be negative");
                money = value;
            }
        }

        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
        }

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public bool BuyProduct(Product product)
        {
            if (product.Cost > Money) return false;
            this.products.Add(product);
            this.money -= product.Cost;
            return true;
        }
    }
}
