namespace AquaShop.Models.Fish
{
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using System;

    public abstract class Fish : IFish
    {
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidFishName);
                name = value;
            }
        }

        private string species;

        public string Species
        {
            get => species;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                species = value;
            }
        }

        private int size;

        public int Size { get => size; protected set => size = value; }

        private decimal price;

        public decimal Price
        {
            get => price;

            private set
            {
                if (value <= 0) throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                price = value;
            }
        }

        public Fish(string name, string species, decimal price)
        {
            Name = name;
            Species = species;
            Price = price;
        }

        public abstract void Eat();
    }
}
