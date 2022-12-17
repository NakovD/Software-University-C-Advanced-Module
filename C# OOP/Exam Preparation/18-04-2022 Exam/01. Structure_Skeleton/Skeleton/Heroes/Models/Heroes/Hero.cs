namespace Heroes.Models.Heroes
{
    using Contracts;
    using System;
    using System.Text;

    public abstract class Hero : IHero
    {
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Hero name cannot be null or empty.");

                name = value;
            }
        }

        private int health;

        public int Health
        {
            get => health;

            private set
            {
                if (value < 0) throw new ArgumentException("Hero health cannot be below 0.");

                health = value;
            }
        }

        private int armour;

        public int Armour
        {
            get => armour;

            private set
            {
                if (value < 0) throw new ArgumentException("Hero armour cannot be below 0.");

                armour = value;
            }
        }

        private IWeapon weapon;

        public IWeapon Weapon
        {
            get => weapon;

            private set
            {
                if (value == null) throw new ArgumentException("Weapon cannot be null.");

                weapon = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                if (Health > 0) return true;

                return false;
            }
        }

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public void AddWeapon(IWeapon weapon) => Weapon = weapon;

        public void TakeDamage(int points)
        {
            if (points <= Armour)
            {
                Armour -= points;
                return;
            }

            var leftDamageAfterArmor = points - Armour;

            Armour = 0;

            if (leftDamageAfterArmor >= Health)
            {
                Health = 0; return;
            }

            Health -= leftDamageAfterArmor;

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}: {Name}");
            sb.AppendLine($"--Health: {Health}");
            sb.AppendLine($"--Armour: {Armour}");
            var weaponString = Weapon != null ? Weapon.Name : "Unarmed";
            sb.AppendLine($"--Weapon: {weaponString}");

            return sb.ToString().Trim();
        }
    }
}
