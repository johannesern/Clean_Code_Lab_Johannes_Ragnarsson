namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class MooGameStrategy : IGameStrategy
    {
        public string _goal;
        public void Initialize()
        {
            _goal = GenerateGoal();
            UI.Output("New game:");
            UI.Output("For practice, number is: " + _goal);
        }

        public string CheckGuess(string guess)
        {
            if (guess.Length < 5)
            {
                int cows = 0, bulls = 0;
                guess += "    ";     // if player entered less than 4 chars
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (_goal[i] == guess[j])
                        {
                            if (i == j)
                            {
                                bulls++;
                            }
                            else
                            {
                                cows++;
                            }
                        }
                    }
                }
                return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
            }
            else
            {
                return $"You enter {guess.Length} characters but only 4 is allowed, try again";
            }
        }

        public string GenerateGoal()
        {
            Random randomGenerator = new Random();
            string goal = "";

            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = random.ToString();

                while (goal.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = random.ToString();
                }

                goal += randomDigit;
            }

            return goal;
        }
    }
}
