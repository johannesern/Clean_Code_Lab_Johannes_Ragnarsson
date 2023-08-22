using Clean_Code_Lab_Johannes_Ragnarsson;

namespace GameTests
{
    [TestClass()]
    public class MooGameLogictests
    {
        //Classname_MethodName_ExpectedResult
        [TestMethod()]
        public void MooGameLogic_CheckBullsAndCows_ReturnStringWithCorrectCownsAndBulls()
        {
            //Arrange
            string goal = "1234";
            string guess = "1243";
            string correctBullsAndCows = "BB,CC";

            //Act
            var response = MooGameLogic.CheckBullsAndCows(goal, guess);

            //Assert
            Assert.AreEqual(correctBullsAndCows, response);
        }
    }
}
