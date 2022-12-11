namespace Interfaces
{
    public class Square : IRegularPolygon
    {
        public Square(int length)
        {
            NumberOfSides = 4;
            SideLength = length;
        }

        public int NumberOfSides { get; set; }
        public int SideLength { get; set; }

        public double GetArea() => SideLength * SideLength;

        public double GetPerimeter() => SideLength * NumberOfSides;
    }
}
