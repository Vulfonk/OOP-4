﻿using System;
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
    class CircleViewer : Circle, ShapeViewer
    {
        Brush _color;
        bool _enabled;
        public Brush color { get => _color; set => _color = value; }
        public bool enabled { get => _enabled; set => _enabled = value; }

        public CircleViewer(Point position, uint radius, Brush color, bool enabled) : base(position, radius)
        {
            _color = color;
            _enabled = enabled;
        }
        public void Draw(Graphics e)
        {
            Rectangle rect = new Rectangle(
                    (int)(this._position.X - this._radius),
                    (int)(this._position.Y - this._radius),
                    (int)(this._radius * 2),
                    (int)(this._radius * 2));

            e.FillEllipse(_color, rect);

            if (!_enabled)
            {
                return;
            }
            e.DrawEllipse(new Pen(Brushes.Black, 3), rect);
        }
        public void ungroup()
        {
            return;
        }
    }
}
