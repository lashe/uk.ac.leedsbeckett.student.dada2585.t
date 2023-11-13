using System;
using System.Collections;
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
        public static void HandleError(ArrayList errors, Graphics g)
        {
            g.Clear(Color.White);
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Red;
            int x = 10;  int y = 10;
            foreach (string error in errors)
            {
                g.DrawString(error, font, brush, x, y);
                y += (int)font.GetHeight();
            }
            
        }
        
    }
}
