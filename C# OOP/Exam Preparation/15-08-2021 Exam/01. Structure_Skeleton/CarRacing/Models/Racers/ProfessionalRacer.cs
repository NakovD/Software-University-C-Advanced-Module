namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const string racingBehaviour = "strict";

        private const int startingEXP = 30;

        public ProfessionalRacer(string username, ICar car) : base(username, racingBehaviour, startingEXP, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
    }
}
