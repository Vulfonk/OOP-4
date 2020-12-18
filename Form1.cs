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

        VectorCCircle<ShapeViewer> shapes = new VectorCCircle<ShapeViewer>(1);
        Dictionary<Keys,(int, int) > keyValuePairs = new Dictionary<Keys, (int, int)>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            keyValuePairs.Add(Keys.D, (10, 0));
            keyValuePairs.Add(Keys.A, (-10, 0));
            keyValuePairs.Add(Keys.S, (0, 10));
            keyValuePairs.Add(Keys.W, (0, -10));

           /* Circle a = new Circle(new Point(2,3), 23);
            MessageBox.Show(a.ToString());
                     */
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
                            if (shapes[i].IsHitIn(e))
                            {
                                shapes[i]._enabled = !shapes[i]._enabled;
                                break;
                            }
                        }
                    else
                    {
                        //flag &= !(shapes[i]._enabled = shapes[i].IsHitIn(e) && flag);
                        if (shapes[i].IsHitIn(e) && flag)
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
                for (int i = 0; i < shapes.size(); i++)
                {
                    if (shapes[i] != null)
                    {
                        shapes[i]._enabled = false;
                    }
                }
                
                CircleViewer cCircle = new CircleViewer(e.Location, 30, Brushes.Red, true);
                shapes.resize(shapes.size() + 1);
                shapes[(int)shapes.size() - 1] = cCircle;
            }
            pictureBox.Invalidate();
        }


        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < shapes.size(); i++)
            {
                if (shapes[i] != null && !shapes[i]._enabled)
                {
                    shapes[i].Draw(e);
                }
            }
            for (int i = 0; i < shapes.size(); i++)
            {
                if (shapes[i] != null && shapes[i]._enabled)
                {
                    shapes[i].Draw(e);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl_key = e.Control;
            Keys key = e.KeyCode;
            
            if (keyValuePairs.ContainsKey(key))
            {
                for (int i = 0; i < shapes.size(); i++)
                {

                    if (shapes[i] != null && shapes[i]._enabled)
                    {
                        shapes[i].MoveOn(
                            keyValuePairs[key].Item1,
                            keyValuePairs[key].Item2,
                            pictureBox.Location.X + pictureBox.Width,
                            pictureBox.Location.X,
                            pictureBox.Location.Y - pictureBox.Height,
                            pictureBox.Location.Y);
                    }
                }
            }

            //MessageBox.Show("");

            if (key == Keys.Delete)
            {
                for(int i = 0; i < shapes.size(); i++)
                {
                    if (shapes[i] != null && shapes[i]._enabled)
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
            Keys key = e.KeyCode;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Shape_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    interface Drawable
    {
        void setColor(Brush color);
        void Draw(PaintEventArgs e);
        bool IsHitIn(MouseEventArgs e);
    }
    
    interface Movable
    {
        void MoveOn(int dx, int dy, int maxX, int minX, int maxY, int minY);
        bool InWorkspace(int maxX, int minX, int maxY, int minY);
    }

    abstract class ShapeViewer : Shape, Drawable, Movable
    {
        protected Brush _color;
        public bool _enabled;
        public void MoveOn(int dx, int dy, int maxX, int minX, int maxY, int minY)
        {
           // if (InWorkspace(maxX, minX, maxY, minY))
            //{
                _position.X += dx;
                _position.Y += dy;
            //}
        }
        public void setColor(Brush color)
        {
            _color = color;
        }
        abstract public void Draw(PaintEventArgs e);
        abstract public bool IsHitIn(MouseEventArgs e);
        public bool InWorkspace(int maxX, int minX, int maxY, int minY)
        {
            return
                _position.X < maxX &&
                _position.X > minX &&
                _position.Y < maxY &&
                _position.Y > minY;

        }

    }

    class CircleViewer : ShapeViewer
    {
        private Circle circle;
        public CircleViewer(Brush color, bool enabled)
        {
            setColor(color);
            _enabled = enabled;
        }
        public CircleViewer(Point position, uint radius, Brush color, bool enabled)
        {
            circle = new Circle(position, radius);
            _position = position;
            _enabled = enabled;
            setColor(color);
        }
        override public void Draw(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(
                    _color,
                    this._position.X - this.circle.getRadius(),
                    this._position.Y - this.circle.getRadius(),
                    this.circle.getRadius() * 2,
                    this.circle.getRadius() * 2
                    );

            if (!_enabled)
            {
                return;
            }
            Pen pen = new Pen(Brushes.Black, 5);
            e.Graphics.DrawEllipse(
                    pen,
                    this._position.X - this.circle.getRadius(),
                    this._position.Y - this.circle.getRadius(),
                    this.circle.getRadius() * 2,
                    this.circle.getRadius() * 2
                    );
        }
        override public bool IsHitIn(MouseEventArgs e)
        {
            return ((_position.X - e.X) * (_position.X - e.X) + (_position.Y - e.Y) * (_position.Y - e.Y) <= circle.getRadius() * circle.getRadius());
        
        }
    }
}
