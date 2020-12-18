using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP_4
{
    class Shape
    {
        protected Point _position;
        public Shape() { }
        public Shape(Point position)
        {
            _position = position;
        }
    }
}
