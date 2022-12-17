using P02.Graphic_Editor.Contracts;
using System;

namespace P02.Graphic_Editor
{
    public class Quadgon : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Im Quadgon!");
        }
    }
}
