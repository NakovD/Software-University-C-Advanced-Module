using System;
using System.Collections.Generic;
using System.Text;
using P02.Graphic_Editor.Contracts;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            shape.Draw();
        }
    }
}
