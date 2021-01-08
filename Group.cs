using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    class Group : MyListShape, ShapeViewer
    {
        MyListShape shapes;
        public void NotifyEveryone()
        {
            foreach (var obs in _observers)
            {
                obs.Update(shapes);
            }
        }
        public Group(MyListShape shapeViewers) : base()
        {
            shapes = shapeViewers;
            _observers = shapeViewers._observers;
        }
        public Group():base()
        {

        }
        public override void Add(ShapeViewer shape)
        {
            base.Add(shape);
            if (shapes != null)
            {
                shapes.Remove(shape);
            }
        }
        public override bool Remove(ShapeViewer shape)
        {
            if (base.Remove(shape))
            {
                shapes.Add(shape);
                return true;
            }
            return false;
            
        }
        public override void AddFirst(ShapeViewer shape)
        {
            base.AddFirst(shape);
            shapes.Remove(shape);
        }
        public override void Clear()
        {
            foreach (var shape in this)
            {
                shapes.AddFirst(shape);
            }
            base.Clear();
        }
        public Brush color
        {
            get
            {
                foreach (var shape in this)
                {
                    return shape.color;
                }
                return null;
            }
            set
            {
                foreach (var shape in this)
                {
                    shape.color = value;
                }
            }
        }
        public bool enabled
        {
            get
            {
                foreach (var shape in this)
                {
                    return shape.enabled;
                }
                return false;
            }
            set
            {
                foreach (var shape in this)
                {
                    shape.enabled = value;
                }
            }
        }
        public void Draw(Graphics e)
        {
            foreach (var shape in this)
            {
                shape.Draw(e);
            }
        }

        public bool IsHitIn(Point e)
        {
            foreach (var shape in this)
            {
                if (shape.IsHitIn(e))
                {
                    return true;
                }
            }
            return false;
        }

        public bool MoveOn(int dx, int dy, Rectangle workspace)
        {
            foreach (var shape in this)
            {
                shape.MoveOn(dx, dy, workspace);
            }
            return true;
        }

        public void resize(uint new_size)
        {
            foreach (var shape in this)
            {
                shape.resize(new_size);
            }
        }

        public void resizeOn(int dsize)
        {
            foreach (var shape in this)
            {
                shape.resizeOn(dsize);
            }
        }
        public void ungroup()
        {
            this.Clear();
            shapes.Remove(this);
            NotifyEveryone();
        }

        public void save(StreamWriter writer)
        {
            writer.WriteLine("Group");
            writer.WriteLine(Count);
            foreach (var shape in this)
            {
                shape.save(writer);
            }
        }

        public void load(StreamReader reader)
        {
            int count = Int32.Parse(reader.ReadLine());
            for(int i = 0; i < count; i++)
            {
                ShapeViewer shape = CreateShape(reader.ReadLine());
                shape.load(reader);
                this.Add(shape);
            }
        }
    }
}
