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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VectorShape a = new VectorShape(4);
            Shape s = new Shape();
            s.setX(4);
            a[2] = s;
            label1.Text = a[2].getX().ToString();
        }
    }

    class Shape
    {
        private int _x;
        public void setX(int x)
        {
            _x = x;
        }
        public int getX()
        {
            return _x;
        }
    }

    class VectorShape
    {
        private Shape[] _shapes;
        private int _size;
        private int _k;
        public VectorShape(int size)
        {
            _k = 0;
            _size = size;
            _shapes = new Shape[_size];
        }
        public void resize(int newSize)
        {

        }
        public Shape this[int i]
        {
            set
            {
                _shapes[i] = value;
            }
            get
            {
                return _shapes[i];
            }
        }
    }
}
