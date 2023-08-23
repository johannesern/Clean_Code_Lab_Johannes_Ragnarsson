namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    class Program
    {
        static void Main(string[] args)
        {

            string playerName = UserInterface.GetPlayerName();
            int totalGuesses = 1;
            PlayerData player = new PlayerData(playerName, totalGuesses);

            IGameStrategy mooGame = new MooGameStrategy();
            GameController gameController = new GameController(mooGame);

            gameController.PlayGame(player);
            
        
        }
    }    
}