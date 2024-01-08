using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    public class RunCommand
    {
        /// <summary>
        /// class that handles the run syntax and executes the command
        /// </summary>
        /// <param name="pictureBox1"></param>
        /// <param name="commandInputField"></param>
        public static void Run_Command(PictureBox pictureBox1, RichTextBox commandInputField) 
        {
            ArrayList shapes = new ArrayList();
            List<string> commandList = new List<string>();
            ArrayList errorList = new ArrayList();
            CommandParser parser = new CommandParser();
            Graphics g = pictureBox1.CreateGraphics();
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
                    //handling special commands

                    // check the syntax for each command in the list of commands
                    CommandChecker checkCommand = new CommandChecker();
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
                    parser.ParseCommand(commandList, pictureBox1, commandInputField);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
