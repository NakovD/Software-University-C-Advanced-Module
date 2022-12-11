namespace ChristmasPastryShop.Models.Cocktails
{
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    using System;

    public abstract class Cocktail : ICocktail
    {
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                name = value;
            }
        }

        private string size;

        public string Size { get => size; private set => size = value; }

        private double price;

        public double Price
        {
            get
            {
                double calculatedPrice = price;

                double twoThirds = 2.00 / 3.00;

                double oneThird = 1.00 / 3.00;

                if (Size == "Large") calculatedPrice = price;

                else if (Size == "Middle") calculatedPrice = twoThirds * price;

                else calculatedPrice = oneThird * price;

                return calculatedPrice;
            }
        }

        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            this.price = price;
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }
    }
}
