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
    class LineViewer : Line, ShapeViewer
    {
        Brush _color;
        bool _enabled;
        int width = 3;
        public Brush color { get => _color; set => _color = color; }
        public bool enabled { get => _enabled; set => _enabled = value; }
        public LineViewer(Point A, Point B, Brush color, bool enabled) : base(A, B)
        {
            _color = color;
            _enabled = enabled;
        }
        public void Draw(Graphics e)
        {
            if (_enabled)
                e.DrawLine(new Pen(Brushes.Black, width + 3), _B, _A);
            e.DrawLine(new Pen(_color, width), _B, _A);
            
        }
        override public bool MoveOn(int dx, int dy, Rectangle workspace)
        {
            bool flag = new Point().InRect(workspace);
            if (flag)
            {
                _position.X += dx;
                _position.Y += dy;
            }
            return flag;
        }
        public override void resize(uint new_size)
        {
            width = (int)new_size;
        }

        public override void resizeOn(int dsize)
        {
            width += dsize;
        }
        public override bool IsHitIn(Point e)
        {
            Point A = _B;
            Point B = _position;
            Point C = e;
            bool X = ((C.X > A.X - width) && (C.X < B.X + width)) || ((C.X < A.X + width) && (C.X > B.X - width));
            bool Y = ((C.Y > A.Y - width) && (C.Y < B.Y + width)) || ((C.Y < A.Y + width) && (C.Y > B.Y - width));
            return (distance(A, B) * width/4 > square(A, B, C)) && X && Y;
        }

    }
}
