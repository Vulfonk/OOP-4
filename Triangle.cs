using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP_4
{
    class Triangle : Polygon
    {
        private const int E = 1;
        protected Point[] vertices = new Point[3];
        public Triangle()
        {

        }
        public Triangle(Point position, uint side) : base(position, side)
        {
            PosToVertices();
        }
        protected void PosToVertices()
        {
            var dx = (int)(0.5 * _side);
            var dy = (int)(_position.Y + 2 * Math.Sqrt(3) * _side / 10);

            vertices[0] = new Point(_position.X, (int)(_position.Y - 3 * Math.Sqrt(3) * _side / 10));
            vertices[1] = new Point(_position.X - dx, dy);
            vertices[2] = new Point(_position.X + dx, dy);
        }
        public override void resizeOn(int dsize)
        {
            base.resizeOn(dsize);
            PosToVertices();
        }
        public override bool IsHitIn(Point e)
        {
            double ABCSquare = square(vertices);

            double ABDSquare = square(e, vertices[1], vertices[2]);
            double BCDSquare = square(vertices[0], e, vertices[2]);
            double CADSquare = square(vertices[0], vertices[1], e);

            return
                ABCSquare + E >= ABDSquare + BCDSquare + CADSquare &&
                ABCSquare - E <= ABDSquare + BCDSquare + CADSquare;
        }
        public override bool MoveOn(int dx, int dy, Rectangle workspace)
        {
            bool flag = true;
            foreach (var ver in vertices)
            {
                Point point = new Point(ver.X + dx, ver.Y + dy);
                flag &= point.InRect(workspace);
            }
            if (flag)
            {
                    _position.X += dx;
                    _position.Y += dy;
                for(int i = 0; i < vertices.Length; i++)
                {
                    vertices[i].X += dx;
                    vertices[i].Y += dy;
                }
            }
            return flag;
        }
    }
}
