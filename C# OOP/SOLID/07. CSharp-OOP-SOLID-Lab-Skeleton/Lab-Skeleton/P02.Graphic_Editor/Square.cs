using System;
using System.Collections.Generic;
using System.Text;
using P02.Graphic_Editor.Contracts;

namespace P02.Graphic_Editor
{
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("I'm Square");
        }
    }
}
