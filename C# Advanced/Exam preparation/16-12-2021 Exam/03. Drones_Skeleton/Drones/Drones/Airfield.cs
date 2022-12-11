using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }

        public int Count { get => this.Drones.Count; }

        public string Name { get; set; }

        public int Capacity { get; }

        public double LandingStrip  { get; set; }

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand)) return "Invalid drone.";
            if (drone.Range < 5 || drone.Range > 15) return "Invalid drone.";
            if (this.Capacity == this.Count) return "Airfield is full.";

            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var neededDrone = this.Drones.SingleOrDefault(drone => drone.Name == name);

            if (neededDrone == null) return false;

            this.Drones.Remove(neededDrone);

            return true;
        }

        public int RemoveDroneByBrand(string brand)
        {
            var dronesRemoved = this.Drones.RemoveAll(drone => drone.Brand == brand);

            return dronesRemoved;
        }

        public Drone FlyDrone(string name)
        {
            var neededDrone = this.Drones.SingleOrDefault(drone => drone.Name == name);

            if (neededDrone == null) return null;

            neededDrone.Available = false;

            return neededDrone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            var validDrones = this.Drones.Where(drone => drone.Range >= range);

            foreach (var drone in validDrones)
            {
                drone.Available = false;
            }

            return validDrones.ToList();
        }

        public string Report()
        {
            var availableDrones = this.Drones.Where(drone => drone.Available == true);
            var sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            sb.AppendLine(string.Join(Environment.NewLine, availableDrones));

            return sb.ToString().Trim();
        }
    }
}
