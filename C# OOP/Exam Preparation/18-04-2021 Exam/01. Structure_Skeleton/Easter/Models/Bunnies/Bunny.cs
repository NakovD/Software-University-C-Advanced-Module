namespace Easter.Models.Bunnies
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes.Contracts;
    using Easter.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Bunny : IBunny
    {
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                name = value;
            }
        }

        private int energy;

        public int Energy
        {
            get => energy;

            protected set
            {
                energy = value;
                if (energy < 0) energy = 0;
            }
        }

        private ICollection<IDye> dyes;

        public ICollection<IDye> Dyes { get => dyes; }

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            dyes = new List<IDye>();
        }

        public void AddDye(IDye dye) => this.Dyes.Add(dye);

        //may need to be abstract?
        public virtual void Work()
        {
            Energy -= 10;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Energy: {Energy}");
            sb.AppendLine($"Dyes: {Dyes.Where(d => !d.IsFinished()).Count()} not finished");


            return sb.ToString().Trim();
        }
    }
}
