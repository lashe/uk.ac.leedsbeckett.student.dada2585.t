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
        string penColour = "pen";
        string fillShape = "fill";
        string runCommand = "run";

        /// <summary>
        /// the method for handling a parsed commands
        /// </summary>
        /// <param name="commands">list of commads to be executed</param>
        /// <param name="pictureBox">picture box control for rendering the commands</param>
        public void ParseCommand(List<string> commands, PictureBox pictureBox, RichTextBox commandInputField)
        {
            int x = StateManager.Instance.X;
            int y = StateManager.Instance.Y;
            Color color = StateManager.Instance.C;
            bool fill = StateManager.Instance.F;
            Canvas canvas = new Canvas(pictureBox);
            for (int i = 0; i < commands.Count; i++)
            {
                string[] parameters = commands[i].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parameters[0] == penPositon )
                {
                    // move cursor to new coordinates
                    Cursor cursor = new Cursor(x, y);
                    //cursor.MoveCursor(cursor.X, cursor.Y);
                    Pointer pointer = new Pointer(color, cursor.X, cursor.Y, fill);
                    canvas.AddShape(pointer);
                    StateManager.Instance.X = x;
                    StateManager.Instance.Y = y;
                    //pictureBox.Invalidate();
                }
                else if (parameters[0] == drawingPosition)
                {
                    // draw a line to new coordinates
                    int x2 = int.Parse(parameters[1]);
                    int y2 = int.Parse(parameters[2]);
                    Lines line = new Lines(color, x, y, fill, x2, y2);
                    canvas.AddShape(line);
                    StateManager.Instance.X = x2;
                    StateManager.Instance.Y = y2;
                }
                else if (parameters[0] == drawCircle)
                {
                    // draw circle
                    int r = int.Parse(parameters[1]);
                    Circles circle = new Circles(color, x, y, fill, r);
                    canvas.AddShape(circle);

                }
                else if (parameters[0] == drawRectangle)
                {
                    // draw rectangle
                    int w = int.Parse(parameters[1]);
                    int h = int.Parse(parameters[2]);
                    Rectangles rectangle = new Rectangles(color, x, y, fill, w, h);
                    canvas.AddShape(rectangle);

                }
                else if (parameters[0] == drawTriangle)
                {
                    // draw triangle
                    int x2 = int.Parse(parameters[1]);
                    int y2 = int.Parse(parameters[2]);
                    int x3 = int.Parse(parameters[3]);
                    int y3 = int.Parse(parameters[4]);
                    Triangles triangle = new Triangles(color, x, y,fill, x2, y2, x3, y3);
                    canvas.AddShape(triangle);
                }
                else if (commands[i] == clearDrawing)
                {
                    // clear all drawing
                    canvas.ClearCanvas();
                    Cursor cursor = new Cursor(x, y);
                    Pointer pointer = new Pointer(color, cursor.X, cursor.Y, fill);
                    canvas.AddShape(pointer);
                    //pictureBox.Invalidate();

                }
                else if (commands[i] == resetPicture)
                {
                    // clear picturebox and return cursor to starting point
                    canvas.ResetCursor();
                    Cursor cursor = new Cursor(10, 10);
                    Pointer pointer = new Pointer(color, cursor.X, cursor.Y, fill);
                    canvas.AddShape(pointer);
                    StateManager.Instance.X = cursor.X;
                    StateManager.Instance.Y = cursor.Y;
                    StateManager.Instance.C = Color.Black;
                    StateManager.Instance.F = false;
                    pictureBox.Refresh();
                }
                else if (parameters[0] == fillShape)
                {
                    // turn fill on to fill shapes with colour
                    if (parameters[1] == "on")
                    {
                        StateManager.Instance.F = true;
                    }
                    // turn fill off to outline shape
                    else if (parameters[1] == "off")
                    {
                        StateManager.Instance.F = false;
                    }
                }
                else if (parameters[0] == penColour)
                {
                    // change pen colour
                    Color SetColour;

                    switch (parameters[1])
                    {
                        case "black":
                            SetColour = Color.Black;
                            StateManager.Instance.C = SetColour;
                            break;
                        case "red":
                            SetColour = Color.Red;
                            StateManager.Instance.C = SetColour;
                            break;
                        case "yellow":
                            SetColour = Color.Yellow;
                            StateManager.Instance.C = SetColour;
                            break;
                        case "green":
                            SetColour = Color.Green;
                            StateManager.Instance.C = SetColour;
                            break;
                        default:
                        throw new ArgumentException($"Invalid command pen {parameters[1]}");

                    }
                }
                else if (commands[i] == runCommand)
                {
                    RunCommand.Run_Command(pictureBox, commandInputField);
                }
                throw new InvalidOperationException($"Invalid command {commands[i]}");
            }
        }
    }
}
