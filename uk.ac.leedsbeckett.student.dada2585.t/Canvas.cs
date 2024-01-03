using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
  /// <summary>
  /// canvas class for drawing onto the picture box
  /// </summary>
    internal class Canvas
    {
        /// <summary>
        /// global variables that are accessible throughout the class
        /// </summary>
        Cursor cursor;
        private PictureBox pictureBox;
        private List<SShapes> shapes;

        /// <summary>
        /// the canvas method for setting the picture box to be drawn on
        /// </summary>
        /// <param name="pictureBox">the picture box control object</param>
        public Canvas(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            shapes = new List<SShapes>();
            initializeCanvas();
        }

        private void initializeCanvas()
        {
            pictureBox.Paint += PictureBox_Paint;
        }
        /// <summary>
        /// paint method for drawing onto the picture box from a list of shape commads passed into it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            //DrawPointer(e.Graphics);
            
             foreach (SShapes shape in shapes)
            {
                shape.Draw(e.Graphics);
                // cursor.DrawCursor(e.Graphics);
            }
        }
        /// <summary>
        /// method for adding a shape to a list shapes to be drawn in the picture box
        /// </summary>
        /// <param name="shape"> a defined shape from the shape class</param>
        public void AddShape(SShapes shape)
        {
            shapes.Add(shape);
            pictureBox.Invalidate();
        }
        private void DrawPointer(Graphics g)
        {
            /*Pointer pointer = new Pointer();
            pointer.Draw(g);*/
        }
        /// <summary>
        /// method for clearing the canvas off all drawings
        /// </summary>
        public void ClearCanvas()
        {
            shapes.Clear();
            pictureBox.Invalidate();
            int x = StateManager.Instance.X;
            int y = StateManager.Instance.Y;
            Color color = StateManager.Instance.C;
            bool fill = StateManager.Instance.F;
            shapes.Add(new Pointer(color, x, y, fill));
        }

        /// <summary>
        /// method for resetting the cnavas to its initial state before any drawing is done
        /// </summary>
        public void ResetCursor()
        {
            shapes.Clear();
            StateManager.Instance.X = 10;
            StateManager.Instance.Y = 10;
            Color color = StateManager.Instance.C;
            bool fill = StateManager.Instance.F;
            pictureBox.Invalidate();
            shapes.Add(new Pointer(color, 10, 10, fill));
            //initializeCanvas();

        }
    }
}
