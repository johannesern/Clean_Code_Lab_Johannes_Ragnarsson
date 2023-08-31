namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class GameController
    {
        private readonly IGameStrategy _game;
        private readonly string _goal;
        private readonly string _correctGoalSequence;

        public GameController(IGameStrategy game)
        {
            _game = game;
            _goal = _game.GetGoal();
            _correctGoalSequence = SetCorrectGoalLength();
        }

        public void PlayGame(PlayerData player) 
        {
            string filename = GetFileName();

            UI.Output("\nCorrect number at correct place generates C(orrect)" +
                "\nCorrect number but wrong place generates A(lmost)");
            UI.Output("New game:");

            //Uncomment for practice
            //_game.PracticeMessage();

            bool playOn = true;
            while (playOn)
            {
                player.TotalGuesses++;
                bool isCharIncorrect = EvaluateUserInput();                
                while (isCharIncorrect)
                {
                    player.TotalGuesses++;
                    isCharIncorrect = EvaluateUserInput();
                }

                UI.Output("You made it!");

                string userUpdated = Statistics.SaveResult(player, filename);
                UI.Output(userUpdated);
                Statistics.ShowTopList(filename);

                playOn = UI.AskToContinue();
                if (playOn)
                {
                    UI.Clear();
                    UI.Output("New round!");
                }
            }
        }

        private bool EvaluateUserInput()
        {
            string userGuess = CheckUserInput();
            string checkedCharacters = _game.CheckGuess(userGuess);
            UI.Output(checkedCharacters);

            bool isCharIncorrect = CheckForIncorrectChar(checkedCharacters);
            return isCharIncorrect;
        }

        private string CheckUserInput()
        {
            bool isEmpty;
            string userGuess;
            do
            {
                userGuess = UI.Input();
                isEmpty = String.IsNullOrEmpty(userGuess);
                if (isEmpty)
                {
                    UI.Output("\nCannot be an empty guess, try again...\n");
                }

            } while (isEmpty);

            return userGuess;
        }

        private string SetCorrectGoalLength()
        {
            string correctCombination = "";
            for (int i = 0; i < _goal.Length; i++)
            {
                correctCombination += "C";
            }
            return correctCombination + ",";
        }

        private bool CheckForIncorrectChar(string checkedCharacters)
        {
            
            if(checkedCharacters == _correctGoalSequence)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string GetFileName()
        {
            // For example, if _game is type of MooGameStrategy =>
            // then GetType.Name = MooGameStrategy
            // we remove Strategy and get our filename = MooGame.txt
            var gameName = _game.GetType().Name;
            var indexOfS = gameName.IndexOf('S');
            var filename = gameName.Substring(0, indexOfS) + ".txt";
            return filename;
        }
    }
}
