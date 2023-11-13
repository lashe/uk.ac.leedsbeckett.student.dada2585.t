using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    /// <summary>
    /// this is supposed to be the command parser class for executing commands
    /// </summary>
    public class CommandParser
    {
        // private PictureBox pictureBox;
        Cursor cursor;
        // private Canvas canvas;
        string penPositon = "moveto";
        string drawingPosition = "drawto";
        string drawCircle = "circle";
        string drawRectangle = "rectangle";
        string drawTriangle = "triangle";
        string clearDrawing = "clear";
        string resetPicture = "reset";
        string penColour = @"pen";
        string fillShape = @"fill";

        /// <summary>
        /// the method for handling a parsed commands
        /// </summary>
        /// <param name="commands">list of commads to be executed</param>
        /// <param name="pictureBox">picture box control for rendering the commands</param>
        public void ParseCommand(List<string> commands, PictureBox pictureBox)
        {
            Canvas canvas = new Canvas(pictureBox);
            for (int i = 0; i < commands.Count; i++)
            {
                string[] parameters = commands[i].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parameters[0] == penPositon )
                {
                    // move cursor to new coordinates
                    int x = int.Parse(parameters[1]);
                    int y = int.Parse(parameters[2]);
                    Cursor cursor = new Cursor(x, y);
                    //cursor.MoveCursor(cursor.X, cursor.Y);
                    Pointer pointer = new Pointer(cursor.X, cursor.Y);
                    canvas.AddShape(pointer);
                    StateManager.Instance.X = x;
                    StateManager.Instance.Y = y;
                    //pictureBox.Invalidate();
                }
                else if (parameters[0] == drawingPosition)
                {
                    // draw a line to new coordinates
                    int x = StateManager.Instance.X;
                    int y = StateManager.Instance.Y;
                    int x2 = int.Parse(parameters[1]);
                    int y2 = int.Parse(parameters[2]);
                    Lines line = new Lines(x, y, x2, y2);
                    canvas.AddShape(line);
                    StateManager.Instance.X = x2;
                    StateManager.Instance.Y = y2;
                }
                else if (parameters[0] == drawCircle)
                {
                    // draw circle
                    int x = StateManager.Instance.X; 
                    int y = StateManager.Instance.Y;
                    int r = int.Parse(parameters[1]);
                    Circles circle = new Circles(x, y, r);
                    canvas.AddShape(circle);

                }
                else if (parameters[0] == drawRectangle)
                {
                    // draw rectangle
                    int x = StateManager.Instance.X;
                    int y = StateManager.Instance.Y;
                    int w = int.Parse(parameters[1]);
                    int h = int.Parse(parameters[2]);
                    Rectangles rectangle = new Rectangles(x, y, w, h);
                    canvas.AddShape(rectangle);

                }
                else if (parameters[0] == drawTriangle)
                {
                    // draw triangle
                    int x = StateManager.Instance.X;
                    int y = StateManager.Instance.Y;
                }
                else if (parameters[0] == clearDrawing)
                {
                    // clear all drawing
                    canvas.ClearCanvas();
                    int x = StateManager.Instance.X;
                    int y = StateManager.Instance.Y;
                    Cursor cursor = new Cursor(x, y);
                    Pointer pointer = new Pointer(cursor.X, cursor.Y);
                    canvas.AddShape(pointer);
                    //pictureBox.Invalidate();

                }
                else if (parameters[0] == resetPicture)
                {
                    // clear picturebox and return cursor to starting point
                    canvas.ResetCursor();
                    Cursor cursor = new Cursor(10, 10);
                    Pointer pointer = new Pointer(cursor.X, cursor.Y);
                    canvas.AddShape(pointer);
                    StateManager.Instance.X = cursor.X;
                    StateManager.Instance.Y = cursor.Y;
                    //pictureBox.Invalidate();
                }
            }
        }
    }
}
