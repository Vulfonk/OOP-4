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
        VectorCCircle shapes = new VectorCCircle(1);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            CCircle cCircle = new CCircle(e.X, e.Y);
            shapes.resize(100);
            if (shapes.getK() == shapes.size())
            {
                //shapes.resize(shapes.getK() + 1);
            }
            shapes[(int)shapes.getK()] = cCircle;
        }

        private void buttonShowShapes_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < shapes.size(); i++)
            {
                dataGridViewShapes.Rows.Add(shapes[i].getX(), shapes[i].getY());
            }
        }
    }

    class CCircle
    {
        private int _x, _y;
        public CCircle(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public int getX()
        {
            return _x;
        }
        public int getY()
        {
            return _y;
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
            CCircle[] _shapes1 = new CCircle[_size];
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
}
