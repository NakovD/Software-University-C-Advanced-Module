using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square(5);
            DisplayPolygon(nameof(square), square);
            
            var triangle = new Triangle(5);
            DisplayPolygon(nameof(triangle), triangle);

            var octagon = new Octagon(5);
            DisplayPolygon(nameof(octagon), octagon);

        }

        public static void DisplayPolygon(string polygonType, IRegularPolygon polygon) {
            Console.WriteLine($"{polygonType} Number of Sides: {polygon.NumberOfSides}");
            Console.WriteLine($"{polygonType} Side length: {polygon.SideLength}");
            Console.WriteLine($"{polygonType} Perimeted: {polygon.GetPerimeter()}");
            Console.WriteLine($"{polygonType} Area: {Math.Round(polygon.GetArea(), 2)}");
            Console.WriteLine();
        }
    }
}
