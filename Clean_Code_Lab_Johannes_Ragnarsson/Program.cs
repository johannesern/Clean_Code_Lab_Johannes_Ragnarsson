using System.Security.Cryptography.X509Certificates;

namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    class Program
    {
        static void Main(string[] args)
        {

            string playerName = UI.GetPlayerName();
            int totalGuesses = 0;
            var player = new PlayerData(playerName, totalGuesses);

            bool run = true;
            while (run)
            {
                string response = UI.GamesMenu(player);
                switch (response)
                {
                    case "1":
                        IGameStrategy mooGame = new MooGameStrategy();
                        GameController mooController = new GameController(mooGame);
                        mooController.PlayGame(player);
                        break;
                    case "2":
                        IGameStrategy mastermindGame = new MastermindGameStrategy();
                        GameController mastermindController = new GameController(mastermindGame);
                        mastermindController.PlayGame(player);
                        break;
                    case "9":
                        Environment.Exit(0);
                        break;
                    default:
                        UI.Output("Wrong input, try again");
                        break;
                }
            }
        }
    }    
}