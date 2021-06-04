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
    public interface IObserver
    {
        void Update(ISubject subject, ShapeViewer shapeViewer);
    }
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void NotifyEveryone(ShapeViewer shapeViewer);
    }
    public interface IGroup
    {
        void ungroup();
        void deleteEnabled();
    }
    public interface ISaveLoad
    {
        void save(StreamWriter writer);
        void load(StreamReader reader);
    }
    public interface ShapeViewer : Drawable, Movable, Resizeable, ISaveLoad { }
}
