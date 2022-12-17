namespace Heroes.Models.Weapons
{
    using Contracts;
    using System;

    public abstract class Weapon : IWeapon
    {
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Weapon type cannot be null or empty.");

                name = value;
            }
        }

        private int durability;

        public int Durability
        {
            get => durability;

            protected set
            {
                if (value < 0) throw new ArgumentException("Durability cannot be below 0.");

                durability = value;
            }
        }

        public Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }

        public abstract int DoDamage();
    }
}
