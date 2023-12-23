using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    /// <summary>
    /// this is class that handles getting and setting the shape parameters for drawing a Circle
    /// </summary>
    public class Circles: SShapes
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public int Radius { get; set; }

        /// <summary>
        /// drawing a circle
        /// </summary>
        /// <param name="x">the x coordinate for a bitmap</param>
        /// <param name="y">the y coordinates for a bitmap</param>
        /// <param name="radius">the radius of the circle to be drawn</param>
        public Circles(int x, int y, int radius) 
        { 
            X = x;
            Y = y;
            Radius = radius;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gph">this is the graphics parameter used for rendering the drawn shape</param>
        public void Draw(Graphics gph)
        {
            Pen p = new Pen(Color.Black, 2);
            gph.FillEllipse(Brushes.Transparent, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            gph.DrawEllipse(p, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
        }
    }
    /// <summary>
    /// class responsible for drawing a rectangle
    /// </summary>
    public class Rectangles : SShapes
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
/// <summary>
/// method for drawing a rectangle
/// </summary>
/// <param name="x">the x coordinates</param>
/// <param name="y">the y coordinates</param>
/// <param name="width">width of the rectangle to be drawn</param>
/// <param name="height">height of the rectangle to be drawn</param>
        public Rectangles(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public void Draw(Graphics gph)
        {
            Pen p = new Pen(Color.Black, 2);
            gph.FillRectangle(Brushes.Transparent, X, Y, Width, Height);
            gph.DrawRectangle(p, X, Y, Width, Height);
        }
    }
    /// <summary>
    /// the class responsible for drawing lines from one point to the other
    /// </summary>
    public class Lines : SShapes
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        /// <summary>
        /// method for drawing a line
        /// </summary>
        /// <param name="x">x coordinate for the starting point of the line</param>
        /// <param name="y">y coordinate for the starting point of the line</param>
        /// <param name="x2">x coordinate of the end point of the line</param>
        /// <param name="y2">y coordinate of the end point of the line</param>
        public Lines(int x, int y, int x2, int y2)
        {
            X = x;
            Y = y;
            X2 = x2;
            Y2 = y2;
        }
        public void Draw(Graphics gph)
        {
            Pen p = new Pen(Color.Black, 2);
            gph.DrawLine(p, X, Y, X2, Y2);
        }
    }
    /// <summary>
    /// class responsible for drawing a triangle
    /// </summary>
    public class Triangles : SShapes
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int X3 { get; set; }
        public int Y3 { get; set; }
        /// <summary>
        /// method for drawing triangle
        /// below are the X and Y points for drawing the triangle
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        public Triangles(int x, int y, int x2, int y2, int x3, int y3)
        {
            X = x;
            Y = y;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }
        public void Draw(Graphics gph)
        {
            Point A = new Point(X, Y);
            Point B = new Point(X2, Y2);
            Point C = new Point(X3, Y3);
            Point[] triangle = { A, B, C };
            Pen p = new Pen(Color.Black, 2);
            // gph.FillPolygon(Brushes.Black, triangle);
            gph.DrawPolygon(p, triangle);
        }
    }
    /// <summary>
    /// class responsible for drawing the cursor point on the canvas
    /// </summary>
    public class Pointer : SShapes
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Pointer(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Draw(Graphics gph)
        {
            Pen p = new Pen(Color.Green, 2);
            gph.FillEllipse(Brushes.Green, X, Y, 5, 5);
            gph.DrawEllipse(p, X, Y, 5, 5);
        }
    }

    public class Strings : SShapes
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Error { get; set; }

        public Strings(int x, int y, string error)
        {
            X = x;
            Y = y;
            Error = error;
        }
        public void Draw(Graphics gph)
        {
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Red;
            Pen p = new Pen(Color.Green, 2);
            gph.DrawString(Error, font, brush, X, Y);
        }
    }
}
