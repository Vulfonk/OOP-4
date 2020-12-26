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
    class TriangleViewer : ShapeViewer
    {
        private Triangle triangle;
        Point[] args = new Point[3];
        public TriangleViewer(Brush color, bool enabled) : base(color, enabled) { }
        public TriangleViewer(Point position, uint side, Brush color, bool enabled) : base(position, color, enabled)
        {
            triangle = new Triangle(position, side);
        }
        override public void Draw(PaintEventArgs e)
        {
            args[0] = new Point(_position.X, (int)(_position.Y - 3 * Math.Sqrt(3) * triangle._side / 10));
            args[1] = new Point(_position.X - (int)(0.5 * triangle._side), (int)(_position.Y + 2 * Math.Sqrt(3) * triangle._side / 10));
            args[2] = new Point(_position.X + (int)(0.5 * triangle._side), (int)(_position.Y + 2 * Math.Sqrt(3) * triangle._side / 10));

            e.Graphics.FillPolygon(Brushes.Red, args);

            if (!_enabled)
            {
                return;
            }

            Pen pen = new Pen(Brushes.Black, 3);

            e.Graphics.DrawLine(pen, args[0], args[1]);
            e.Graphics.DrawLine(pen, args[1], args[2]);
            e.Graphics.DrawLine(pen, args[2], args[0]);

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
        public override bool IsHitIn(MouseEventArgs e)
        {
            double ABCSquare = square(args[0], args[1], args[2]);

            double ABDSquare = square(e.Location, args[1], args[2]);
            double BCDSquare = square(args[0], e.Location, args[2]);
            double CADSquare = square(args[0], args[1], e.Location);

            return
                ABCSquare + 1 >= ABDSquare + BCDSquare + CADSquare &&
                ABCSquare - 1 <= ABDSquare + BCDSquare + CADSquare;
        }
        override public void resizeOn(int dsize)
        {
            triangle._side = (uint)(triangle._side + dsize);
        }
        override public void resize(uint new_size)
        {
            triangle._side = (uint)new_size;
        }
    }
}
