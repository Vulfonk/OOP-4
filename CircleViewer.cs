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
    class CircleViewer : ShapeViewer
    {
        private Circle circle;
        public CircleViewer(Brush color, bool enabled) : base(color, enabled) { }
        public CircleViewer(Point position, uint radius, Brush color, bool enabled) : base(position, color, enabled)
        {
            circle = new Circle(position, radius);
        }
        override public void Draw(PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(
                    (int)(this._position.X - this.circle._radius),
                    (int)(this._position.Y - this.circle._radius),
                    (int)(this.circle._radius * 2),
                    (int)(this.circle._radius * 2));

            e.Graphics.FillEllipse(_color, rect);

            if (!_enabled)
            {
                return;
            }
            e.Graphics.DrawEllipse(new Pen(Brushes.Black, 3), rect);
        }
        public override bool MoveOn(int dx, int dy, int maxX, int minX, int maxY, int minY)
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
        public override bool InWorkspace(int maxX, int minX, int maxY, int minY)
        {
            return
                PointIn(maxX, minX, maxY, minY, new Point((int)(_position.X - circle._radius), (int)(_position.Y - circle._radius))) &&
                PointIn(maxX, minX, maxY, minY, new Point((int)(_position.X + circle._radius), (int)(_position.Y + circle._radius)));
        }
        private bool PointIn(int maxX, int minX, int maxY, int minY, Point point)
        {
            return
                (point.X < maxX) &&
                (point.X > minX) &&
                (point.Y < maxY) &&
                (point.Y > minY);
        }
        override public bool IsHitIn(MouseEventArgs e)
        {
            return
                ((_position.X - e.X) * (_position.X - e.X)
                + (_position.Y - e.Y) * (_position.Y - e.Y)
                <=
                circle._radius * circle._radius);
        }
        override public void resizeOn(int dsize)
        {
            if (circle._radius + dsize > 0)
            {
                circle._radius = (uint)(circle._radius + dsize);
            }
        }
        override public void resize(uint new_size)
        {

            circle._radius = (uint)new_size;
        }
    }
}
