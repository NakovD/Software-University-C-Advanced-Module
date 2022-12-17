namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Captain : ICaptain
    {
        private string fullName;

        public string FullName
        {
            get => fullName;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);

                fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        private ICollection<IVessel> vessels;

        public ICollection<IVessel> Vessels { get => vessels; }

        public Captain(string fullName)
        {
            FullName = fullName;
            vessels = new List<IVessel>();
        }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null) throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);

            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience() => CombatExperience += 10;

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");

            if (vessels.Any())
            {
                var vesselsAsString = string.Join(Environment.NewLine, vessels);
                sb.AppendLine(vesselsAsString);
            }

            return sb.ToString().Trim();
        }
    }
}
