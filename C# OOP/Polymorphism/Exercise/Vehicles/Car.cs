using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditionerFuelConsumption = 0.9;

        public Car(double fuel, double consumption, double tankCapacity) : base(fuel, tankCapacity)
        {
            FuelConsumption = consumption + airConditionerFuelConsumption;
        }
    }
}
