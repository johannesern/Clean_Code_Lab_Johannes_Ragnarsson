namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    class Program
    {
        static void Main(string[] args)
        {

            string playerName = UserInterface.GetPlayerName();
            int totalGuesses = 1;
            var player = new PlayerData(playerName, totalGuesses);

            string response = UserInterface.GamesMenu(player);
            switch (response)
            {
                case "1":
                    IGameStrategy mooGame = new MooGameStrategy();
                    GameController gameController = new GameController(mooGame);
                    gameController.PlayGame(player);
                    break;
                case "2":
                    break;
                default:
                    
                    break;
            }
        }
    }    
}