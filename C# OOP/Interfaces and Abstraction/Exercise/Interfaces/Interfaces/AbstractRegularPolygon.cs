using System;
using System.Collections.Generic;
using System.Linq;
namespace Interfaces
{
    public abstract class AbstractRegularPolygon
    {
        public AbstractRegularPolygon(int sides, int length)
        {
            NumberOfSides = sides;
            SideLength = length;
        }

        public int NumberOfSides { get; set; }
        public int SideLength { get; set; }

        public double GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }

        public abstract double GetArea();
    }
}
