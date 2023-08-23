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

                string guess = UserInterface.UserInput();
                string bbcc = _game.CheckGuess(guess);
                Console.WriteLine(bbcc);

                while (bbcc != "BBBB,")
                {
                    player.TotalGuesses++;
                    guess = UserInterface.UserInput();
                    bbcc = _game.CheckGuess(guess);
                    Console.WriteLine(bbcc);
                }

                string response = Statistics.SaveResult(player, filename);
                Console.WriteLine(response);
                Statistics.ShowTopList(filename);

                playOn = UserInterface.AskToContinue();
                if (playOn)
                {
                    Console.Clear();
                    Console.WriteLine("New round!");
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
