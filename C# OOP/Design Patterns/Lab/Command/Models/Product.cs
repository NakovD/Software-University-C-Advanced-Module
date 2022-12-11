namespace Command.Models
{
    using System;

    public class Product
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public void IncreasePrice(int increaseAmount)
        {
            Price += increaseAmount;
            Console.WriteLine($"The price for the {Name} has been increased by {increaseAmount}.");
        }

        public void DecreasePrice(int decreaseAmount)
        {
            if (decreaseAmount >= Price) return;

            Price -= decreaseAmount;
            Console.WriteLine($"The price for the {Name} has been decreased by {decreaseAmount}.");
        }

        public override string ToString()
        {
            return $"Current price for the {Name} product is {Price}.";
        }
    }
}
