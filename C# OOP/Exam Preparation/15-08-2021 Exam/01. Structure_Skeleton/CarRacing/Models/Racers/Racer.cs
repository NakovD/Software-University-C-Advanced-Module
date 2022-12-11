namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using System;
    using System.Text;

    public abstract class Racer : IRacer
    {
        private string username;

        public string Username
        {
            get => username;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                username = value;
            }
        }

        private string racingBehavior;

        public string RacingBehavior
        {
            get => racingBehavior;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                racingBehavior = value;
            }
        }

        private int drivingExperience;

        public int DrivingExperience
        {
            get => drivingExperience;

            protected set
            {
                if (value < 0 || value > 100) throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                drivingExperience = value;
            }
        }

        private ICar car;

        public ICar Car
        {
            get => car;

            private set
            {
                if (value == null) throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                car = value;
            }
        }

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
            Car = car;
        }

        public bool IsAvailable() => Car.FuelAvailable > Car.FuelConsumptionPerRace;

        public virtual void Race()
        {
            Car.Drive();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name}: {Username}");
            sb.AppendLine($"--Driving behavior: {RacingBehavior}");
            sb.AppendLine($"--Driving experience: {DrivingExperience}");
            sb.AppendLine($"--Car: {Car.Make} {Car.Model} ({car.VIN})");

            return sb.ToString().Trim();
        }
    }
}
