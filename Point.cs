using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    class Point
    {
        public int _x, _y;
        public Point() { }
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public Point(Point point)
        {
            _x = point._x;
            _y = point._y;
        }

    }
}
