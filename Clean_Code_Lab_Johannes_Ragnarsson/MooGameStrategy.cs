namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class MooGameStrategy : IGameStrategy
    {
        private readonly GameLogic _gameLogic;
        private string _goal;
        private int _maxGuessLength = 5;
        private int _goalLength = 4;

        public MooGameStrategy(GameLogic gameLogic)
        {
            _gameLogic = gameLogic;
            _goal = _gameLogic.GenerateGoal(_goalLength);
            UI.Output("For practice, number is: " + _goal);
        }

        public string CheckGuess(string guess)
        {
            if (guess.Length < _maxGuessLength)
            {
                guess = guess.PadRight(_goalLength);
                return _gameLogic.CheckGuess(_goal, guess);
            }
            else
            {
                return $"You entered {guess.Length} characters but only {_goalLength} is allowed, try again";
            }
        }

        public string GetInitialMessage()
        {
            return "New game:" + PracticeMessage();
        }

        private string PracticeMessage()
        {
            return "\nFor practice, number is: " + _goal;
        }

        public string GetGoal()
        {
            return _goal; 
        }
    }
}
