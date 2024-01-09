using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    public class Threading
    {
        public  void InitiateThread(string[] commands, PictureBox pictureBox, RichTextBox textbox1, RichTextBox textbox2)
        {
            Canvas canvas = new Canvas(pictureBox);
            CommandParser parser = new CommandParser();
            for (int i = 0; i < commands.Length; i++)
            {
                Circles circle = new Circles(Color.AliceBlue, 100, 50*i, false, 50*i);
                canvas.AddShape(circle);
                pictureBox.BeginInvoke((MethodInvoker)delegate
                {
                    // Canvas canvas = new Canvas(pictureBox);
                    canvas.AddShape(circle);
                });
                Thread.Sleep(500);
            }
        }

        public void TriggerThread(List<string> commandsA, List<string> commandsB, PictureBox pictureBox, RichTextBox textbox)
        {
            CommandParser parser = new CommandParser();
            parser.ParseCommand(commandsA, pictureBox, textbox);
        }
    }
}
