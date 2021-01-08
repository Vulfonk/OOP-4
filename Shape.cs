using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;


namespace OOP_4
{
    abstract class Shape : ISaveLoad
    {
        protected Dictionary<String, Brush> _color_Dictionary = new Dictionary<String, Brush>
        {
            ["White"] = Brushes.White,
            ["Red"] = Brushes.Red,
            ["Green"] = Brushes.Green,
            ["Blue"] = Brushes.Blue,
            ["Brown"] = Brushes.Brown,
            ["Yellow"] = Brushes.Yellow,
            ["Black"] = Brushes.Black

        };
        protected Point _position;
        public Shape() { }
        public Shape(Point position)
        {
            _position = position;
        }
        virtual public bool MoveOn(int dx, int dy, Rectangle workspace)
        {
            Point newpos = new Point(_position.X + dx, _position.Y + dy);
            bool flag = newpos.InRect(workspace);
            if (flag)
            {
                _position.X += dx;
                _position.Y += dy;
            }
            return flag;
        }
        virtual public bool IsMoveable(int dx, int dy, Rectangle workspace)
        {
            Point newpos = new Point(_position.X + dx, _position.Y + dy);
            return newpos.InRect(workspace);
        }
        abstract public void resize(uint new_size);
        abstract public void resizeOn(int dsize);
        abstract public bool IsHitIn(Point e);
        virtual public void ungroup() 
        { 
        
        }
        virtual public void save(StreamWriter writer)
        {
            writer.WriteLine(_position.X + "," + _position.Y);
        }
        virtual public void load(StreamReader reader)
        {
            string[] position = reader.ReadLine().Split(',');
            _position.X = Int32.Parse(position[0]);
            _position.Y = Int32.Parse(position[1]);
        }

    }
}
