﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    class Group : ListShape<ShapeViewer>, ShapeViewer, ISubject, IGroup
    {
        MyListShape shapes;
        public void NotifyEveryone(ShapeViewer shapeViewer)
        {
            foreach (var obs in shapes._observers)
            {
                obs.Update(shapes, shapeViewer);
            }
        }
        public Group(MyListShape shapeViewers) : base()
        {
            shapes = shapeViewers;
            shapes._observers = shapeViewers._observers;
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
                    if(shape.enabled)
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
                    if(shape.enabled)
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
                if (shape.enabled)
                {
                    shape.MoveOn(dx, dy, workspace);
                }
            }
            return true;
        }

        public void resize(uint new_size)
        {
            foreach (var shape in this)
            {
                if (shape.enabled)
                    shape.resize(new_size);
            }
        }

        public void resizeOn(int dsize)
        {
            foreach (var shape in this)
            {
                if (shape.enabled)
                    shape.resizeOn(dsize);
            }
        }
        public void ungroup()
        {
            this.Clear();
            shapes.Remove(this);
            NotifyEveryone(null);
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
                ShapeViewer shape = CreateObject(reader.ReadLine());
                shape.load(reader);
                this.Add(shape);
            }
        }

        public override ShapeViewer CreateObject(string shapeString)
        {
            return shapes.CreateObject(shapeString);
        }

        public void Attach(IObserver observer)
        {
            shapes.Attach(observer);
        }

        public void Detach(IObserver observer)
        {
            shapes.Detach(observer);
        }

        public void deleteEnabled()
        {
            foreach(var shape in this)
            {
                if (shape.enabled)
                {
                    Remove(shape);
                }
            }
        }
    }
}
