namespace Gym.Models.Athletes
{
    using Gym.Models.Athletes.Contracts;
    using Gym.Utilities.Messages;
    using System;

    public abstract class Athlete : IAthlete
    {
        private string fullName;

        public string FullName
        {
            get => fullName;

            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException(ExceptionMessages.InvalidAthleteName);

                fullName = value;
            }
        }

        private string motivation;

        public string Motivation
        {
            get => motivation;

            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);

                motivation = value;
            }
        }

        private int stamina;

        public int Stamina { get => stamina; protected set => stamina = value; }

        private int numberOfMedals;

        public int NumberOfMedals
        {
            get => numberOfMedals;

            private set
            {
                if (value < 0) throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);

                numberOfMedals = value;
            }
        }

        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            FullName = fullName;
            Motivation = motivation;
            NumberOfMedals = numberOfMedals;
            Stamina = stamina;
        }

        public abstract void Exercise();
    }
}
