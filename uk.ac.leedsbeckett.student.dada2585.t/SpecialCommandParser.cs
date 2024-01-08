using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    /// <summary>
    /// this is supposed to be the command parser class for executing commands
    /// </summary>
    public class SpecialCommandParser
    {
        // private PictureBox pictureBox;
        Cursor cursor;
        // private Canvas canvas;
        string penPositon = "moveto";
        string drawingPosition = "drawto";
        string drawCircle = "circle";
        string drawRectangle = "rectangle";
        string drawTriangle = "triangle";
        string clearDrawing = "clear";
        string resetPicture = "reset";
        string penColour = "pen";
        string fillShape = "fill";
        string runCommand = "run";
        string expression = @"^\S+ = \d+$";
        string expression2 = @"^\S+ = \S+ + \S+$";
        string expression3 = @"^\S+ = \S+\s*\+\s*\S+$";
        string expression4 = @"^\S+ = \S+\s*\+\s*\d+$";
        string expression5 = @"^\S+ = \S+ + \d+$";
        string ifExpression = @"^if \S+ == \d+$";
        string endIf = @"^endif$";
        string method = @"method (?<methodName>\w+)(?<parameters>\(.+?\))";
        string endMethod = @"^endMethod$";
        string methodCall = @"(?<methodName>\w+)(?<parameters>\(.+?\))";

        /// <summary>
        /// the method for handling a parsed commands
        /// </summary>
        /// <param name="commands">list of commads to be executed</param>
        /// <param name="pictureBox">picture box control for rendering the commands</param>
        public void ParseCommand(List<string> commands, PictureBox pictureBox, RichTextBox commandInputField)
        {
            int x = StateManager.Instance.X;
            int y = StateManager.Instance.Y;
            Color color = StateManager.Instance.C;
            bool fill = StateManager.Instance.F;
            Canvas canvas = new Canvas(pictureBox);
            CommandParser parser = new CommandParser();
            // for (int i = 0; i < commands.Count; i++)
            // {
                
                string[] parameters = commands[0].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                
                if (Regex.IsMatch(commands[0], ifExpression, RegexOptions.IgnoreCase) == true)
                {
                    List<string> commandList = new List<string>();
                    var v1 = VariablesHandler.GetVariable(parameters[1]);
                    int a = int.Parse($"{v1}");
                    int b = int.Parse(parameters[3]);
                    if(a == b)
                    {
                        for (int j = 1; j < commands.Count; j++)
                        {
                            if (Regex.IsMatch(commands[j], endIf, RegexOptions.IgnoreCase) == true)
                            {
                                break;
                            }
                            commandList.Add(commands[j].ToLower());
                        }
                        parser.ParseCommand(commandList, pictureBox, commandInputField);
                    }
                }
                else if (Regex.IsMatch(commands[0], method, RegexOptions.IgnoreCase) == true)
                {
                List<string> command = new List<string>();
                Match match = Regex.Match(commands[0], method, RegexOptions.IgnoreCase);
                    string MethodName = match.Groups["methodName"].Value;
                    string parameterleValue = match.Groups["parameters"].Value;
                    MethodsHandler.SetMethod(MethodName, parameterleValue);
                    for (int j = 1; j < commands.Count; j++)
                    {
                        if (Regex.IsMatch(commands[j], endMethod, RegexOptions.IgnoreCase) == true)
                        {
                            break;
                        }
                    command.Add(commands[j].ToLower());
                    }
                    string methodCommands = string.Join(", ", command);
                MethodsHandler.SetMethodCommands(MethodName, methodCommands);
                }
                else
                {
                    throw new InvalidOperationException($"Invalid command {commands[0]}");
                }
            // }
        }
    }
}
