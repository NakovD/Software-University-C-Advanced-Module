namespace CarRacing.Models.Cars
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Utilities.Messages;
    using System;

    public abstract class Car : ICar
    {
        private string make;

        public string Make
        {
            get => make;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidCarMake);
                make = value;
            }
        }

        private string model;

        public string Model
        {
            get => model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException(ExceptionMessages.InvalidCarModel);
                model = value;
            }
        }

        private string vin;

        public string VIN
        {
            get => vin;

            private set
            {
                if (value.Length != 17) throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                vin = value;
            }
        }

        private int horsePower;

        public int HorsePower
        {
            get => horsePower;

            protected set
            {
                if (value < 0) throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                horsePower = value;
            }
        }

        private double fuelAvailable;

        public double FuelAvailable
        {
            get => fuelAvailable;

            private set
            {
                fuelAvailable = value;
                if (fuelAvailable < 0) fuelAvailable = 0; 
            }
        }

        private double fuelConsumptionPerRace;

        public double FuelConsumptionPerRace
        {
            get => fuelConsumptionPerRace;

            private set
            {
                if (value < 0) throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                fuelConsumptionPerRace = value;
            }
        }

        public Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            Make = make;
            Model = model;
            this.VIN = VIN;
            HorsePower = horsePower;
            FuelAvailable = fuelAvailable;
            FuelConsumptionPerRace = fuelConsumptionPerRace;
        }

        public virtual void Drive()
        {
            FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}
