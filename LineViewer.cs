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
using System.IO;

namespace OOP_4
{
    class LineViewer : Line, ShapeViewer
    {
        Brush _color;
        bool _enabled;
        int width = 3;
        public LineViewer()
        {

        }
        public Brush color { get => _color; set => _color = value; }
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
            Point A = _A;
            Point B = _B;
            Point C = e;
            bool X = ((C.X > A.X - width) && (C.X < B.X + width)) || ((C.X < A.X + width) && (C.X > B.X - width));
            bool Y = ((C.Y > A.Y - width) && (C.Y < B.Y + width)) || ((C.Y < A.Y + width) && (C.Y > B.Y - width));
            return (distance(A, B) * width/4 > square(A, B, C)) && X && Y;
        }
        public override void save(StreamWriter writer)
        {
            writer.WriteLine("Line");
            writer.WriteLine(_color_Dictionary.KeyWithValue(_color));
            base.save(writer);
        }
        public override void load(StreamReader reader)
        {
            _color = _color_Dictionary[reader.ReadLine()];
            base.load(reader);
        }
    }
}
