using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double airConditionerFuelConsumption = 1.6;
        public Truck(double fuel, double consumption, double tankCapacity) : base(fuel, tankCapacity)
        {
            FuelConsumption = consumption + airConditionerFuelConsumption; 
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += 0.95 * liters;
        }
    }
}
