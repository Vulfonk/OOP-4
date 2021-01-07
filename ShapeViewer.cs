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
    public interface IGroup
    {
        void ungroup();
    }
    public interface ShapeViewer : Drawable, Movable, Resizeable, IGroup
    {

    }
}
