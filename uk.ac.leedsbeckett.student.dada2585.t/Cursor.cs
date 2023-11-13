using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    public class Cursor
    {
        public int x;
        public int y;
        /*public int X { get; set; }
        public int Y { get; set; }*/

        public Cursor(int initialx, int initialy)
        {
            x = initialx;
            y = initialy;
        }

        public int X { 
            get { return x; }
            set { x = value; }
        }
        public int Y { 
            get { return y; } 
            set { y = value; }
        }
        public void DrawCursor(Graphics g)
        {
            Pen pen = new Pen(Color.Green, 2);
            g.DrawEllipse(pen, X, Y, 5, 5);
        }

        public void MoveCursor(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
