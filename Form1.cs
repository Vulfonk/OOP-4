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
using System.IO;

namespace OOP_4
{

    public partial class Form1 : Form
    {
        string filename;
        bool ctrl_key = false;
        const int SIZE = 60;
        delegate void PressKeyDelegate(MyListShape shapes);

        delegate void PressKeyDelegate2(int d);
        delegate void constructor();

        Point start_point;
        Point final_point;

        Dictionary<string, string> ShapeEnRusDictionary = new Dictionary<string, string>
        {
            ["Квадрат"] = "Squade",
            ["Круг"] = "Circle",
            ["Отрезок"] = "Line",
            ["Треугольник"] = "Triangle"

        };

        Dictionary<Keys, PressKeyDelegate> KeyDelegate_Dictionary = new Dictionary<Keys, PressKeyDelegate>
        {
            [Keys.Add] = add,
            [Keys.Subtract] = sub,
            [Keys.Delete] = del
        };

        static void add(MyListShape shapes)
        {
            foreach (var shape in shapes)
            {
                if (shape.enabled)
                    shape.resizeOn(1);
            }

        }
        static void sub(MyListShape shapes)
        {
            foreach (var shape in shapes)
            {
                if (shape.enabled)
                    shape.resizeOn(-1);
            }
        }
        static void del(MyListShape shapes)
        {

            foreach (var shape in shapes)
            {
                if (shape.enabled)
                    shapes.Remove(shape);
            }
        }
        static void col(MyListShape shapes)
        {

        }

        Dictionary<String, Brush> color_Dictionary = new Dictionary<String, Brush>
        {
            ["Белый"] = Brushes.White,
            ["Красный"] = Brushes.Red,
            ["Зеленый"] = Brushes.Green,
            ["Синий"] = Brushes.Blue,
            ["Коричневый"] = Brushes.Brown,
            ["Желтый"] = Brushes.Yellow,
            ["Черный"] = Brushes.Black

        };

        const int displacement = 10;
        Dictionary<Keys, (int dx, int dy)> KeysDxDy_Dictionary = new Dictionary<Keys, (int, int)>
        {
            [Keys.D] = (displacement, 0),
            [Keys.A] = (-displacement, 0),
            [Keys.S] = (0, displacement),
            [Keys.W] = (0, -displacement),
        };

        MyListShape shapes = new MyListShape();

