using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    class Rectangle
    {
        public Point _Location;
        public int _Height;
        public int _Width;
        public Rectangle() { }
        public Rectangle(Point Location, int Height, int Width)
        {
            _Location = Location;
            _Height = Height;
            _Width = Width;
        }
        
    }
}
