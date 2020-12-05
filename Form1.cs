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
    public partial class Form1 : Form
    {
        Point firstPoint, lastPoint;
        VectorCCircle shapes = new VectorCCircle(1);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e  )
        {
            CCircle cCircle = new CCircle(e.X, e.Y);
            //shapes.resize(100);
            if (shapes.getK() == shapes.size())
            {
                shapes.resize(shapes.getK() + 1);
            }
            shapes[(int)shapes.getK()] = cCircle;
            PaintEllipse();

        }

        private void drawEllipse()
        {
           
        }

        private void buttonShowShapes_Click(object sender, EventArgs e)
        {
            dataGridViewShapes.Rows.Clear();
            for(int i = 0; i < shapes.size(); i++)
            {
                dataGridViewShapes.Rows.Add(shapes[i].getX(), shapes[i].getY());
            }
        }

        private void dataGridViewShapes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
        }

        private void PaintEllipse()
        {
            var graphics = pictureBox.CreateGraphics();
            graphics.Clear(BackColor);
            for (int i = 0; i < shapes.size(); i++)
            {
                if (shapes[i] != null)
                {
                    graphics.FillEllipse(
                        Brushes.Red, 
                        shapes[i].getX() - shapes[i].getRadius(), 
                        shapes[i].getY() - shapes[i].getRadius(), 
                        shapes[i].getRadius() * 2, 
                        shapes[i].getRadius() * 2
                        );
                }
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            PaintEllipse();

        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint._x = e.X;
            firstPoint._y = e.Y;

        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //Point lastPoint = new Point(e.X, e.Y);

        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            lastPoint._x = e.X;
            lastPoint._y = e.Y;
            new Rectangle(firstPoint, lastPoint);

        }
    }

    class Rectangle
    {
        Point _LeftUpperPoint;
        Point _RightLowerPoint;
        

        private void PointPosition(int xFirst, int yFirst, int xLast, int yLast)
        {
            _LeftUpperPoint = new Point(
                xFirst > xLast? xLast : xFirst,
                yFirst > yLast ? yFirst : yLast);
            _RightLowerPoint = new Point(
                xFirst < xLast ? xLast : xFirst,
                yFirst < yLast ? yFirst : yLast);
        }
        public Rectangle(Point first, Point last)
        {
            PointPosition(first._x, first._y, last._x, last._y);
        }

        public Rectangle(int xFirst, int yFirst, int xLast, int yLast)
        {
            PointPosition(xFirst, yFirst, xLast, yLast);
        }
        public Point LeftUpperPoint()
        {
            return _LeftUpperPoint;
        }
        public Point RightLowerPoint()
        {
            return _RightLowerPoint;
        }
    }
    class Point
    {
        public int _x, _y;
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public Point(Point point)
        {
            _x = point._x;
            _y = point._y;
        }

    }

    class CCircle
    {
        private Point _position;
        private uint _radius;
        public CCircle(Point position)
        {
            _position = position;
        }
        public CCircle(int x, int y, uint radius = 50)
        {
            _position = new Point(x, y);
            /*_position._x = x;
            _position._y = y;*/
            _radius = radius;
        }

        public Point getPosition()
        {
            return _position;
        }
        public int getX()
        {
            return _position._x;
        }
        public int getY()
        {
            return _position._y;
        }
        public uint getRadius()
        {
            return _radius;
        }
        public CCircle(CCircle Circle)
        {
            _position = Circle._position;
            _radius = Circle._radius;
        }
    }

    class VectorCCircle
    {
        private CCircle[] _shapes;
        private uint _size;
        private uint _k;
        public VectorCCircle(uint size)
        {
            _k = 0;
            _size = size;
            _shapes = new CCircle[_size];
            for(int i = 0; i < size; i++)
            {
                _shapes[i] = null;
            }
        }
        public void resize(uint newSize)
        {
            CCircle[] _shapes1 = new CCircle[newSize];
            uint size = _size < newSize ? _size : newSize;
            for(int i = 0; i < size; i++)
            {
                _shapes1[i] = _shapes[i];
            }
            _shapes = _shapes1;
            _size = newSize;
        }
        public CCircle this[int i]
        {
            set
            {
                if ((i < 0) || (i > _size))
                {

                }
                else
                {
                    if(_shapes[i] == null)
                    {
                        _k++;
                    }
                    _shapes[i] = value;
                }
            }
            get
            {
                if ((i < 0) || (i > _size))
                {
                    return null;
                }
                else
                {
                    return _shapes[i];
                }
            }
        }
        public void delCCircle(uint i)
        {
            if (_shapes[i] != null)
            {
                _k--;
            }
            _shapes[i] = null;
        }
        public uint size()
        {
            return _size;
        }
        public uint getK()
        {
            return _k;
        }
        public VectorCCircle(VectorCCircle a)
        {
            _k = a._k;
            _size = a._size;
            for (int i = 0; i < _size; i++)
            {
                _shapes[i] = a._shapes[i];
            }
        }
        ~VectorCCircle()
        {
            for(int i = 0; i < _size; i++)
            {
                _shapes[i] = null;
            }
        }
    }
    enum PointPositionRectangle{
        LEFT_UPPER,
        RIGHT_UPPER,
        LEFT_LOWER,
        RIGHT_LOWER
    }
}
