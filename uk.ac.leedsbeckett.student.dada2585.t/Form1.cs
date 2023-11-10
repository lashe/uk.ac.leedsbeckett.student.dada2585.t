using System.Collections;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    public partial class Form1 : Form
    {
        Bitmap drawBitmap = new Bitmap(534, 436);
        Pen drawinPen = new Pen(Color.Green, 3);
        Boolean mouseDown = false;
        ArrayList shapes = new ArrayList();
        ArrayList commandList = new ArrayList();
        ArrayList errorList = new ArrayList();
        public Form1()
        {
            InitializeComponent();

            //add shapes
            /*shapes.Add(new Circle(Color.AliceBlue, 10, 100, 100));
            shapes.Add(new Circle(Color.Fuchsia, 100, 10, 50));
            shapes.Add(new Rectangle(Color.Beige, 100, 100, 50, 100));
            shapes.Add(new Triangle(Color.Red, 300, 100, 300));*/
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

        private void button1_Click(object sender, EventArgs e)
        {
            string[] commands = commandInputField.Lines;
            try
            {
                if (commandInputField.Text == "")
                {
                    // error handler
                    pictureBox1.Image = null;
                    Graphics g = Graphics.FromImage(drawBitmap);
                    Font font = new Font("Arial", 10);
                    Brush brush = Brushes.Red;
                    string response = "no command entered";
                    g.DrawString(response, font, brush, 10, 10);
                    pictureBox1.Image = drawBitmap;
                }
                else
                {
                    CommandCheck checkCommand = new CommandCheck();
                    // Graphics g = Graphics.FromImage(drawBitmap);
                    Graphics graphics = pictureBox1.CreateGraphics();
                    graphics.Clear(Color.White);
                    for (int i = 0; i < commands.Length; i++)
                    {
                        if (checkCommand.CheckCommand(commands[i]) == true)
                        {
                            commandList.Add(commands[i]);
                        }
                        else
                        {
                            string error = $"error on line {i + 1} at {commands[i]}";
                            errorList.Add(error);
                        }

                    }
                    if (errorList.Count > 0)
                    {
                        // execute command
                    }
                    Console.WriteLine(errorList);
                    graphics.Clear(Color.White);
                    Font font = new Font("Arial", 10);
                    Brush brush = Brushes.Red;
                    int x = 10; int y = 10;
                    foreach (string error in errorList)
                    {
                        graphics.DrawString(error, font, brush, x, y);
                        y += (int)font.GetHeight();
                    }
                    //ErrorHandler.HandleError(errorList, graphics, font, brush, 10, 10);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}