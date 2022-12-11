using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;

        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0) throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                length = value;
            }
        }

        private double width;

        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0) throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                width = value;
            }
        }

        private double height;

        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0) throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double SurfaceArea()
        {
            return 2 * (Length * Width) + 2 * (Length * Height) + 2 * (Width * Height);
        }

        public double LateralSurfaceArea()
        {
            return 2 * (Length * Height) + 2 * (Width * Height);
        }

        public double Volume()
        {
            return Length * Width * Height;
        }
    }
}
