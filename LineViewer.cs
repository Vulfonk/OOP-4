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
    class LineViewer : ShapeViewer
    {
        private Line line;
        public LineViewer(Point position, uint side, Brush color, bool enabled) : base(position, color, enabled)
        {

        }
        public override void Draw(PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override bool IsHitIn(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void resize(uint new_size)
        {
            throw new NotImplementedException();
        }

        public override void resizeOn(int dsize)
        {
            throw new NotImplementedException();
        }
    }
}
