using System.Collections;
using System.Drawing;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    /// <summary>
    /// this is the entry poin of the project
    /// </summary>
    public partial class Form1 : Form
    {
        Bitmap drawBitmap;
        Cursor cursor;
        CommandParser parser = new CommandParser();
        Boolean mouseDown = false;
        ArrayList shapes = new ArrayList();
        List<string> commandList = new List<string>();
        ArrayList errorList = new ArrayList();
        private Canvas canvas;
        public Form1()
        {
            InitializeComponent();
            // set initial points for cursor
            cursor = new Cursor(10, 10);
            drawBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = drawBitmap;
            StateManager.Instance.X = cursor.X;
            StateManager.Instance.Y = cursor.Y;
            StateManager.Instance.F = false;
            StateManager.Instance.C = Color.Black;
            canvas = new Canvas(pictureBox1);
            Pointer pointer = new Pointer(Color.Black, cursor.X, cursor.Y, false);
            canvas.AddShape(pointer);
        }
        /// <summary>
        /// this is the button for checking the syntax of a command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SyntaxCheckButtonClick(object sender, EventArgs e)
        {
            /*Graphics g = pictureBox1.CreateGraphics();
            string[] commands = commandInputField.Lines;
            try
            {
                if (commandInputField.Text == "")
                {
                    // error handler
                    MessageBox.Show("empty input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CommandCheck checkCommand = new CommandCheck();
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
                        // throw error
                        ErrorHandler.HandleError(errorList, g);
                        pictureBox1.Invalidate();

                    }
                    else
                    {
                        MessageBox.Show("Syntax Ok", "Syntax Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    *//*Font font = new Font("Times New Roman", 10);
                    Brush brush = Brushes.Red;
                    string response = "Syntax OK";
                    g.DrawString(response, font, brush, 10, 10);
                    pictureBox1.Image = drawBitmap;*//*
                }*/
            string command = textBox1.Text;
            try
            {
                if (textBox1.Text == "")
                {
                    // error handler
                    MessageBox.Show("empty input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    CommandCheck checkCommand = new CommandCheck();
                    if (checkCommand.CheckCommand(command) == true)
                    {
                        MessageBox.Show("Syntax Ok", "Syntax Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Syntax Error", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// button function for reading and executing contents of the programme line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RunCommandButtonClick(object sender, EventArgs e)
        {
            RunCommand.Run_Command(pictureBox1, commandInputField);
            /*Graphics g = pictureBox1.CreateGraphics();
            // Graphics g = Graphics.FromImage(drawBitmap);
            string[] commands = commandInputField.Lines;
            try
            {
                if (commandInputField.Text == "")
                {
                    // error handler
                    MessageBox.Show("command missing", "Syntax Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // check the syntax for each command in the list of commands
                    CommandCheck checkCommand = new CommandCheck();
                    for (int i = 0; i < commands.Length; i++)
                    {
                        if (checkCommand.CheckCommand(commands[i].ToLower()) == true)
                        {
                            commandList.Add(commands[i].ToLower());
                        }
                        else
                        {
                            string error = $"error on line {i + 1} at {commands[i]}";
                            errorList.Add(error);
                        }

                    }
                    if (errorList.Count > 0)
                    {
                        // throw error
                        ErrorHandler.HandleError(errorList, g);
                        pictureBox1.Invalidate();

                    }
                    parser.ParseCommand(commandList, pictureBox1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(ex.ToString());
            }*/
        }

        /// <summary>
        /// method for saving commands to text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFileButtonClick(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (commandInputField.Text == "")
            {
                Graphics graphics = pictureBox1.CreateGraphics();

                errorList.Add("no text input");
                ErrorHandler.HandleError(errorList, graphics);
            }
            else
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.Write(commandInputField.Text);
                    }

                    MessageBox.Show("save successful", "Success", MessageBoxButtons.OK);
                }
            }

        }

        /// <summary>
        /// method forloading text file into the programme line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFileButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    commandInputField.Text = reader.ReadToEnd();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //Cursor cursor;
            //Cursor cur = new Cursor(50, 50);
            /*StateManager.Instance.X = 60;
            StateManager.Instance.Y = 60;
            Pointer pointer = new Pointer(60, 60);
            canvas.AddShape(pointer);
            Lines line = new Lines(10, 10, 50, 50);
            canvas.AddShape(line);
            Triangles triangle = new Triangles(10, 10, 60, 60, 40, 40);
            canvas.AddShape(triangle);
            Circles circle = new Circles(50, 50, 50);
            canvas.AddShape(circle);
            Rectangles rectangle = new Rectangles(40, 40, 70, 50);
            canvas.AddShape(rectangle);*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            canvas.ClearCanvas();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            canvas.ResetCursor();
        }

        /// <summary>
        /// method for reading input on the command line immediately a command is entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            Graphics g = Graphics.FromImage(drawBitmap);
            // Graphics g = pictureBox1.CreateGraphics();
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                try
                {
                    CommandCheck checkCommand = new CommandCheck();
                    if (checkCommand.CheckCommand(textBox1.Text.ToLower()) == true)
                    {
                        if (textBox1.Text == "run")
                        {
                        }
                        commandList.Add(textBox1.Text.ToLower());
                    }
                    else
                    {
                        string error = $"syntax error on line 1 at {textBox1.Text}";
                        errorList.Add(error);
                    }
                    if (errorList.Count > 0)
                    {
                        // throw error
                        ErrorHandler.HandleError(errorList, g);
                        pictureBox1.Image = drawBitmap;
                    }
                    else if (errorList.Count == 0)
                    {
                        parser.ParseCommand(commandList, pictureBox1, commandInputField);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }
        }
    }
}
