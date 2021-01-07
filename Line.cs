using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP_4
{
    class Line : Shape
    {
        public Point _A, _B;
        public Line(Point A, Point B) : base(new Point((A.X + B.X) / 2, (A.Y + B.Y) / 2))
        {
            _A = A;
            _B = B;
        }

        virtual public bool MoveOn(int dx, int dy, Rectangle workspace)
        {
            Point newposA = new Point(_A.X + dx, _A.Y + dy);
            Point newposB = new Point(_B.X + dx, _B.Y + dy);

            bool flag = newposA.InRect(workspace) && newposB.InRect(workspace);
            if (flag)
            {
                _A.X += dx;
                _A.Y += dy;
                _B.X += dx;
                _B.Y += dy;
            }
            return flag;
        }

        protected double rotate(Point A, Point B, Point C)
        {
            return (B.X - A.X) * (C.Y - B.Y) - (B.Y - A.Y) * (C.X - B.X);
        }
        protected double distance(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
        protected double square(Point a, Point b, Point c)
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
        }

        public override void resizeOn(int dsize)
        {
        }
        public override bool IsHitIn(Point e)
        {
            Point A = _A;
            Point B = _B;
            Point C = e;
            
            return (
                (square(A, B, C)) == 0) &&
                (C.X > Math.Min(B.X, A.X)) &&
                (C.X < Math.Max(B.X, A.X)) &&
                (C.Y > Math.Min(B.Y, A.Y)) &&
                (C.Y < Math.Max(B.Y, A.Y));
        }
    }
}
