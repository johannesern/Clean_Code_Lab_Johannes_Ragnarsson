namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class UI
    {
        public static string GetPlayerName()
        {
            string username;
            bool isEmpty;
            do
            {
                UI.Output("Enter your username:");

                username = Input();
                if (String.IsNullOrEmpty(username))
                    isEmpty = true;
                else
                    isEmpty = false;
            } while (isEmpty);
            return username;
        }

        public static string Input()
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
            Output("\nContinue? (y/n)");
            string answer = Input();
            bool wantToContinue = !string.IsNullOrEmpty(answer) && answer.Trim().ToLower() == "y";
            return wantToContinue;
        }

        public static string GamesMenu(PlayerData player)
        {
            Output($"Hello {player.Name} and Welcome," +
                $"\nWhat would you like to play?" +
                $"\n1. MooGame" +
                $"\n2. MasterMind" +
                $"\n9. Exit");
            return Input();
        }
    }
}
