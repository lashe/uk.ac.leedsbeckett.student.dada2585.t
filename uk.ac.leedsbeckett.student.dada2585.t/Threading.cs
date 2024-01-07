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
        public  void InitiateThread(string[] commands, PictureBox pictureBox)
        {
            Canvas canvas = new Canvas(pictureBox);
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
    }
}
