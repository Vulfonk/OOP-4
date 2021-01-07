using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP_4
{
    abstract class Shape
    {
        protected Point _position;
        public Shape() { }
        public Shape(Point position)
        {
            _position = position;
        }
        virtual public bool MoveOn(int dx, int dy, Rectangle workspace)
        {
            Point newpos = new Point(_position.X + dx, _position.Y + dy);
            bool flag = newpos.InRect(workspace);
            if (flag)
            {
                _position.X += dx;
                _position.Y += dy;
            }
            return flag;
        }
        abstract public void resize(uint new_size);
        abstract public void resizeOn(int dsize);
        abstract public bool IsHitIn(Point e);

    }
}
