namespace Formula1.Models
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Race : IRace
    {
        private string raceName;

        public string RaceName
        {
            get => raceName;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5) throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));

                raceName = value;
            }
        }

        private int numberOfLaps;

        public int NumberOfLaps
        {
            get => numberOfLaps;

            private set
            {
                if (value < 1) throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));

                numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; } = false;

        public ICollection<IPilot> Pilots { get; private set; }

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            Pilots = new List<IPilot>();
        }

        public void AddPilot(IPilot pilot) => Pilots.Add(pilot);

        public string RaceInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"The {RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: {NumberOfLaps}");

            var tookPlace = TookPlace ? "Yes" : "No";
            sb.AppendLine($"Took place: {tookPlace}");

            return sb.ToString().Trim();
        }
    }
}
