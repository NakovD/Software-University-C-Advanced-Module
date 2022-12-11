namespace Gym.Models.Gyms
{
    using Contracts;
    using Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using global::Gym.Models.Equipment.Contracts;
    using global::Gym.Models.Athletes.Contracts;
    using System.Linq;
    using System.Text;

    public abstract class Gym : IGym
    {
        private string name;

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException(ExceptionMessages.InvalidGymName);
                name = value;
            }
        }

        private int capacity;

        public int Capacity { get => capacity; private set => capacity = value; }

        public double EquipmentWeight => Equipment.Sum(eq => eq.Weight);

        private ICollection<IEquipment> equipment;

        public ICollection<IEquipment> Equipment { get => equipment; }

        private ICollection<IAthlete> athletes;

        public ICollection<IAthlete> Athletes { get => athletes; }

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            athletes = new List<IAthlete>();
            equipment = new List<IEquipment>();
        }

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity == Athletes.Count) throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);

            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment) => Equipment.Add(equipment);

        public void Exercise()
        {
            foreach (var item in Athletes)
            {
                item.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {GetType().Name}:");

            var athletesAsString = Athletes.Any() ? string.Join(", ", Athletes.Select(a => a.FullName)) : "No athletes";
            sb.AppendLine($"Athletes: {athletesAsString}");
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return sb.ToString().Trim();
        }

        public bool RemoveAthlete(IAthlete athlete) => Athletes.Remove(athlete);
    }
}
