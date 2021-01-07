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
    class TriangleViewer : Triangle, ShapeViewer
    {
        private Brush _color;
        private bool _enabled;

        public Brush color { get => _color; set => _color = value; }
        public bool enabled { get => _enabled; set => _enabled = value; }
        public TriangleViewer(Point position, uint side, Brush color, bool enabled) : base(position, side)
        {
            _color = color;
            _enabled = enabled;
        }
        public void Draw(Graphics e)
        {
            e.FillPolygon(_color, vertices);

            if (!_enabled)
            {
                return;
            }

            Pen pen = new Pen(Brushes.Black, 3);
            e.DrawLines(pen, vertices);
            e.DrawLine(pen, vertices[2], vertices[0]);

        }
        public void ungroup()
        {
            return;
        }
    }
}
