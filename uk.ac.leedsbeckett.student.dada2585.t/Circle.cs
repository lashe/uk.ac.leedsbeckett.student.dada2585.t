﻿using System;
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
        public Circle(Color colour, int x, int y, int radius) : base(colour, x, y)
        {
            this.radius = radius;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush sb = new SolidBrush(colour);
            g.FillEllipse(sb, x, y, radius + 2, radius + 2);
            g.DrawEllipse(p, x, y, radius + 2, radius + 2);

        }
    }
}
