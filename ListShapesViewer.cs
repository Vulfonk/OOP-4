using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

namespace OOP_4
{
    class ListShapesViewer<T> : ListShape<T> where T : Drawable
    {
        Point _LeftUp, _RightDown;
        ListShapesViewer(Point LeftUp, Point RightDown)
        {
            _LeftUp = LeftUp;
            _RightDown = RightDown;
        }


    }
}
