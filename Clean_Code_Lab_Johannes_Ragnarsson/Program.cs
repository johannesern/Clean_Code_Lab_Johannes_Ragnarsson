namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    class Program
    {
        static void Main(string[] args)
        {

            string playerName = UI.GetPlayerName();
            int totalGuesses = 0;
            var player = new PlayerData(playerName, totalGuesses);

            UI.GamesMenu(player);
            
        }
    }    
}