namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class GameController
    {
        private IGameStrategy _game;

        public GameController(IGameStrategy game)
        {
            _game = game;
        }

        public void PlayGame(PlayerData player) 
        {
            string filename = GetGameName();

            bool playOn = true;
            while (playOn)
            {

                _game.Initialize();

                string userGuess = CheckUserInput();
                string bullsAndCows = _game.CheckGuess(userGuess);
                UI.Output(bullsAndCows);

                while (bullsAndCows != "BBBB,")
                {
                    player.TotalGuesses++;
                    userGuess = CheckUserInput();
                    bullsAndCows = _game.CheckGuess(userGuess);
                    UI.Output(bullsAndCows);
                }

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

        private static string CheckUserInput()
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
