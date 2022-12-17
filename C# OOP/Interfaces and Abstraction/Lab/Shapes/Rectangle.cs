using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;

        private int height;

        public int Width
        {
            get => width;
            private set
            {
                width = value;
            }
        }
        public int Height
        {
            get => height;
            private set
            {
                height = value;
            }
        }

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void Draw()
        {
            DrawLine(width, '*', '*');
            for (int i = 0; i < height - 1; ++i)
            {
                DrawLine(width, '*', ' ');
            }
            DrawLine(width, '*', '*');
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 0; i < width - 1; i++)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
