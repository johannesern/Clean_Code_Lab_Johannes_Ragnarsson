using Clean_Code_Lab_Johannes_Ragnarsson;

namespace GameTests
{
    [TestClass()]
    public class MooGameStrategyTests
    {
        private MooGameStrategy _mooGameStrategy = new MooGameStrategy();

        //Classname_Methodname_ExpectedResult
        [TestMethod]
        public void MooGameStrategy_CheckGuess_CorrectCharSequenceDependingOnInput()
        {
            //Arrange            
            string allBulls = "BBBB,";
            
            _mooGameStrategy.Initialize();
            string guessCorrectSequence = _mooGameStrategy._goal;

            //Act            
            string bullsAndOrCows = _mooGameStrategy.CheckGuess(guessCorrectSequence);
            Console.WriteLine(bullsAndOrCows);
            //Assert
            Assert.AreEqual(allBulls, bullsAndOrCows);
        }

        [TestMethod]
        public void MooGameStrategy_GenerateGoal_FourRandomIntegersAsString()
        {
            //Arrange

            //Act
            string goal = _mooGameStrategy.GenerateGoal();

            //Assert
            bool isNumbers = Int32.TryParse(goal, out int goalNumbers);
            Assert.IsTrue(isNumbers);
            Assert.IsTrue(goal.Length == 4);
        }
    }
}
