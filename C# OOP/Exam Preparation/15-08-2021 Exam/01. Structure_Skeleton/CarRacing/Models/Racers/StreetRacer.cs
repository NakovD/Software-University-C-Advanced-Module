namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const string racingBehaviour = "aggressive";

        private const int startingEXP = 10;

        public StreetRacer(string username, ICar car) : base(username, racingBehaviour, startingEXP, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
