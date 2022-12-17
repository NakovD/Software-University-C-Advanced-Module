using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Color = "n/a";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var carPower = this.Engine.Power != 0 ? this.Engine.Power.ToString() : "n/a";
            var carDisplacement = this.Engine.Displacement != 0 ? this.Engine.Displacement.ToString() : "n/a";
            var carWeight = this.Weight != 0 ? this.Weight.ToString() : "n/a";
            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($" {this.Engine.Model}:");
            sb.AppendLine($"   Power: {carPower}");
            sb.AppendLine($"   Displacement: {carDisplacement}");
            sb.AppendLine($"   Efficiency: {this.Engine.Efficiency}");
            sb.AppendLine($" Weight: {carWeight}");
            sb.AppendLine($" Color: {this.Color}");

            return sb.ToString();
        }
    }
}
