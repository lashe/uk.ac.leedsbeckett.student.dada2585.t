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
            // Arrange
            string command = "drawto 10, 10";
            CommandChecker commandCheck = new CommandChecker();

            // Act
            commandCheck.CheckCommand(command);

            // Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Test for valid Draw Circle command execution parameters
        /// </summary>
        [Test]
        public void DrawCircleCommand()
        {
            // Arrange
            Color color = Color.Black;
            int x = 15;
            int y = 15;
            int r = 100;
            bool fill = false;

            // Act
            var DrawCircle = new Circles(color, x, y, fill, r);

            //Assert
            Assert.IsNotNull(DrawCircle);
        }

        /// <summary>
        /// Test for valid Draw Rectangle command execution parameters
        /// </summary>
        [Test]
        public void DrawRectangleCommand()
        {
            // Arrange
            Color color = Color.Red;
            int x = 15;
            int y = 15;
            int h = 100;
            int w = 200;
            bool fill = true;

            // Act
            var DrawRectangle = new Rectangles(color, x, y, fill, w, h);

            // Assert
            Assert.IsNotNull(DrawRectangle);
        }

        /// <summary>
        /// Test for valid Draw Triangle command execution parameters
        /// </summary>
        [Test]
        public void DrawTriangleCommand()
        {
            // Arrange 
            Color color = Color.Yellow;
            int x = 15;
            int y = 15;
            int x2 = 100;
            int y2 = 200;
            int x3 = 300;
            int y3 = 500;
            bool fill = false;

            // Act
            var DrawTriangle = new Triangles(color, x, y, fill, x2, y2, x3, y3);

            // Assert
            Assert.IsNotNull(DrawTriangle);
        }

        /// <summary>
        /// Test for valid Draw Line command execution parameters
        /// </summary>
        [Test]
        public void DrawLineCommand()
        {

            // Arrange 
            Color color = Color.Yellow;
            int x = 15;
            int y = 15;
            int x2 = 100;
            int y2 = 200;
            bool fill = false;

            // Act
            var DrawLine = new Lines(color, x, y, fill, x2, y2);

            // Assert
            Assert.IsNotNull(DrawLine);
        }

        /// <summary>
        /// Test for moving the cursor/pen start point from one point to another on the canvas
        /// </summary>
        [Test]
        public void MoveCursorCommand()
        {
            // Arrange
            Color color = Color.Black;
            int x = 15;
            int y = 15;
            bool fill = true;

            // Act
            var MovePoints = new Pointer(color, x, y, fill);

            // Assert
            Assert.IsNotNull(MovePoints);
        }

        [Test]
        public void CreateVariable()
        {
            // Arrange
            string variableName = "size";
            string variableValue = "10";

            // Act
            VariablesHandler.SetVariable(variableName, variableValue);

            // Assert
            object actualSetValue = VariablesHandler.GetVariable(variableName);
            object v = actualSetValue;
            Assert.IsNotNull(v);
            Assert.AreEqual(variableValue, actualSetValue);
        }

        //[Test]
        //public void GetVariable()
        //{
        //    // Arrange

        //    // Act  

        //    // Assert
        //}

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