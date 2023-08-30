namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class MastermindGameStrategy : IGameStrategy
    {
        private readonly GameLogic _gameLogic;
        private string _goal;
        private int _maxGuessLength = 7;
        private int _goalLength = 6;

        public MastermindGameStrategy(GameLogic gameLogic)
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
            return "New game:\nFor practice, number is: " + _goal;
        }

        public string GetGoal()
        {
            return _goal;
        }
    }
}
