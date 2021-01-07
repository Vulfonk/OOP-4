using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP_4
{

    class MyListShape : ListShape<ShapeViewer>
    {
        protected override ShapeViewer CreateShape(string shapeString)
        {

            ShapeViewer shape;

            if (shapeString == "Circle")
            {
                shape = new CircleViewer();
            }
            else if(shapeString == "Squade")
            {
                shape = new SquadeViewer();
            }
            else if (shapeString == "Triangle")
            {
                shape = new TriangleViewer();
            }
            else if (shapeString == "Line")
            {
                shape = new LineViewer();
            }
            else if (shapeString == "Group")
            {
                shape = new Group();
            }
            else
            {
                shape = null;
            }
            return shape;
        }
    }
}
