using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace OOP_4
{
    class Polygon : Shape
    {
        public uint _side;
        public Polygon()
        {

        }
        public Polygon(Point position, uint side):base(position)
        {
            _side = side;
        }
        public Polygon(Polygon polygon)
        {
            this._side = polygon._side;
            this._position = polygon._position;
        }
        public override  bool IsHitIn(Point e)
        {
            return false;
        }
        override public void resizeOn(int dsize)
        {
            if (_side + dsize > 0)
            {
                _side = (uint)(_side + dsize);
            }
        }

        override public void resize(uint new_size)
        {
            _side = (uint)new_size;
        }

        protected double distance(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }

        protected double square(params Point[] vertices)
        {
            var n = vertices.Length;
            double[] segment_length = new double[n];
            double sum = segment_length[n - 1] = distance(vertices[0], vertices[n - 1]);
            for (int i = 0; i < n - 1; i++)
            {
                segment_length[i] = distance(vertices[i], vertices[i + 1]);
                sum += segment_length[i];
            }
            double p = sum / 2;
            double proiz = p;
            for (int i = 0; i < n; i++)
            {
                proiz *= (p - segment_length[i]);
            }
            double square = Math.Sqrt(proiz);
            return square;
        }
        virtual public void save(StreamWriter writer)
        {
            writer.WriteLine(_side);
            base.save(writer);
        }
        virtual public void load(StreamReader reader)
        {
            _side = (uint)Int32.Parse(reader.ReadLine());            
            base.load(reader);
        }
    }
}
