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
    public class CommandCheck
    {
         string penPositon = @"^moveto \d+, \d+$";
        string runCommand = @"^run$";
        string drawingPosition = @"^drawto \d+, \d+$";
         string drawCircle = @"^circle \d+$";
         string drawRectangle = @"^rectangle \d+, \d+$";
         string drawTriangle = @"^triangle \d+, \d+, \d+, \d+$";
         string clearDrawing = @"^clear$";
         string resetPicture = @"^reset$";
         string penColour = @"^pen \S+$";
         string fillShapeOn = @"^fill on$";
         string fillShapeOff = @"^fill off$";

        /// <summary>
        /// method used to determine the syntax accuracy of a command
        /// </summary>
        /// <param name="command">a string of command to be compared against predefined syntaxes</param>
        /// <returns></returns>
        public bool CheckCommand( string command)
        {
            if (Regex.IsMatch(command, penPositon, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, drawingPosition, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if( Regex.IsMatch(command, drawCircle, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if(Regex.IsMatch(command, drawTriangle, RegexOptions.IgnoreCase) == true)
            {
                return true;
            }
            else if (Regex.IsMatch(command, drawRectangle, RegexOptions.IgnoreCase) == true)
            {
                return true;
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
                string[] parameters = command.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
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
            else
            {
                return false;
            }
        }
    }
}
