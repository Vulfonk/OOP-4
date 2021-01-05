using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP_4
{
    class Line : Shape
    {
        public Point _B;
        public Line(Point A, Point B) : base(A)
        {
            _B = B;
        }
    }
}
