namespace ChristmasPastryShop.Models.Delicacies
{
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    using System;

    public abstract class Delicacy : IDelicacy
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

        private double price;

        public double Price { get => price; private set => price = value; }

        public Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - {Price:F2} lv";
        }
    }
}
