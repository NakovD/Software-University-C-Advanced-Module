namespace CarRacing.Models.Maps
{
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Utilities.Messages;
    using System;

    //maybe should be static?
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable()) return OutputMessages.RaceCannotBeCompleted;

            if (racerOne.IsAvailable() && !racerTwo.IsAvailable()) return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);

            if (!racerOne.IsAvailable() && racerTwo.IsAvailable()) return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);

            var racerOneChanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * GetRacingBehaviourMultiplier(racerOne.RacingBehavior);

            var racerTwoChanceOfWinning = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * GetRacingBehaviourMultiplier(racerTwo.RacingBehavior);

            racerOne.Race();

            racerTwo.Race();

            var winner = racerOneChanceOfWinning > racerTwoChanceOfWinning ? racerOne : racerTwo;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
        }

        private double GetRacingBehaviourMultiplier(string racingBehavior)
        {
            switch (racingBehavior)
            {
                case "strict": return 1.2;
                default: return 1.1;
            }
        }
    }
}
