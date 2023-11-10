using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    internal class CommandCheck
    {
         string penPositon = @"^moveto \d+ \d+$";
         string drawingPosition = @"^drawto \d+ \d+$";
         string drawCircle = @"^circle \d+$";
         string drawRectangle = @"^rectangle \d+ \d+$";
         string drawTriangle = @"^triangle \d+$";

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
            else
            {
                return false;
            }
        }
    }
}
