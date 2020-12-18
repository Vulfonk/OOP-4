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

        bool ctrl_key = false;

        VectorCCircle<CCircleViewer> shapes = new VectorCCircle<CCircleViewer>(1);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {

            if (!(e.Button == MouseButtons.Left))
            {
                return;
            }
            if (SelectionMode_checkBox.Checked)
            {
                bool flag = true;
                for (int i = (int)shapes.size() - 1; i >= 0; i--)
                {
                    if (shapes[i] == null)
                        continue;

                    if (ctrl_key)
                    {
                        if (shapes[i].IsSelected(e))
                        {
                            shapes[i]._enabled = !shapes[i]._enabled;
                            break;
                        }
                    }
                    else
                    {
                        if (shapes[i].IsSelected(e) && flag)
                        {
                            shapes[i]._enabled = true;
                            flag = false;
                        }
                        else
                        {
                            shapes[i]._enabled = false;
                        }
                    }

                }
            }
            else
            {
                
                for (int i = 0; i < shapes.getK(); i++)
                {
                    if(shapes[i] == null)
                    {
                        continue;
                    }
                    shapes[i]._enabled = false;
                }

                CCircleViewer cCircle = new CCircleViewer(e.Location, 30, Brushes.Red, true);

                if (shapes.getK() == shapes.size())
                {
                    shapes.resize(shapes.getK() + 1);
                }
                shapes[(int)shapes.getK()] = cCircle;
            }
            pictureBox.Invalidate();
        }

        private void buttonShowShapes_Click(object sender, EventArgs e)
        {
            dataGridViewShapes.Rows.Clear();
            for (int i = 0; i < shapes.size(); i++)
            {
                if(shapes[i] == null)
                {
                    continue;
                }
                dataGridViewShapes.Rows.Add(shapes[i].getX(), shapes[i].getY());
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < shapes.size(); i++)
            {
                if (shapes[i] == null)
                    continue;
                shapes[i].Draw(e);
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl_key = e.Control;
            if(e.KeyCode == Keys.Delete)
            {
                for(int i = 0; i < shapes.size(); i++)
                {
                    if(shapes[i] == null)
                    {
                        continue;
                    }
                    if (shapes[i]._enabled)
                    {
                        shapes.delCShape((uint)i);
                    }
                }
            }
            pictureBox.Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            ctrl_key = e.Control;
        }
    }

    class CCircleViewer : CCircle
    {
        private Brush _color;
        public bool _enabled = false;
        public CCircleViewer(Brush brush, bool enabled)
        {
            _color = brush;
            _enabled = enabled;
        }
        public CCircleViewer(Point position, uint radius, Brush brush, bool enabled)
        {
            _position = position;
            _radius = radius;
            _color = brush;
            _enabled = enabled;
        }
        public void Draw(PaintEventArgs e)
        {

            e.Graphics.FillEllipse(
                    _color,
                    this.getX() - this.getRadius(),
                    this.getY() - this.getRadius(),
                    this.getRadius() * 2,
                    this.getRadius() * 2
                    );

            if (!_enabled)
            {
                return;
            }
            Pen pen = new Pen(Brushes.Black, 5);
            e.Graphics.DrawEllipse(
                    pen,
                    this.getX() - this.getRadius(),
                    this.getY() - this.getRadius(),
                    this.getRadius() * 2,
                    this.getRadius() * 2
                    );

        }
        public bool IsSelected(MouseEventArgs e)
        {
            return ((_position.X - e.X) * (_position.X - e.X) + (_position.Y - e.Y) * (_position.Y - e.Y) <= _radius * _radius);
        
        }
    }
}
