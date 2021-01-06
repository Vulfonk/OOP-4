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
    class LineViewer : ShapeViewer
    {
        private int width = 3;
        private Line line;
        public LineViewer(Point position, Point B, Brush color, bool enabled) : base(position, color, enabled)
        {
            line = new Line(position, B);
        }
        public override void Draw(Graphics e)
        {
            if (_enabled)
                e.DrawLine(new Pen(Brushes.Black, width + 3), line._B, _position);
            e.DrawLine(new Pen(_color, width),line._B, _position);
            
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
                line._B.X += dx;
                line._B.Y += dy;
                _position.X += dx;
                _position.Y += dy;
                return true;
            }
        }
        public override bool InWorkspace(int maxX, int minX, int maxY, int minY)
        {
            return
                PointIn(maxX, minX, maxY, minY, _position) &&
                PointIn(maxX, minX, maxY, minY, line._B);
        }
        public override bool IsHitIn(Point e)
        {
            Point A = line._B;
            Point B = _position;
            Point C = e;
            bool X = ((C.X > A.X - width) && (C.X < B.X + width)) || ((C.X < A.X + width) && (C.X > B.X - width));
            bool Y = ((C.Y > A.Y - width) && (C.Y < B.Y + width)) || ((C.Y < A.Y + width) && (C.Y > B.Y - width));
            return (distance(A, B) * width/4 > square(A, B, C)) && X && Y;
        }
        private double rotate(Point A, Point B, Point C)
        {
            return (B.X - A.X) * (C.Y - B.Y) - (B.Y - A.Y) * (C.X - B.X);
        }
        private double distance(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
        private double square(Point a, Point b, Point c)
        {
            double ab = distance(a, b);
            double ac = distance(a, c);
            double cb = distance(c, b);

            double p = (ab + ac + cb) / 2;
            double square = Math.Sqrt((p - ab) * (p - ac) * (p - cb) * p);
            return square;
        }
        public override void resize(uint new_size)
        {
            width = (int)new_size;
        }

        public override void resizeOn(int dsize)
        {
            width += dsize;
            /*line._B.X += dsize;
            line._B.Y += dsize;
            _position.X += dsize;
            _position.Y += dsize;*/
        }
    }
}