        public Form1()
        {
            InitializeComponent();
            foreach (var color_item in color_Dictionary)
            {
                Color_comboBox.Items.Add(color_item.Key);
            }
            TreeViewer tree = new TreeViewer(treeView1);
            shapes.Attach(tree);
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
                for (var i = shapes.Count - 1; i >= 0; i--)
                {
                    ShapeViewer shape = shapes.ElementAt(i);
                    if (ctrl_key)
                    {
                        if (shape.IsHitIn(e.Location))
                        {
                            shape.enabled = !shape.enabled;
                            break;
                        }
                    }
                    else
                    {
                        //flag &= !(shapes[i].enabled = shapes[i].IsHitIn(e) && flag);
                        if (shape.IsHitIn(e.Location) && flag)
                        {
                            shape.enabled = true;
                            flag = false;
                        }
                        else
                        {
                            shape.enabled = false;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < shapes.Count; i++)
                {
                    ShapeViewer shape = shapes.ElementAt(i);

                    if (shape != null)
                    {
                        shape.enabled = false;
                    }
                }

                if (color_Dictionary.TryGetValue(Color_comboBox.Text, out Brush color))
                {
                    ShapeViewer shape = null;
                    if ((string)Shape_comboBox.SelectedItem == "Круг")
                    {
                        shape = new CircleViewer(e.Location, SIZE / 2, color, true);
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
                    shapes.Add(shape);
                }
            }
            pictureBox.Invalidate();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                ShapeViewer shape = shapes.ElementAt(i);
                if (shape != null && !shape.enabled)
                {
                    shape.Draw(e.Graphics);
                }
            }
            for (int i = 0; i < shapes.Count; i++)
            {
                ShapeViewer shape = shapes.ElementAt(i);
                if (shape != null && shape.enabled)
                {
                    shape.Draw(e.Graphics);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl_key = e.Control;
            Keys key = e.KeyCode;

            if (KeysDxDy_Dictionary.TryGetValue(key, out (int dx, int dy) displacement))
            {
                bool flag = true;
                /*foreach (var shapemove in shapes)
                {
                    if (shapemove.enabled)
                    {
                        flag = shapemove.InWorkspace(maxX - dx, minX - dx, maxY - dy, minY - dy);
                    }
                    if (!flag)
                    {
                        break;
                    }
                }*/
                if (flag)
                    for (int i = 0; i < shapes.Count; i++)
                    {
                        ShapeViewer shape = shapes.ElementAt(i);

                        if (shape != null && shape.enabled)
                        {

                            shape.MoveOn(
                                displacement.dx, displacement.dy, new Rectangle(
                                    0,
                                    0,
                                    pictureBox.Width,
                                    pictureBox.Height)
                                );

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
            shapes.Clear();
            pictureBox.Invalidate();
        }

        private void Color_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                ShapeViewer shape = shapes.ElementAt(i);

                if (shape != null && shape.enabled)
                {
                    shape.color = color_Dictionary[Color_comboBox.Text];
                }
            }
            pictureBox.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void reverse_selected_button_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < shapes.Count; i++)
            {
                ShapeViewer shape = shapes.ElementAt(i);

                if (shape != null)
                    shape.enabled = !shape.enabled;
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

        private void grouping_button_Click(object sender, EventArgs e)
        {
            Group group = new Group(shapes);
            foreach (var shape in shapes)
            {
                if (shape.enabled)
                {
                    group.Add(shape);
                }
            }
            shapes.Add(group);
        }

        private void ungrouping_button_Click(object sender, EventArgs e)
        {
            foreach (var shape in shapes) 
            {
                if (shape.enabled && shape is IGroup)
                {
                    (shape as IGroup).ungroup();
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\shapes";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filename = openFileDialog.FileName;
                    this.Text = filename;
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        shapes.Clear();
                        shapes.LoadObject(reader);
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            pictureBox.Invalidate();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(filename == null)
            {
                сохранитьКакToolStripMenuItem_Click(sender, e);
            }
            string writePath = filename;
            try
            {
                StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default);


                foreach (var shape in shapes)
                {
                    shape.save(sw);
                }
                sw.WriteLine("end");
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            pictureBox.Invalidate();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string writePath = saveFileDialog1.FileName;
                try
                {
                    StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default);

                    filename = writePath;
                    this.Text = filename;
                    foreach (var shape in shapes)
                    {
                        shape.save(sw);
                    }
                    sw.WriteLine("end");
                    sw.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            pictureBox.Invalidate();
        }
       
        private void Menu_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    class VectorShapeViewer<ShapeViewer> : VectorCCircle<ShapeViewer>
    {
        private PictureBox _picture;
        public VectorShapeViewer(PictureBox picture) : base()
        {
            _picture = picture;
        }
    }
    public interface Resizeable
    {
        void resizeOn(int dsize);
        void resize(uint new_size);
    }
    public interface Drawable
    {
        Brush color { get; set; }
        bool enabled { get; set; }
        void Draw(Graphics e);
    }
    public interface Movable
    {
        bool MoveOn(int dx, int dy, Rectangle workspace);
        bool IsHitIn(Point e);
    }

    public static class PointExtension
    {
        public static bool InRect(this Point point, Rectangle rectangle)
        {
            return
                point.X > rectangle.X && point.X < rectangle.X + rectangle.Width &&
                point.Y > rectangle.Y && point.Y < rectangle.Y + rectangle.Height;
        }
    }
    public static class DictionaryExtention
    {
        public static string KeyWithValue(this Dictionary<String, Brush> pairs, Brush Value)
        {
            foreach (var pair in pairs.Keys)
            {
                if (pairs[pair] == Value)
                {
                    return pair;
                }
            }
            return null;
        }
    }
}
