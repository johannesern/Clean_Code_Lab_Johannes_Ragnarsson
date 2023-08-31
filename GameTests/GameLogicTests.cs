using Clean_Code_Lab_Johannes_Ragnarsson;

namespace GameTests
{
    [TestClass()]
    public class GameLogicTests
    {
        [DataTestMethod()]
        [DataRow("1234", "1234", "CCCC,")]
        [DataRow("1234", "2134", "CC,AA")]
        [DataRow("123456", "123456", "CCCCCC,")]
        [DataRow("123456", "123645", "CCC,AAA")]
        public void GameLogic_CheckGuess_CorrectSymbolsDependingOnInput(string goal, string guess, string expected)
        {
            //Arrange
            GameLogic gameLogic = new GameLogic();

            //Act
            string result = gameLogic.CheckGuess(goal, guess);
            Console.WriteLine(result);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod()]
        [DataRow(4, 4)]
        [DataRow(6, 6)]
        public void GameLogic_GenerateGoal_CorrectAmountOfNumbersAndIsNumbers(int goalLength, int expectedLength)
        {
            //Arrange
            GameLogic gameLogic = new GameLogic();

            //Act
            string result = gameLogic.GenerateGoal(goalLength);

            //Assert
            Assert.AreEqual(expectedLength, result.Length);
        }
    }
}
