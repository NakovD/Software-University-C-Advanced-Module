using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        public string Type { get; set; }

        public double Weight { get; set; }

        public Cargo(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }
    }
}
