namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class UserInterface
    {
        public static string GetPlayerName()
        {
            Console.WriteLine("Enter your user name:");
            return Console.ReadLine();
        }

        public static string GetGuess()
        {
            return Console.ReadLine();
        }

        public static bool AskToContinue()
        {
            Console.WriteLine("\nContinue? (y/n)");
            string answer = Console.ReadLine();
            bool wantToContinue = !string.IsNullOrEmpty(answer) && answer.Trim().ToLower() == "y";
            return wantToContinue;
        }
    }
}
