using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace OOP_4
{

    class MyListShape : ListShape<ShapeViewer>, ISubject
    {
        public List<IObserver> _observers;

        public void NotifyEveryone(ShapeViewer shapeViewer)
        {
            foreach (var obs in _observers)
            {
                obs.Update(this, shapeViewer);
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
            NotifyEveryone(data);
        }
        public override void AddFirst(ShapeViewer data)
        {
            base.AddFirst(data);
            NotifyEveryone(data);
        }
        public override void Clear()
        {
            base.Clear();
            NotifyEveryone(null);
        }
        public override bool Remove(ShapeViewer data)
        {
            bool flag = base.Remove(data);
            NotifyEveryone(data);
            return flag;
        }

        public ShapeViewer IsHitIn(Point position, bool mode)
        {
            bool flag = true;
            ShapeViewer enabledShape = null;
            for (var i = this.Count - 1; i >= 0; i--)
            {
                ShapeViewer shape = this.ElementAt(i);
                if (mode)
                {
                    if (shape.IsHitIn(position))
                    {
                        shape.enabled = !shape.enabled;
                        enabledShape = shape;
                        break;
                    }
                }
                else
                {
                    if (shape.IsHitIn(position) && flag)
                    {
                        shape.enabled = true;
                        enabledShape = shape;
                        flag = false;
                    }
                    else
                    {
                        shape.enabled = false;
                    }
                }
            }
            NotifyEveryone(enabledShape);
            return enabledShape;
        }

        public override ShapeViewer CreateObject(string shapeString)
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

        public void Draw(Graphics e)
        {
            foreach(var shape in this)
            {
                shape.Draw(e);
            }
        }

        public bool MoveOn(int dx, int dy, Rectangle workspace)
        {
            bool flag = false;
            foreach (var shape in this)
            {
                if (shape.enabled)
                { 
                    shape.MoveOn(dx,dy,workspace);
                    flag = true;
                }
            }
            return flag;
        }
        public void resizeOn(int dsize)
        {
            foreach (var shape in this)
            {
                if (shape.enabled)
                {
                    shape.resizeOn(dsize);
                }
            }
        }

        public void resize(uint new_size)
        {
            foreach (var shape in this)
            {
                if (shape.enabled)
                {
                    shape.resize(new_size);
                }
            }
        }
    }
}
