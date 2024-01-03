using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    public class SShapes
    {
        protected Color colour;
        protected int x; protected int y;
        protected bool fill;

        public SShapes(Color colour, int x, int y, bool fill)
        {
            this.colour = colour;
            this.x = x;
            this.y = y;
            this.fill = fill;
        }
         public virtual void Draw(Graphics g)
        {

        }
    }
}
