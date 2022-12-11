using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }

        public Car()
        {
            this.TravelledDistance = 0;
        }

        public void Travel(double kmToTravel)
        {
            var fuelToBeConsumed = kmToTravel * FuelConsumptionPerKilometer;
            if (this.FuelAmount - fuelToBeConsumed < 0) { Console.WriteLine("Insufficient fuel for the drive"); return; }
            this.FuelAmount -= fuelToBeConsumed;
            this.TravelledDistance += kmToTravel;
        }
    }
}
