using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
            string ifExpression = @"^if \S+ == \d+$";
            string endIf = @"^endif$";
            string method = @"method (?<methodName>\w+)(?<parameters>\(.+?\))";
            string endMethod = @"^endMethod$";
            ArrayList shapes = new ArrayList();
            List<string> commandList = new List<string>();
            List<string> specialCommandList = new List<string>();
            ArrayList errorList = new ArrayList();
            CommandParser parser = new CommandParser();
            SpecialCommandParser specialCommandParser = new SpecialCommandParser();
            CommandChecker checkCommand = new CommandChecker();
            Bitmap drawBitmap;
            drawBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
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
                    if (Regex.IsMatch(commands[0], ifExpression, RegexOptions.IgnoreCase) == true || Regex.IsMatch(commands[0], method, RegexOptions.IgnoreCase) == true)
                    {
                        for (int i = 0; i < commands.Length; i++)
                        {
                            if (checkCommand.CheckCommand(commands[i].ToLower()) == true)
                            {
                                specialCommandList.Add(commands[i].ToLower());
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
                            
                            pictureBox1.Image = drawBitmap;

                        }
                        specialCommandParser.ParseCommand(specialCommandList, pictureBox1, commandInputField);
                    }
                    else
                    {
                        // check the syntax for each command in the list of commands
                        for (int i = 0; i < commands.Length; i++)
                        {
                            if (checkCommand.CheckCommand(commands[i].ToLower()) == true)
                            {
                                commandList.Add(commands[i].ToLower());
                            }
                            else
                            {
                                string error = $"syntax error on line {i + 1} at {commands[i]}";
                                errorList.Add(error);
                            }

                        }
                        if (errorList.Count > 0)
                        {
                            // throw error
                            throw new CustomException(errorList);
                            

                        }
                        parser.ParseCommand(commandList, pictureBox1, commandInputField);
                    }
                    
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
