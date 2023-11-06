using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    internal class Shape
    {
        protected Color colour;
        protected int x; protected int y;

        public Shape(Color colour, int x, int y)
        {
            this.colour = colour;
            this.x = x;
            this.y = y;
        }
        public virtual void draw(Graphics g)
        {

        }
    }
}
