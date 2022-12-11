using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var graphicEditor = new GraphicEditor();
            var circle = new Circle();
            var rectangle = new Rectangle();
            var square = new Square();
            var quadgon = new Quadgon();

            graphicEditor.DrawShape(quadgon);
        }
    }
}
