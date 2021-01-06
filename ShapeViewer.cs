using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace OOP_4
{
    abstract class ShapeViewer : Shape, Drawable, Movable, Resizeable
    {
        public Brush _color;
        public bool _enabled;
        public ShapeViewer(Brush color, bool enabled)
        {
            setColor(color);
            _enabled = enabled;
        }
        public ShapeViewer(Point position, Brush color, bool enabled)
        {
            _position = position;
            _enabled = enabled;
            setColor(color);
        }
        virtual public bool MoveOn(int dx, int dy, int maxX, int minX, int maxY, int minY)
        {
            bool moveable = InWorkspace(maxX - dx, minX - dx, maxY - dy, minY - dy);
            if (!moveable)
            {
                return false;
            }
            else
            {
                _position.X += dx;
                _position.Y += dy;
                return true;
            }
            
        }
        public void setColor(Brush color)
        {
            _color = color;
        }
        protected bool PointIn(int maxX, int minX, int maxY, int minY, Point point)
        {
            return
                (point.X < maxX) &&
                (point.X > minX) &&
                (point.Y < maxY) &&
                (point.Y > minY);
        }
        abstract public void Draw(Graphics e);
        abstract public bool IsHitIn(Point e);
        abstract public bool InWorkspace(int maxX, int minX, int maxY, int minY);
        abstract public void resizeOn(int dsize);
        abstract public void resize(uint new_size);

    }
}
