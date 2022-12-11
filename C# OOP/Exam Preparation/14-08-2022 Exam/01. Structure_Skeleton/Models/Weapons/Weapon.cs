namespace PlanetWars.Models.Weapons
{
    using Contracts;
    using PlanetWars.Utilities.Messages;
    using System;

    public abstract class Weapon : IWeapon
    {
        private int desctuctionLevel;

        public int DestructionLevel
        {
            get => desctuctionLevel;

            private set
            {
                if (value < 1) throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                if (value > 10) throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);

                desctuctionLevel = value;
            }
        }

        public double Price { get; private set; }

        public Weapon(int destructionLevel, double price)
        {
            Price = price;
            DestructionLevel = destructionLevel;
        }
    }
}
