using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public double FuelQuantity
        {
            get => fuelQuantity;

            protected set
            {
                if (value > TankCapacity) fuelQuantity = 0;
                else fuelQuantity = value;
            }
        }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; protected set; }

        public Vehicle(double fuel, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuel;
        }

        public virtual string Drive(double km)
        {
            var neededFuelForTravel = km * FuelConsumption;

            if (neededFuelForTravel > FuelQuantity) return $"{this.GetType().Name} needs refueling";

            FuelQuantity -= neededFuelForTravel;

            return $"{this.GetType().Name} travelled {km} km";
        }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }

        public virtual string GetFuelStatus()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }

        protected bool IsNewFuelValid(double newFuel)
        {
            return newFuel >= 0;
        }
    }
}
