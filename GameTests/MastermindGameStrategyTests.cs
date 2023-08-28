using Clean_Code_Lab_Johannes_Ragnarsson;

namespace GameTests
{
    [TestClass()]
    public class MastermindGameStrategyTests
    {
        private MastermindGameStrategy _mastermindGameTest = new MastermindGameStrategy();

        //Classname_Methodname_ExpectedResult
        [TestMethod()]
        public void MastermindGameStrategy_CheckGuess_CorrectCharSequenceDependingOnInput()
        {
            //Arrange            
            string allCorrect = "CCCCCC,";

            _mastermindGameTest.Initialize();
            string guessCorrectSequence = _mastermindGameTest._goal;

            //Act            
            string correctCharacters = _mastermindGameTest.CheckGuess(guessCorrectSequence);
            Console.WriteLine(correctCharacters);
            //Assert
            Assert.AreEqual(allCorrect, correctCharacters);
        }

        [TestMethod]
        public void MastermindGameStrategy_GenerateGoal_SixRandomIntegersAsString()
        {
            //Arrange

            //Act
            string goal = _mastermindGameTest.GenerateGoal();

            //Assert
            bool isNumbers = Int32.TryParse(goal, out int goalNumbers);
            Assert.IsTrue(isNumbers);
            Assert.IsTrue(goal.Length == 6);
        }
    }
}
