using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    /// <summary>
    /// class responsible for checking the accuracy and comparing command syntaxes against a set of predefined syntaxes to see if they match what is expected
    /// </summary>
    public class CommandChecker
    {
        string penPositon = @"^moveto \d+, \d+$";
        string runCommand = @"^run$";
        string drawingPosition = @"^drawto \d+, \d+$";
        string drawCircle = "circle";
        string drawRectangle = "rectangle";
        string drawTriangle = @"^triangle \d+, \d+, \d+, \d+$";
        string clearDrawing = @"^clear$";
        string resetPicture = @"^reset$";
        string penColour = @"^pen \S+$";
        string fillShapeOn = @"^fill on$";
        string fillShapeOff = @"^fill off$";
        string expression = @"^\S+ = \d+$";
        string expression2 = @"^\S+ = \S+ + \S+$";
        string expression3 = @"^\S+ = \S++\S+$";
        string expression4 = @"^\S+ = \S++\d+$";
        string expression5 = @"^\S+ = \S+ + \d+$";
        string ifExpression = @"^\if \S+ == \d+$";
        string endIf = @"^endif$";
        string thread = @"^thread$";


        /// <summary>
        /// method used to determine the syntax accuracy of a command
        /// </summary>
        /// <param name="command">a string of command to be compared against predefined syntaxes</param>
        /// <returns></returns>
        public bool CheckCommand( string command)
        {
            string[] parameters = command.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (Regex.IsMatch(command, penPositon, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, drawingPosition, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (parameters[0] == drawCircle && parameters.Length == 2)
            {
                if ((int.TryParse(parameters[1], out int result) && result > 0))
                {
                    return true;
                }
                else if (!int.TryParse(parameters[1], out int result2) && parameters[1] is string)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if(Regex.IsMatch(command, drawTriangle, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (parameters[0] == drawRectangle && parameters.Length == 3)
            {
                if ((int.TryParse(parameters[1], out int result) && result > 0 || parameters[1] is string) && (int.TryParse(parameters[2], out int result2) && result2 > 0 || parameters[2] is string))
                {
                    return true;
                }
                return false;
            }
            else if (Regex.IsMatch(command, clearDrawing, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, resetPicture, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, runCommand, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, penColour, RegexOptions.IgnoreCase) == true)
            {
                if (parameters[1] == "black")
                {
                    return true;
                }
                else if (parameters[1] == "red")
                {
                    return true;
                }
                else if (parameters[1] == "yellow")
                {
                    return true;
                }
                else if (parameters[1] == "green")
                {
                    return true;
                }
                return false;
            }
            else if (Regex.IsMatch(command, fillShapeOn, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, fillShapeOff, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, expression, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, expression2, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, expression2, RegexOptions.IgnoreCase) == true || Regex.IsMatch(command, expression3, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, expression4, RegexOptions.IgnoreCase) == true || Regex.IsMatch(command, expression5, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, ifExpression, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, thread, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
