using uk.ac.leedsbeckett.student.dada2585.t;
namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void commandInput()
        {
            string command = "drawto 10, 10";
            CommandCheck commandCheck = new CommandCheck();
            commandCheck.CheckCommand(command);
            Assert.IsTrue(true);
        }

        [Test]
        public void DrawShape() 
        {
            
        }
    }
}