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
        const int SIZE = 60;
        delegate void PressKeyDelegate(VectorCCircle<ShapeViewer> shapes);

        delegate void PressKeyDelegate2(int d);
        delegate void constructor();

        Point start_point;
        Point final_point;

        Dictionary<Keys, PressKeyDelegate> KeyDelegate_Dictionary = new Dictionary<Keys, PressKeyDelegate>
        {
            [Keys.Add] = add,
            [Keys.Subtract] = sub,
            [Keys.Delete] = del
        };

        static void add(VectorCCircle<ShapeViewer> shapes)
        {
            for (int i = 0; i < shapes.size(); i++)
            {
                if (shapes[i] != null && shapes[i]._enabled)
                {
                    shapes[i].resizeOn(1);
                }
            }
        }
        static void sub(VectorCCircle<ShapeViewer> shapes)
        {
            for (int i = 0; i < shapes.size(); i++)
            {
                if (shapes[i] != null && shapes[i]._enabled)
                {
                    shapes[i].resizeOn(-1);
                }
            }
        }
        static void del(VectorCCircle<ShapeViewer> shapes)
        {
            for (int i = 0; i < shapes.size(); i++)
            {
                if (shapes[i] != null && shapes[i]._enabled)
                {
                    shapes.delCShape((uint)i);
                }
            }
        }
        static void col(VectorCCircle<ShapeViewer> shapes)
        {
            for (int i = 0; i < shapes.size(); i++)
            {
                if (shapes[i] != null)
                {

                }
            }
        }

        Dictionary<String, Brush> color_Dictionary = new Dictionary<String, Brush>
        {
            ["Белый"] = Brushes.White,
            ["Красный"] = Brushes.Red,
            ["Зеленый"] = Brushes.Green,
            ["Синий"] = Brushes.Blue,
            ["Коричневый"] = Brushes.Brown,
            ["Желтый"] = Brushes.Yellow

        };

        const int displacement = 10;
        Dictionary<Keys, (int dx, int dy)> KeysDxDy_Dictionary = new Dictionary<Keys, (int, int)>
        {
            [Keys.D] = (displacement, 0),
            [Keys.A] = (-displacement, 0),
            [Keys.S] = (0, displacement),
            [Keys.W] = (0, -displacement),
        };

        VectorCCircle<ShapeViewer> shapes = new VectorCCircle<ShapeViewer>();

        public Form1()
        {
            InitializeComponent();
            foreach (var color_item in color_Dictionary)
            {
                Color_comboBox.Items.Add(color_item.Key);
            }
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

                if (color_Dictionary.TryGetValue(Color_comboBox.Text, out Brush color))
                    if ((string)Shape_comboBox.SelectedItem == "Круг")
                    {
                        shape = new CircleViewer(e.Location, SIZE/2, color, true);
                    }
                    else if ((string)Shape_comboBox.SelectedItem == "Квадрат")
                    {
                        shape = new SquadeViewer(e.Location, SIZE, color, true);
                    }
                    else if ((string)Shape_comboBox.SelectedItem == "Треугольник")
                    {
                        shape = new TriangleViewer(e.Location, SIZE, color, true);
                    }
                    else if ((string)Shape_comboBox.SelectedItem == "Отрезок")
                    {
                        shape = new LineViewer(e.Location, start_point, color, true);
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

            if (KeysDxDy_Dictionary.TryGetValue(key, out (int dx, int dy) displacement))
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

            if (KeyDelegate_Dictionary.TryGetValue(key, out PressKeyDelegate handler))
            {
                handler(shapes);
            }

            pictureBox.Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            ctrl_key = e.Control;
            Keys key = e.KeyCode;
        }
        private void clear_button_Click(object sender, EventArgs e)
        {
            shapes = new VectorCCircle<ShapeViewer>();
            pictureBox.Invalidate();
        }

        private void Color_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < shapes.size(); i++)
            {
                if (shapes[i] != null && shapes[i]._enabled)
                {
                    shapes[i]._color = color_Dictionary[Color_comboBox.Text];
                }
            }
            pictureBox.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void reverse_selected_button_Click(object sender, EventArgs e)
        {
            for(var i = 0; i < shapes.size(); i++)
            {
                if (shapes[i] != null)
                    shapes[i]._enabled = !shapes[i]._enabled;
            }
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            start_point = new Point(e.Location.X, e.Location.Y);
            
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            final_point = new Point(e.Location.X, e.Location.Y);
        }
    }
    class VectorShapeViewer<Shape> : VectorCCircle<Shape>
    {
        private PictureBox _picture;
        public VectorShapeViewer(PictureBox picture) : base()
        {
            _picture = picture;
        }
    }
    interface Resizeable
    {
        void resizeOn(int dsize);
        void resize(uint new_size);

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
    public static class GraphicsExtension
    {
        public static void DrawEllipse(this Graphics gr, Pen pen, (float x, float y, float width, float height) args)
        {
            gr.DrawEllipse(pen, args.x, args.y, args.width, args.height);
        }
        public static void FillEllipse(this Graphics gr, Brush color, (float x, float y, float width, float height) args)
        {
            gr.FillEllipse(color, args.x, args.y, args.width, args.height);
        }
        public static void DrawTriangle(this Graphics gr, Pen pen, Point a, Point b, Point c)
        {
            gr.DrawLine(pen, a, b);
            gr.DrawLine(pen, b, c);
            gr.DrawLine(pen, a, c);
        }
        public static void FillTriangle(this Graphics gr, Brush color, Point a, Point b, Point c)
        {
        }
    }
}
