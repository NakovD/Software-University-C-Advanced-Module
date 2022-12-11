using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public bool HasPeople { get; set; }

        public Bus(double fuel, double consumption, double tankCapacity) : base(fuel, tankCapacity)
        {
            this.FuelConsumption = consumption;
            HasPeople = false;
        }

        public override string Drive(double km)
        {
            if (HasPeople) return DriveWithPeople(km);
            return DriveEmpty(km);
        }

        private string DriveEmpty(double km)
        {
            return base.Drive(km);
        }

        private string DriveWithPeople(double km)
        {
            FuelConsumption += 1.4;
            var result = base.Drive(km);
            FuelConsumption -= 1.4;
            return result;
        }
    }
}
