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

                string guess = UI.UserInput();
                string bbcc = _game.CheckGuess(guess);
                UI.Output(bbcc);

                while (bbcc != "BBBB,")
                {
                    player.TotalGuesses++;
                    guess = UI.UserInput();
                    bbcc = _game.CheckGuess(guess);
                    UI.Output(bbcc);
                }

                string response = Statistics.SaveResult(player, filename);
                UI.Output(response);
                Statistics.ShowTopList(filename);

                playOn = UI.AskToContinue();
                if (playOn)
                {
                    UI.Clear();
                    UI.Output("New round!");
                }
            }
        }

        private string GetGameName()
        {
            var gameName = _game.GetType().Name;
            var indexOfS = gameName.IndexOf('S');
            var filename = gameName.Substring(0, indexOfS) + ".txt";
            return filename;
        }
    }
}
