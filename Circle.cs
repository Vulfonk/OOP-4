﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace OOP_4
{
    class Circle :  Shape
    {
        public uint _radius;

        public Circle()
        {

        }
        public Circle(Point position, uint radius):base(position)
        {
            _radius = radius;
        }

        public Circle(Circle Circle)
        {
            _position = Circle._position;
            _radius = Circle._radius;
        }
        override public bool IsHitIn(Point e)
        {
            return
                ((_position.X - e.X) * (_position.X - e.X)
                + (_position.Y - e.Y) * (_position.Y - e.Y)
                <=
                _radius * _radius);
        }
        override public void resizeOn(int dsize)
        {
            if (_radius + dsize > 0)
            {
                _radius = (uint)(_radius + dsize);
            }
        }
        override public void resize(uint new_size)
        {
            _radius = (uint)new_size;
        }
        public override void save(StreamWriter writer)
        {
            writer.WriteLine(_radius);
            base.save(writer);
        }
        public override void load(StreamReader reader)
        {
            _radius = (uint)Int32.Parse(reader.ReadLine());
            base.load(reader);
        }
    }
}
