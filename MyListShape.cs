using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP_4
{

    class MyListShape : ListShape<ShapeViewer>, ISubject
    {
        public List<IObserver> _observers;
        public void NotifyEveryone()
        {
            foreach (var obs in _observers)
            {
                obs.Update(this);
            }
        }
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public MyListShape()
        {
            _observers = new List<IObserver>();
        }
        public override void Add(ShapeViewer data)
        {
            base.Add(data);
            NotifyEveryone();
        }
        public override void AddFirst(ShapeViewer data)
        {
            base.AddFirst(data);
            NotifyEveryone();
        }
        public override void Clear()
        {
            base.Clear();
            NotifyEveryone();
        }
        public override bool Remove(ShapeViewer data)
        {
            bool flag = base.Remove(data);
            NotifyEveryone();
            return flag;
        }


        public override ShapeViewer CreateShape(string shapeString)
        {

            ShapeViewer shape;

            if (shapeString == "Circle")
            {
                shape = new CircleViewer();
            }
            else if(shapeString == "Squade")
            {
                shape = new SquadeViewer();
            }
            else if (shapeString == "Triangle")
            {
                shape = new TriangleViewer();
            }
            else if (shapeString == "Line")
            {
                shape = new LineViewer();
            }
            else if (shapeString == "Group")
            {
                shape = new Group(this);
            }
            else
            {
                shape = null;
            }
            return shape;
        }
    }
}
