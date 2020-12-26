using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP_4
{
    class Circle :  Shape
    {
        public uint _radius;
        
        public Circle(Point position, uint radius):base(position)
        {
            _radius = radius;
        }

        public Circle(Circle Circle)
        {
            _position = Circle._position;
            _radius = Circle._radius;
        }
    }
}
