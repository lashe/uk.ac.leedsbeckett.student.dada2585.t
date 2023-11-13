using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    internal class Line: Shape
    {
        Cursor cursor;
        protected int x2;
        protected int y2;
        public Line(Color colour, int x, int y, int x2, int y2) : base(colour, x, y)
        {
            this.x2 = x2;
            this.x2 = y2;
        }

        public void draw(Graphics g, int x2, int y2)
        {
            Pen p = new Pen(Color.Black, 2);
            g.DrawLine(p, cursor.X, cursor.Y, x2, y2);

        }
    }
}
