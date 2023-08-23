namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class UI
    {
        public static string GetPlayerName()
        {
            Console.WriteLine("Enter your user name:");
            return Console.ReadLine();
        }

        public static string UserInput()
        {
            return Console.ReadLine();
        }

        public static void Output(string output)
        {
            Console.WriteLine(output);
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static bool AskToContinue()
        {
            Console.WriteLine("\nContinue? (y/n)");
            string answer = Console.ReadLine();
            bool wantToContinue = !string.IsNullOrEmpty(answer) && answer.Trim().ToLower() == "y";
            return wantToContinue;
        }

        public static string GamesMenu(PlayerData player)
        {
            Console.WriteLine($"Hello {player.Name} and Welcome," +
                $"\nWhat would you like to play?" +
                $"\n1. MooGame" +
                $"\n2. MasterMind" +
                $"\n9. Exit");
            return UserInput();
        }
    }
}
