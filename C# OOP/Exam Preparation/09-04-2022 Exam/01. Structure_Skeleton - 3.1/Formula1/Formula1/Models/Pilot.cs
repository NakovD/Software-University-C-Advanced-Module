namespace Formula1.Models
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Text;

    public class Pilot : IPilot
    {
        private string fullName;

        public string FullName
        {
            get => fullName;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5) throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));

                fullName = value;
            }
        }

        private IFormulaOneCar car;

        public IFormulaOneCar Car
        {
            get => car;

            private set
            {
                if (value == null) throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);

                car = value;
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanRace { get; private set; } = false;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public void AddCar(IFormulaOneCar car)
        {
            CanRace = true;
            Car = car;
        }

        public void WinRace() => NumberOfWins++;

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Pilot {FullName} has {NumberOfWins} wins.");

            return sb.ToString().Trim();
        }

    }
}
