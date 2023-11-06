using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    internal class Triangle: Shape
    {
        protected int z;

        public Triangle(Color color, int x, int y, int z): base(color, x, y)
        {
            this.z = z;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush sb = new SolidBrush(colour);
            Point A = new Point(x, y);
            Point B = new Point(y, z);
            Point C = new Point(x, z);
            Point[] triangle = { A, B, C };
            g.DrawPolygon(p, triangle);
            g.FillPolygon(sb, triangle);

        }
    }
}
