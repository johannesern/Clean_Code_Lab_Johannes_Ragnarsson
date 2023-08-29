using System.Net.Http.Headers;

namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class GameController
    {
        private IGameStrategy _game;
        private string _gameName;

        public GameController(IGameStrategy game)
        {
            _game = game;
            _gameName = GetGameName();
        }

        public void PlayGame(PlayerData player) 
        {
            string filename = GetFileName(_gameName);

            bool playOn = true;
            while (playOn)
            {

                _game.Initialize();

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

        private bool CheckCharsDependingOnGame(string checkedCharacters)
        {
            string correctMooGame = "BBBB,";
            string correctOtherGame = "CCCCCC,";

            if(checkedCharacters == correctMooGame)
            {
                return false;
            }
            else if(checkedCharacters == correctOtherGame)
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

        private string GetGameName()
        {
            var gameName = _game.GetType().Name;
            return gameName;
        }

        private string GetFileName(string gameName)
        {
            // For example, if _game is type of MooGameStrategy =>
            // then GetType.Name = MooGameStrategy
            // we remove Strategy and get our filename = MooGame.txt
            var indexOfS = gameName.IndexOf('S');
            var filename = gameName.Substring(0, indexOfS) + ".txt";
            return filename;
        }
    }
}
