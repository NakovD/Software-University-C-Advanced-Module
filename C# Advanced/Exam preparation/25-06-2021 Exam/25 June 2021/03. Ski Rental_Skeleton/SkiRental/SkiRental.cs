using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public int Count { get => this.data.Count; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public SkiRental(string name, int capacity)
        {
            data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public void Add(Ski ski)
        {
            if (this.data.Count == this.Capacity) return;

            this.data.Add(ski);
        }

        public bool Remove(string manufacturer, string model)
        {
            var neededSki = this.data.SingleOrDefault(ski => ski.Manufacturer == manufacturer && ski.Model == model);

            if (neededSki == null) return false;

            this.data.Remove(neededSki);

            return true;
        }

        public Ski GetNewestSki()
        {
            if (this.data.Count == 0) return null;
            var sortedSki = this.data.OrderByDescending(ski => ski.Year).ToList();
            var newestSki = sortedSki[0];
            return newestSki;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            var neededSki = this.data.SingleOrDefault(ski => ski.Manufacturer == manufacturer && ski.Model == model);

            return neededSki;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            sb.AppendLine(string.Join(Environment.NewLine, this.data));
            return sb.ToString().Trim();
        }
    }
}
