namespace Easter.Models.Eggs
{
    using Easter.Models.Eggs.Contracts;
    using Easter.Utilities.Messages;
    using System;

    public class Egg : IEgg
    {
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidEggName);
                name = value;
            }
        }

        private int energyRequired;

        public int EnergyRequired
        {
            get => energyRequired;

            private set
            {
                energyRequired = value;
                if (energyRequired < 0) energyRequired = 0;
            }
        }

        public Egg(string name, int energyRequired)
        {
            Name = name;
            EnergyRequired = energyRequired;
        }

        public void GetColored() => EnergyRequired -= 10;

        public bool IsDone() => EnergyRequired == 0;
    }
}
