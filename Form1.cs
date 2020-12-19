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
        const int displacement = 10;
        VectorCCircle<ShapeViewer> shapes = new VectorCCircle<ShapeViewer>();
        Dictionary<Keys, (int dx, int dy)> keyValuePairs = new Dictionary<Keys, (int, int)>
        {
            [Keys.D] = (displacement, 0),
            [Keys.A] = (-displacement, 0),
            [Keys.S] = (0, displacement),
            [Keys.W] = (0, -displacement),
        };

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

                ShapeViewer shape = null;
                if ((string)Shape_comboBox.SelectedItem == "Круг")
                {
                    shape = new CircleViewer(e.Location, 30, Brushes.Red, true);
                }
                else if ((string)Shape_comboBox.SelectedItem == "Квадрат")
                {
                    shape = new SquadeViewer(e.Location, 30, Brushes.Red, true);
                }
                shapes.resize(shapes.size() + 1);
                if (shape != null)
                {
                    shapes[(int)shapes.size() - 1] = shape;
                }


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

            if (keyValuePairs.TryGetValue(key, out(int dx, int dy) displacement))
            {
                for (int i = 0; i < shapes.size(); i++)
                {

                    if (shapes[i] != null && shapes[i]._enabled)
                    {
                        shapes[i].MoveOn(
                            displacement.dx, displacement.dy,
                            pictureBox.Width,
                            0,
                            pictureBox.Height,
                            0);
                    }
                }
            }

            if (key == Keys.Delete)
            {
                for (int i = 0; i < shapes.size(); i++)
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

        private void button1_Click(object sender, EventArgs e)
        {
            shapes = new VectorCCircle<ShapeViewer>();
            pictureBox.Invalidate();
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
        public ShapeViewer(Brush color, bool enabled)
        {
            setColor(color);
            _enabled = enabled;
        }
        public ShapeViewer(Point position, Brush color, bool enabled)
        {
            _position = position;
            _enabled = enabled;
            setColor(color);
        }
        public void MoveOn(int dx, int dy, int maxX, int minX, int maxY, int minY)
        {
            if (InWorkspace(maxX - dx, minX - dx, maxY - dy, minY - dy))
            {
                _position.X += dx;
                _position.Y += dy;
            }
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
                (_position.X < maxX) &&
                (_position.X > minX) &&
                (_position.Y < maxY) &&
                (_position.Y > minY);

        }

    }

    class CircleViewer : ShapeViewer
    {
        private Circle circle;
        public CircleViewer(Brush color, bool enabled) : base(color, enabled) { }
        public CircleViewer(Point position, uint radius, Brush color, bool enabled):base(position, color, enabled)
        {
            circle = new Circle(position, radius);
        }
        override public void Draw(PaintEventArgs e)
        {
            var args = ( this._position.X - this.circle.getRadius(),
                    this._position.Y - this.circle.getRadius(),
                    this.circle.getRadius() * 2,
                    this.circle.getRadius() * 2);
            e.Graphics.FillEllipse(_color, args);

            if (!_enabled)
            { 
                return;
            }
            e.Graphics.DrawEllipse(new Pen(Brushes.Black, 3),args);
        }
        override public bool IsHitIn(MouseEventArgs e)
        {
            return
                ((_position.X - e.X) * (_position.X - e.X)
                + (_position.Y - e.Y) * (_position.Y - e.Y)
                <=
                circle.getRadius() * circle.getRadius());
        }
    }
    public static class GraphicsExtension
    {
        public static void DrawEllipse(this Graphics gr, Pen pen, (float x, float y, float width, float height) args)
        {
            gr.DrawEllipse(pen, args.Item1, args.Item2, args.Item3, args.Item4);
        }
        public static void FillEllipse(this Graphics gr, Brush color, (float x, float y, float width, float height) args)
        {
            gr.FillEllipse(color, args.Item1, args.Item2, args.Item3, args.Item4);
        }   
    }
    
    class SquadeViewer : ShapeViewer
    {
        private Squade squade;
        public SquadeViewer(Brush color, bool enabled) : base(color, enabled) { }
        public SquadeViewer(Point position, uint side, Brush color, bool enabled):base(position, color, enabled)
        {
            squade = new Squade(position, side);
        }
        override public void Draw(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(
                    _color,
                    this._position.X,
                    this._position.Y,
                    squade._side,
                    squade._side
                    );

            if (!_enabled)
            {
                return;
            }
            Pen pen = new Pen(Brushes.Black, 3);
            e.Graphics.DrawEllipse(
                    pen,
                    this._position.X,
                    this._position.Y,
                    squade._side,
                    squade._side
                    );
        }
        public override bool IsHitIn(MouseEventArgs e)
        {
            return Math.Abs(_position.X - e.X) < squade._side && Math.Abs(_position.Y - e.Y) < squade._side;
        }

    }
}
