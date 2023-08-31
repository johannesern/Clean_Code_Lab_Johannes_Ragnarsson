using System.Numerics;

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

        public static void GamesMenu(PlayerData player)
        {
            bool run = true;
            while (run)
            {

                Output($"Hello {player.Name} and Welcome," +
                    $"\nWhat would you like to play?" +
                    $"\n1. MooGame" +
                    $"\n2. MasterMind" +
                    $"\n9. Exit");

                string response = Input();

                GamesList(response, player);
            }
            
        }

        private static void GamesList(string response, PlayerData player)
        {
            GameLogic gameLogic = new GameLogic();

            switch (response)
            {
                case "1":
                    IGameStrategy mooGame = new MooGameStrategy(gameLogic);
                    GameController mooController = new GameController(mooGame);
                    mooController.PlayGame(player);
                    break;
                case "2":
                    IGameStrategy mastermindGame = new MastermindGameStrategy(gameLogic);
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
