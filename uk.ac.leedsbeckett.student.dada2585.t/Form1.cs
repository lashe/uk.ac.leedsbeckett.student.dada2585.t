using System.Collections;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    public partial class Form1 : Form
    {
        Bitmap drawBitmap = new Bitmap(534, 605);
        Pen drawinPen = new Pen(Color.Green, 3);
        Boolean mouseDown = false;
        ArrayList shapes = new ArrayList();
        public Form1()
        {
            InitializeComponent();

            //add shapes
            shapes.Add(new Circle(Color.AliceBlue, 10, 100, 100));
            shapes.Add(new Circle(Color.Fuchsia, 100, 10, 50));
            shapes.Add(new Rectangle(Color.Beige, 100, 100, 50, 100));
            shapes.Add(new Triangle(Color.Red, 300, 200, 300));
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // g.DrawImageUnscaled(drawBitmap, 0, 0);
            for (int i = 0; i < shapes.Count; i++)
            {
                Shape s;
                s = (Shape)shapes[i];
                s.draw(g);
                Console.WriteLine(s.ToString());
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown) 
            {
                return;
            }
            Graphics g = Graphics.FromImage(drawBitmap);
            g.DrawLine(drawinPen, e.X, e.Y, e.X + 1, e.Y + 1);
            Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}