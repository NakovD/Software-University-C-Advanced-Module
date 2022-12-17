using System;

namespace Interfaces
{
    public class Triangle : IRegularPolygon
    {
        public int SideLength { get; set; }
        public int NumberOfSides { get; set; }
        public Triangle(int length)
        {
            NumberOfSides = 3;
            SideLength = length;
        }
        public double GetPerimeter() => SideLength * NumberOfSides;
        public double GetArea() => SideLength * SideLength * Math.Sqrt(3) / 4;

        
    }
}
