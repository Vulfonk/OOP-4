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
        Dictionary<String, Brush> _color_Dictionary = new Dictionary<String, Brush>
        {
            ["Белый"] = Brushes.White,
            ["Красный"] = Brushes.Red,
            ["Зеленый"] = Brushes.Green,
            ["Синий"] = Brushes.Blue,
            ["Коричневый"] = Brushes.Brown,
            ["Желтый"] = Brushes.Yellow,
            ["Черный"] = Brushes.Black

        }; 

        protected override ShapeViewer CreateShape(string shapeString, string shapePosition, string shapeColor, int size)
        {
            ShapeViewer shape;

            string[] positionString = shapePosition.Split(',');
            int X = Int32.Parse(positionString[0]);
            int Y = Int32.Parse(positionString[1]);

            Brush color = _color_Dictionary[shapeColor];
            Point position = new Point(X, Y);

            if (shapeString == "Circle")
            {
                shape = new CircleViewer(position, (uint)size, color, false);
            }
            else if(shapeString == "Squade")
            {
                shape = new SquadeViewer(position, (uint)size, color, false);
            }
            else if (shapeString == "Triangle")
            {
                shape = new TriangleViewer(position, (uint)size, color, false);
            }
            else if (shapeString == "Line")
            {
                Point A = new Point(
                    Int32.Parse(positionString[0]), 
                    Int32.Parse(positionString[1]));

                Point B = new Point(
                    Int32.Parse(positionString[2]),
                    Int32.Parse(positionString[3]));
                shape = new LineViewer(A, B, color, false);
            }
            else
            {
                shape = null;
            }
            return shape;
        }
    }
}
