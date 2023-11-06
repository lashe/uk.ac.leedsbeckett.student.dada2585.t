using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    internal class Rectangle:Shape
    {
        protected int width, height;

        public Rectangle(Color colour, int x, int y,int width, int height) : base(colour, x, y)
        {
            this.width = width;
            this.height = height;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush sb = new SolidBrush(colour);
            g.FillRectangle(sb, x, y, width, height);
            g.DrawRectangle(p, x, y, width, height);

        }
    }
}
