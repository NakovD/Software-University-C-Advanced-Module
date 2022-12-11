using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace _4._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var input = Console.ReadLine();
            var shops = new Dictionary<string, Dictionary<string, double>>();

            while (!input.Contains("Revision"))
            {
                var shopData = input.Split(", ");
                var shopName = shopData[0];
                var product = shopData[1];
                var productPrice = double.Parse(shopData[2]);

                input = Console.ReadLine();

                if (!shops.ContainsKey(shopName))
                {
                    var productsDictionary = new Dictionary<string, double>();
                    productsDictionary.Add(product, productPrice);
                    shops[shopName] = productsDictionary;
                    continue;
                }
                shops[shopName].Add(product, productPrice);

            }

            var orderedShops = shops.OrderBy(shop => shop.Key);

            foreach (var shop in orderedShops)
            {
                var productsAsString = shop.Value.Select(product => $"Product: {product.Key}, Price: {product.Value}");
                Console.WriteLine($"{shop.Key}->");
                Console.WriteLine(string.Join("\n", productsAsString));
            }
        }
    }
}
