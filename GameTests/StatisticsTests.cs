using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clean_Code_Lab_Johannes_Ragnarsson;

namespace Clean_Code_Lab_Johannes_Ragnarsson.Tests
{
    [TestClass()]
    public class StatisticsTests
    {
        //Classname_MethodName_ExpectedResult

        [TestMethod()]
        public void Statistics_SplitString_ReturnsArray()
        {
            //Arrange - get variables, get classes and methods
            string splitter = "#&#";
            string lineToSplit = "Johannes#&#1#&#2";

            string firstPart = "Johannes";
            string middlePart = "1";
            string lastPart = "2";

            //Act - execute this function
            string[] splittedLine = Statistics.SplitString(lineToSplit, splitter);

            //Assert - What is returned is what is expected
            Assert.AreEqual(firstPart, splittedLine[0]);
            Assert.AreEqual(middlePart, splittedLine[1]);
            Assert.AreEqual(lastPart, splittedLine[2]);
        }
    }
}