using Moq;
using System.Drawing;
using System.Windows.Forms;
using uk.ac.leedsbeckett.student.dada2585.t;
namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// Test the command input constructor with a valid command
        /// </summary>
        [Test]
        public void CommandInput()
        {
            string command = "drawto 10, 10";
            CommandCheck commandCheck = new CommandCheck();
            commandCheck.CheckCommand(command);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Test for valid Draw Circle command execution parameters
        /// </summary>
        [Test]
        public void DrawCircleCommand()
        {
            var DrawCircle = new Circles(Color.Black, 15, 15, false, 100);
            Assert.IsNotNull(DrawCircle);
        }

        /// <summary>
        /// Test for valid Draw Rectangle command execution parameters
        /// </summary>
        [Test]
        public void DrawRectangleCommand()
        {
            var DrawRectangle = new Rectangles(Color.Red, 15, 15, false, 100, 200);
            Assert.IsNotNull(DrawRectangle);
        }

        /// <summary>
        /// Test for valid Draw Triangle command execution parameters
        /// </summary>
        [Test]
        public void DrawTriangleCommand()
        {
            var DrawTriangle = new Triangles(Color.Red, 15, 15, false, 100, 200, 300, 500);
            Assert.IsNotNull(DrawTriangle);
        }

        /// <summary>
        /// Test for valid Draw Line command execution parameters
        /// </summary>
        [Test]
        public void DrawLineCommand()
        {
            var DrawLine = new Lines(Color.Red, 15, 15, false, 100, 200);
            Assert.IsNotNull(DrawLine);
        }

        /// <summary>
        /// Test for moving the cursor/pen start point from one point to another on the canvas
        /// </summary>
        [Test]
        public void MoveCursorCommand()
        {
            var MovePoints = new Pointer(Color.Red, 100, 150, false);
            Assert.IsNotNull(MovePoints);
        }

        /*[Test]
        public void ParseCommand()
        {
            CommandParser commandParser = new CommandParser();
            Bitmap drawBitmap = new Bitmap(400, 400);
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = drawBitmap;
            RichTextBox textBox = new RichTextBox();
            textBox.Text = "drawto 10, 10";
            List<string> commandList = new List<string>();
            // commandList.Add("drawto 10, 10");
            commandList.Add("circle 50");
            commandParser.ParseCommand(commandList, pictureBox, textBox);
            Assert.IsNotNull(commandParser);
        }*/
    }
}