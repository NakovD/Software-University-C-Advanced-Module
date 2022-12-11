using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class Octagon : IRegularPolygon
    {
        public Octagon(int sideLength)
        {
            NumberOfSides = 8;
            SideLength = sideLength;
        }

        public int NumberOfSides { get; set; }
        public int SideLength { get; set; }
        public double GetPerimeter() => NumberOfSides * SideLength;
        public double GetArea() => SideLength * SideLength * (2 + 2 * Math.Sqrt(2));
    }
}
