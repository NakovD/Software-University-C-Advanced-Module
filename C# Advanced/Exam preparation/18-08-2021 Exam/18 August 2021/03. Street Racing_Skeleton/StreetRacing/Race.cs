using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants { get; set; }

        public int Count { get => this.Participants.Count; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }

        public void Add(Car car)
        {
            var carExists = this.Participants.Any(participant => participant.LicensePlate == car.LicensePlate);
            if (carExists) return;
            if (this.Count == this.Capacity) return;
            if (car.HorsePower > this.MaxHorsePower) return;
            this.Participants.Add(car);
        }

        public bool Remove(string licensePlate)
        {
            var neededCar = this.Participants.SingleOrDefault(car => car.LicensePlate == licensePlate);
            if (neededCar == null) return false;
            this.Participants.Remove(neededCar);
            return true;
        }

        public Car FindParticipant(string licensePlate)
        {
            var neededCar = this.Participants.SingleOrDefault(car => car.LicensePlate == licensePlate);
            return neededCar;
        }

        public Car GetMostPowerfulCar()
        {
            if (this.Participants.Count == 0) return null;
            var sortedCars = this.Participants.OrderByDescending(car => car.HorsePower);

            var mostPowerfulCar = sortedCars.Take(1).ToList()[0];

            return mostPowerfulCar;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            sb.AppendLine(String.Join(Environment.NewLine, this.Participants));
            return sb.ToString().Trim();
        }
    }
}
