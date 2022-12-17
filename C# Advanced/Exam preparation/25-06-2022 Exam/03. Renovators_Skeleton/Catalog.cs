using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public string Name { get; set; }

        public int NeededRenovators { get; set; }

        public string Project { get; set; }

        public int Count { get => this.renovators.Count; }

        public Catalog(string name, int neededRenovators, string project)
        {
            renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type)) return "Invalid renovator's information.";
            if (this.NeededRenovators == 0) return "Renovators are no more needed.";
            if (renovator.Rate > 350) return "Invalid renovator's rate.";
            this.NeededRenovators -= 1;
            this.renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            var renovator = this.renovators.SingleOrDefault(renovator => renovator.Name == name);
            if (renovator == null) return false;
            this.NeededRenovators += 1;
            this.renovators.Remove(renovator);
            return true;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            var removedRenovators = this.renovators.RemoveAll(renovator => renovator.Type == type);
            this.NeededRenovators += removedRenovators;
            return removedRenovators;
        }

        public Renovator HireRenovator(string name)
        {
            var renovator = this.renovators.SingleOrDefault(renovator => renovator.Name == name);
            if (renovator == null) return null;
            renovator.Hired = true;
            return renovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            var neededRenovators = this.renovators.Where(renovator => renovator.Days >= days).ToList();
            return neededRenovators;
        }

        public string Report()
        {
            var notHiredRenovators = this.renovators.Where(renovator => renovator.Hired == false);
            var sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");
            sb.AppendLine(string.Join(Environment.NewLine, notHiredRenovators));

            return sb.ToString().Trim();
        }
    }
}
