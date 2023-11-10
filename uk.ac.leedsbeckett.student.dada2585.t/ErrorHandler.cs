using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    internal class ErrorHandler
    {
        public static void HandleError(string[] errors, Graphics g, Font f, Brush b, int x, int y)
        {
            foreach (string error in errors)
            {
                g.DrawString(error, f, b, x, y);
                y += (int)f.GetHeight();
            }
            
        }
    }
}
