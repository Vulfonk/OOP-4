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
using System.IO;

namespace OOP_4
{
    class SquadeViewer : Squade, ShapeViewer
    {
        Brush _color;
        bool _enabled;
        public SquadeViewer()
        {

        }
        public Brush color { get => _color; set => _color = value; }
        public bool enabled { get => _enabled; set => _enabled = value; }
        public SquadeViewer(Point position, uint side, Brush color, bool enabled) : base(position, side)
        {
            _color = color;
            _enabled = enabled;
        }
        public void Draw(Graphics e)
        {
            Rectangle rect = new Rectangle(
                    (int)(this._position.X - _side / 2),
                    (int)(this._position.Y - _side / 2),
                    (int)_side,
                    (int)_side);

            e.FillRectangle(_color,rect);

            if (!_enabled)
            {
                return;
            }
            e.DrawRectangle(new Pen(Brushes.Black, 3),rect);
        }
        override public void save(StreamWriter writer)
        {
            writer.WriteLine("Squade");
            writer.WriteLine(_color_Dictionary.KeyWithValue(_color));
            base.save(writer);
        }

        override public void load(StreamReader reader)
        {
            _color = _color_Dictionary[reader.ReadLine()];
            base.load(reader);
        }
    }
}
