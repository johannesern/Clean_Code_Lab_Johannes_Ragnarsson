namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    class Program
    {
        static void Main(string[] args)
        {

            string playerName = UserInterface.GetPlayerName();
            MooGameLogic.PlayGame(playerName);
        
        }
    }    
}