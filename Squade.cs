using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP_4
{
    class Squade : Polygon
    {
        public Squade(Point position, uint side) : base(position, side) { }
        
        public override bool IsHitIn(Point e)
        {
            return Math.Abs(_position.X - e.X) * 2 < _side && Math.Abs(_position.Y - e.Y) * 2 < _side;
        }
    }
}
