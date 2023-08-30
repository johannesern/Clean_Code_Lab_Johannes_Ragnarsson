using System.Net.Http.Headers;

namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class GameController
    {
        private readonly IGameStrategy _game;
        private readonly string _goal;

        public GameController(IGameStrategy game)
        {
            _game = game;
            _goal = _game.GetGoal();
        }

        public void PlayGame(PlayerData player) 
        {
            string filename = GetFileName();
            
            UI.Output("\nCorrect number at correct place generates C(orrect)" +
                "\nCorrect number but wrong place generates A(lmost)");
            UI.Output(_game.GetInitialMessage());

            bool playOn = true;
            while (playOn)
            {
                player.TotalGuesses++;
                bool charIncorrect = EvaluateUserInput();                
                while (charIncorrect)
                {
                    player.TotalGuesses++;
                    charIncorrect = EvaluateUserInput();
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

            bool charIncorrect = CheckCharsDependingOnGame(checkedCharacters);
            return charIncorrect;
        }

        private string SetGoalSequence()
        {
            string correctCombination = "";
            for (int i = 0; i < _goal.Length; i++)
            {
                correctCombination += "C";
            }
            return correctCombination;
        }

        private bool CheckCharsDependingOnGame(string checkedCharacters)
        {
            var correctGoalSequence = SetGoalSequence();

            if(checkedCharacters == correctGoalSequence)
            {
                return false;
            }
            else
            {
                return true;
            }
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
