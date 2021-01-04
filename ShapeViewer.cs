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
        public void MoveOn(int dx, int dy, int maxX, int minX, int maxY, int minY)
        {
            if (InWorkspace(maxX - dx, minX - dx, maxY - dy, minY - dy))
            {
                _position.X += dx;
                _position.Y += dy;
            }
        }
        public void setColor(Brush color)
        {
            _color = color;
        }
        abstract public void Draw(PaintEventArgs e);
        abstract public bool IsHitIn(MouseEventArgs e);
        public bool InWorkspace(int maxX, int minX, int maxY, int minY)
        {
            return
                (_position.X < maxX) &&
                (_position.X > minX) &&
                (_position.Y < maxY) &&
                (_position.Y > minY);
        }
        abstract public void resizeOn(int dsize);
        abstract public void resize(uint new_size);

    }
}
