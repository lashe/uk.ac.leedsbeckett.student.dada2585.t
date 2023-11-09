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
        protected string penPositon = @"^moveto \d+ \d+$";
        protected string drawingPosition = @"^moveto \d+ \d+$";
        protected string drawCircle = @"^circle \d+ \d+$";
        protected string drawRectangle = @"^rectangle \d+ \d+$";
        protected string drawTriangle = @"^triangle \d+$";
        protected Boolean checkCommand;

        public CommandCheck( string command)
        {
            if (Regex.IsMatch(command, penPositon, RegexOptions.IgnoreCase))
            {
                checkCommand = true;
                return;
            }
            else if (Regex.IsMatch(command, drawingPosition, RegexOptions.IgnoreCase))
            {
                checkCommand = true;
                return;
            }
            else if( Regex.IsMatch(command, drawCircle, RegexOptions.IgnoreCase))
            {
                checkCommand = true;
                return;
            }
            else if(Regex.IsMatch(command, drawTriangle, RegexOptions.IgnoreCase))
            {
                checkCommand = true;
                return;
            }
            else if (Regex.IsMatch(command, drawRectangle, RegexOptions.IgnoreCase))
            {
                checkCommand= true;
                return;
            }
            else
            {
                checkCommand = false;
                return;
            }
        }
    }
}
