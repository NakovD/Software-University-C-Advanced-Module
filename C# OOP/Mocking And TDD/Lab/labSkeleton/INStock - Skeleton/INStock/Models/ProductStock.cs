using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public IProduct this[int index] { get => products[index]; set => products[index] = value; }

        public int Count => products.Count;

        public ProductStock()
        {
            products = new List<IProduct>();
        }

        public void Add(IProduct product)
        {
            products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            return products.Contains(product);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= products.Count) throw new IndexOutOfRangeException("Invalid index.");
            return products[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            var neededProducts = products.Where(p => p.Price == (decimal)price);

            return neededProducts;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            var validProducts = products.Where(p => p.Quantity == quantity);

            return validProducts;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            var validProducts = products.Where(p => p.Price >= (decimal)lo && p.Price <= (decimal)hi);

            return validProducts;
        }

        public IProduct FindByLabel(string label)
        {
            var neededProduct = products.SingleOrDefault(p => p.Label == label);

            if (neededProduct == null) throw new ArgumentException("Product with the provided label doesn't exist.");

            return neededProduct;
        }

        public IProduct FindMostExpensiveProduct()
        {
            var mostExpensiveProduct = products.OrderByDescending(p => p.Price).ToList()[0];

            return mostExpensiveProduct;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        public bool Remove(IProduct product)
        {
            return products.Remove(product);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
