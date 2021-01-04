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
        private const int E = 1;
        private Triangle triangle;
        private Point[] vertices = new Point[3];
        public TriangleViewer(Brush color, bool enabled) : base(color, enabled) { }
        public TriangleViewer(Point position, uint side, Brush color, bool enabled) : base(position, color, enabled)
        {
            triangle = new Triangle(position, side);
        }
        override public void Draw(PaintEventArgs e)
        {
            var dx = (int)(0.5 * triangle._side);
            var dy = (int)(_position.Y + 2 * Math.Sqrt(3) * triangle._side / 10);

            vertices[0] = new Point(_position.X, (int)(_position.Y - 3 * Math.Sqrt(3) * triangle._side / 10));
            vertices[1] = new Point(_position.X - dx, dy);
            vertices[2] = new Point(_position.X + dx, dy);

            e.Graphics.FillPolygon(_color, vertices);

            if (!_enabled)
            {
                return;
            }

            Pen pen = new Pen(Brushes.Black, 3);
            e.Graphics.DrawLines(pen, vertices);
            e.Graphics.DrawLine(pen, vertices[2], vertices[0]);
            /*
            e.Graphics.DrawLine(pen, vertices[0], vertices[1]);
            e.Graphics.DrawLine(pen, vertices[1], vertices[2]);
            */

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
        private double square(Point[] vertices)
        {
            var n = vertices.Length;
            double[] segment_length = new double[n];
            double sum = segment_length[n - 1] = distance(vertices[0], vertices[n - 1]);
            for (int i = 0; i < n - 1; i++)
            {
                segment_length[i] = distance(vertices[i], vertices[i + 1]);
                sum += segment_length[i];
            }
            double p = sum / 2;
            double proiz = p;
            for (int i = 0; i < n; i++) {
                proiz *= (p - segment_length[i]);
            }
            double square = Math.Sqrt(proiz);
            return square;
        }
        public override bool IsHitIn(MouseEventArgs e)
        {
            //double ABCSquare = square(vertices);
            double ABCSquare = square(vertices[0], vertices[1], vertices[2]);

            double ABDSquare = square(e.Location, vertices[1], vertices[2]);
            double BCDSquare = square(vertices[0], e.Location, vertices[2]);
            double CADSquare = square(vertices[0], vertices[1], e.Location);

            return
                ABCSquare + E >= ABDSquare + BCDSquare + CADSquare &&
                ABCSquare - E <= ABDSquare + BCDSquare + CADSquare;
        }
        override public void resizeOn(int dsize)
        {
            if (triangle._side + dsize > 0)
            {
                triangle._side = (uint)(triangle._side + dsize);
            }
        }
        override public void resize(uint new_size)
        {
            triangle._side = (uint)new_size;
        }
    }
}
