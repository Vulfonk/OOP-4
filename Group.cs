using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    class Group : ListShape<ShapeViewer>, ShapeViewer
    {
        ListShape<ShapeViewer> shapes;
        public Group(ListShape<ShapeViewer> shapeViewers)
        {
            shapes = shapeViewers;
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
            foreach (var shape in this) 
            {
                shapes.Add(shape);
                this.Remove(shape);
            }
        }
    }
}
