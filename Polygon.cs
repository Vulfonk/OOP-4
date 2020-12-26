using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP_4
{
    class Polygon : Shape
    {
        public uint _side;

        public Polygon(Point position, uint side):base(position)
        {
            _side = side;
        }
        public Polygon(Polygon polygon)
        {
            this._side = polygon._side;
            this._position = polygon._position;
        }
    }
}
