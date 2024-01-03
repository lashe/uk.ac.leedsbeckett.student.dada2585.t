using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    internal class Circle : Shape
    {
        protected int radius;
        public Circle(Color colour, int x, int y, bool fill, int radius) : base(colour, x, y)
        {
            this.radius = radius;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(colour, 2);
            SolidBrush sb = new SolidBrush(colour);
            g.FillEllipse(sb, x-radius, y-radius, radius * 2, radius * 2);
            g.DrawEllipse(p, x - radius, y - radius, radius * 2, radius * 2);

        }
    }
}
