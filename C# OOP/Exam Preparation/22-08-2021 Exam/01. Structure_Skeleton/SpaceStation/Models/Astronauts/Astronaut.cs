namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    using SpaceStation.Models.Bags.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Linq;
    using System.Text;

    public abstract class Astronaut : IAstronaut
    {
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                //note this can be a problem;
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(Name), ExceptionMessages.InvalidAstronautName);
                name = value;
            }
        }

        private double oxygen;

        public double Oxygen
        {
            get => oxygen;

            protected set
            {
                if (value < 0) throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                oxygen = value;
            }
        }

        public bool CanBreath => Oxygen > 0;

        public IBag Bag { get; private set; }

        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            Bag = new Backpack();
        }

        public virtual void Breath()
        {
            if (Oxygen - 10 < 0)
            {
                Oxygen = 0; 
                return;
            }

            Oxygen -= 10;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Oxygen: {Oxygen}");

            var itemsAsString = Bag.Items.Any() ? string.Join(", ", Bag.Items) : "none";
            sb.AppendLine($"Bag items: {itemsAsString}");

            return sb.ToString().Trim();
        }
    }
}
