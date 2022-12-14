using System.Text;
using System.Xml.Linq;

namespace Drones
{
    public class Drone
    {
        public string Name { get; set; }

        public string Brand { get; set; }

        public int Range { get; set; }

        public bool Available { get; set; }

        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
            Available = true;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drone: {this.Name}");
            sb.AppendLine($"Manufactured by: {this.Brand}");
            sb.AppendLine($"Range: {this.Range} kilometers");

            return sb.ToString().Trim();
        }
    }
}
