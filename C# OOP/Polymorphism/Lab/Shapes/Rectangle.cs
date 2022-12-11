using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;

        private double height;

        public double Width
        {
            get => width;

            private set
            {
                width = value;
            }
        }

        public double Height
        {
            get => height;

            private set
            {
                height = value;
            }
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalculateArea()
        {
            return width * height;
        }

        public override double CalculatePerimeter()
        {
            return width * 2 + height * 2;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }


    }
}
