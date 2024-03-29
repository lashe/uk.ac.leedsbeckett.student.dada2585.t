﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.Intrinsics;

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
        string expression = @"^\S+ = \d+$";
        string expression2 = @"^\S+ = \S+ + \S+$";
        string expression3 = @"^\S+ = \S+\s*\+\s*\S+$";
        string expression4 = @"^\S+ = \S+\s*\+\s*\d+$";
        string expression5 = @"^\S+ = \S+ + \d+$";
        string ifExpression = @"^if \S+ == \d+$";
        string endIf = @"^endif$";
        string method = @"method (?<methodName>\w+)(?<parameters>\(.+?\))";
        string endMethod = @"^endMethod$";
        string methodCall = @"(?<methodName>\w+)(?<parameters>\(.+?\))";

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
                    //Cursor cursor = new Cursor(x, y);
                    //cursor.MoveCursor(cursor.X, cursor.Y);
                    int x2 = int.Parse(parameters[1]);
                    int y2 = int.Parse(parameters[2]);
                    Pointer pointer = new Pointer(color, x2, y2, fill);
                    canvas.AddShape(pointer);
                    StateManager.Instance.X = x2;
                    StateManager.Instance.Y = y2;
                    //pictureBox.Invalidate();
                }
                else if (parameters[0] == drawingPosition)
                {
                    // draw a line to new coordinates
                    int x2 = int.Parse(parameters[1]);
                    int y2 = int.Parse(parameters[2]);
                    Lines line = new Lines(color, x, y, fill, x2, y2);
                    canvas.AddShape(line);
                    Pointer pointer = new Pointer(color, x, y, fill);
                    canvas.AddShape(pointer);
                    StateManager.Instance.X = x2;
                    StateManager.Instance.Y = y2;
                }
                else if (parameters[0] == drawCircle)
                {
                    // draw circle
                    if(int.TryParse(parameters[1], out int result) && result > 0)
                    {
                        int r = int.Parse(parameters[1]);
                        Circles circle = new Circles(color, x, y, fill, r);
                        canvas.AddShape(circle);
                    }
                    else
                    {
                        object v1 = VariablesHandler.GetVariable(parameters[1]);
                        int r = int.Parse($"{v1}");
                        Circles circle = new Circles(color, x, y, fill, r);
                        canvas.AddShape(circle);
                    }
                    

                }
                else if (parameters[0] == drawRectangle)
                {
                    if (int.TryParse(parameters[1], out int result) && int.TryParse(parameters[2], out int result2))
                    {
                        // draw rectangle
                        int w = int.Parse(parameters[1]);
                        int h = int.Parse(parameters[2]);
                        Rectangles rectangle = new Rectangles(color, x, y, fill, w, h);
                        canvas.AddShape(rectangle);
                    }
                    else
                    {
                        var v1 = VariablesHandler.GetVariable(parameters[1]);
                        var v2 = VariablesHandler.GetVariable(parameters[2]);
                        int w = int.Parse($"{v1}");
                        int h = int.Parse($"{v2}");
                        Rectangles rectangle = new Rectangles(color, x, y, fill, w, h);
                        canvas.AddShape(rectangle);
                    }
                    

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
                else if (Regex.IsMatch(commands[i], expression, RegexOptions.IgnoreCase) == true)
                {
                    string variableName = parameters[0];
                    string variableValue = parameters[2];
                    VariablesHandler.SetVariable(variableName, variableValue);
                }
                else if (Regex.IsMatch(commands[i], expression2, RegexOptions.IgnoreCase) == true)
                {
                    string variableName = parameters[0];
                    var v2 = VariablesHandler.GetVariable(parameters[2]);
                    var v3 = VariablesHandler.GetVariable(parameters[4]);
                    int a = int.Parse($"{v2}");
                    int b = int.Parse($"{v3}");
                    int c = a + b;
                    string variableValue = c.ToString();
                    VariablesHandler.SetVariable(variableName, variableValue);
                }
                else if (Regex.IsMatch(commands[i], expression3, RegexOptions.IgnoreCase) == true)
                {
                    string[] parts = commands[i].Split('=');
                    string variableName = parts[0].Trim();
                    string expression = parts[1].Trim();
                    string[] splitexpression = expression.Split('+');
                    string variableName2 = splitexpression[0];
                    string variableName3 = splitexpression[1];
                    if(int.TryParse(variableName3, out int result) && result > 0)
                    {
                        var v2 = VariablesHandler.GetVariable(variableName2);
                        int a = int.Parse($"{v2}");
                        int b = int.Parse($"{splitexpression[1]}");
                        int c = a + b;
                        string variableValue = c.ToString();
                        VariablesHandler.SetVariable(variableName, variableValue);
                    }
                    else
                    {
                        var v2 = VariablesHandler.GetVariable(variableName2);
                        var v3 = VariablesHandler.GetVariable(variableName3);
                        int a = int.Parse($"{v2}");
                        int b = int.Parse($"{v3}");
                        int c = a + b;
                        string variableValue = c.ToString();
                        VariablesHandler.SetVariable(variableName, variableValue);
                    }
                }
                else if (Regex.IsMatch(commands[i], expression4, RegexOptions.IgnoreCase) == true)
                {
                    string[] parts = commands[i].Split('=');
                    string variableName = parts[0].Trim();
                    string expression = parts[1].Trim();
                    string[] splitexpression = expression.Split('+');
                    string variableName2 = splitexpression[0];
                    var v1 = VariablesHandler.GetVariable(variableName);
                    var v2 = VariablesHandler.GetVariable(variableName2);
                    int a = int.Parse($"{v2}");
                    int b = int.Parse($"{splitexpression[1]}");
                    int c = a + b;
                    string variableValue = c.ToString();
                    VariablesHandler.SetVariable(variableName, variableValue);
                }
                else if (Regex.IsMatch(commands[i], expression5, RegexOptions.IgnoreCase) == true)
                {
                    string variableName = parameters[0];
                    string variableName2 = parameters[2];
                    int a = int.Parse(parameters[4]);
                    var v1 = VariablesHandler.GetVariable(variableName);
                    var v2 = VariablesHandler.GetVariable(variableName2);
                    int b = int.Parse($"{v2}");
                    int c = a + b;
                    string variableValue = c.ToString();
                    VariablesHandler.SetVariable(variableName, variableValue);
                }
                else if (Regex.IsMatch(commands[i], ifExpression, RegexOptions.IgnoreCase) == true)
                {
                    List<string> commandList = new List<string>();
                    var v1 = VariablesHandler.GetVariable(parameters[1]);
                    int a = int.Parse($"{v1}");
                    int b = int.Parse(parameters[3]);
                    if(a == b)
                    {
                        for (int j = i+1; j < commands.Count; j++)
                        {
                            if (Regex.IsMatch(commands[j], endIf, RegexOptions.IgnoreCase) == true)
                            {
                                break;
                            }
                            commandList.Add(commands[j].ToLower());
                        }
                        this.ParseCommand(commandList, pictureBox, commandInputField);
                    }
                }
                else if (Regex.IsMatch(commands[i], method, RegexOptions.IgnoreCase) == true)
                {
                    List<string> command = new List<string>();
                    Match match = Regex.Match(commands[i], method, RegexOptions.IgnoreCase);
                    string MethodName = match.Groups["methodName"].Value;
                    string variableValue = match.Groups["parameters"].Value;
                    MethodsHandler.SetMethod(MethodName, variableValue);
                    MessageBox.Show(commands[i]);
                    for (int j = i + 1; j < commands.Count - 1; j++)
                    {
                        //if (Regex.IsMatch(commands[j], endMethod, RegexOptions.IgnoreCase) == true)
                        //{
                        //    continue;
                        //}
                        command.Add(commands[j].ToLower());
                    }
                    string methodCommands = string.Join(", ", command);
                    MethodsHandler.SetMethodCommands(MethodName, methodCommands);
                    MessageBox.Show(methodCommands);
                }
                else if (Regex.IsMatch(commands[i], methodCall, RegexOptions.IgnoreCase) == true)
                {
                    Match match = Regex.Match(commands[i], methodCall, RegexOptions.IgnoreCase);
                    string MethodName = match.Groups["methodName"].Value;
                    string variableValue = match.Groups["parameters"].Value;
                    string passsedParams = variableValue.Trim('(', ')');
                    string[] splitParams = passsedParams.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var getParams = MethodsHandler.GetMethod(MethodName);
                    string methodParams = getParams.ToString();
                    string storedParams = methodParams.Trim('(', ')');
                    string[] splitMethodParams = storedParams.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if(splitMethodParams.Length == splitParams.Length)
                    {
                        List<string> commandList = new List<string>();
                        List<string> newCmd = new List<string>();
                        var value = MethodsHandler.GetMethodCommands(MethodName);
                        string methodCommands = value.ToString();
                        MessageBox.Show(methodCommands);
                        string[] indvCmd = methodCommands.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        for (int ic = 0; ic < indvCmd.Length; ic++)
                        {
                            string[] cmdParams = indvCmd[ic].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int cp = 1; cp < cmdParams.Length; cp++)
                            {
                                for (int mp = 0; mp < splitMethodParams.Length; mp++)
                                {
                                    if (splitMethodParams[cp].Equals(cmdParams[mp]) && cmdParams.Length == 2)
                                    {
                                        newCmd.Add(cmdParams[0] + splitParams[cp]);
                                    }
                                    else if(splitMethodParams[cp].Equals(cmdParams[mp]) && cmdParams.Length > 2)
                                    {
                                        if(cmdParams[cp].Equals(cmdParams[1]))
                                        {
                                            newCmd.Add(cmdParams[0] + splitParams[cp]);
                                        }
                                        else
                                        {
                                            newCmd.Add(splitParams[cp]);
                                        }
                                    }
                                }
                            }
                            if(cmdParams.Length == 2)
                            {
                                string newCommand = $"{newCmd[0]}";
                                commandList.Add(newCommand);
                            }
                            else
                            {
                                string newCommand = string.Join(", ", newCmd);
                                commandList.Add(newCommand);
                            }
                        }
                        string viewList = string.Join(", ", commandList);
                        //MessageBox.Show(viewList);
                        // AppendTextToTextBox(viewList);
                        // this.ParseCommand(commandList, pictureBox, commandInputField);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Invalid command {commands[i]}");
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Invalid command {commands[i]}");
                }
            }
        }
    }
}
