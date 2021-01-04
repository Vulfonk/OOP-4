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
    class SquadeViewer : ShapeViewer
    {
        private Squade squade;
        public SquadeViewer(Brush color, bool enabled) : base(color, enabled) { }
        public SquadeViewer(Point position, uint side, Brush color, bool enabled) : base(position, color, enabled)
        {
            squade = new Squade(position, side);
        }
        override public void Draw(PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(
                    (int)(this._position.X - squade._side / 2),
                    (int)(this._position.Y - squade._side / 2),
                    (int)squade._side,
                    (int)squade._side);

            e.Graphics.FillRectangle(_color,rect);

            if (!_enabled)
            {
                return;
            }
            e.Graphics.DrawRectangle(new Pen(Brushes.Black, 3),rect);
        }
        public override bool IsHitIn(MouseEventArgs e)
        {
            return Math.Abs(_position.X - e.X) * 2 < squade._side && Math.Abs(_position.Y - e.Y) * 2 < squade._side;
        }

        override public void resizeOn(int dsize)
        {
            if(squade._side + dsize > 0)
            {
                squade._side = (uint)(squade._side + dsize);
            }
        }
        override public void resize(uint new_size)
        {
            squade._side = (uint)new_size;
        }
    }
}
