using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ComputerArchitecture
{
    public class CPU
    {
        public string Brand { get; set; }

        public int Cores { get; set; }

        public double Frequency { get; set; }

        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Brand} CPU:");
            sb.AppendLine($"Cores: {this.Cores}");
            sb.AppendLine($"Frequency: {this.Frequency:F1} GHz");

            return sb.ToString().Trim();
        }
    }
}
