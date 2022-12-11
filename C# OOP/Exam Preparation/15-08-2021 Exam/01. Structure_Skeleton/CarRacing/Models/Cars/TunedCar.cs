namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double fuel = 65;

        private const double fuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, fuel, fuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();

            var reductionOfHorsePower = HorsePower * 0.03;
            HorsePower = (int)Math.Round(HorsePower - reductionOfHorsePower);
        }
    }
}
