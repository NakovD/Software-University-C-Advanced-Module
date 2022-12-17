using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public List<CPU> Multiprocessor { get; set; }

        public int Count { get => this.Multiprocessor.Count; }

        public string Model { get; set; }

        public int Capacity { get; private set; }

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            this.Multiprocessor = new List<CPU>();
        }

        public void Add(CPU cpu)
        {
            if (this.Capacity == this.Multiprocessor.Count) return;

            this.Multiprocessor.Add(cpu);
        }

        public bool Remove(string brand)
        {
            var neededCPU = this.Multiprocessor.SingleOrDefault(cpu => cpu.Brand == brand);

            if (neededCPU == null) return false;

            this.Multiprocessor.Remove(neededCPU);

            return true;
        }

        public CPU MostPowerful()
        {
            if (this.Multiprocessor.Count == 0) return null;

            var sortedCPUs = this.Multiprocessor.OrderBy(cpu => cpu.Frequency);
            var mostPowerful = sortedCPUs.TakeLast(1).ToList()[0];

            return mostPowerful;
        }

        public CPU GetCPU(string brand)
        {
            var neededCPU = this.Multiprocessor.SingleOrDefault(cpu => cpu.Brand == brand);

            return neededCPU;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {this.Model}:");
            sb.AppendLine(string.Join(Environment.NewLine, this.Multiprocessor));

            return sb.ToString().Trim();
        }
    }
}
