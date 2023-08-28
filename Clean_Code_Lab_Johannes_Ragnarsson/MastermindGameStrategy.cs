namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class MastermindGameStrategy : IGameStrategy
    {
        public string _goal;

        public void Initialize()
        {
            _goal = GenerateGoal();
            UI.Output("\nCorrect number at correct place generates C(orrect)" +
                "\nCorrect number but wrong place generates A(lmost)");
            UI.Output("\nNew game:");
            UI.Output("For practice, number is: " + _goal);
        }

        public string CheckGuess(string guess)
        {
            if (guess.Length < 7)
            {
                int almost = 0, correct = 0;
                guess += "      ";     // if player entered less than 6 chars
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (_goal[i] == guess[j])
                        {
                            if (i == j)
                            {
                                correct++;
                            }
                            else
                            {
                                almost++;
                            }
                        }
                    }
                }
                return "CCCCCC".Substring(0, correct) + "," + "AAAAAA".Substring(0, almost);
            }
            else
            {
                return $"You enter {guess.Length} characters but only 6 is allowed, try again";
            }
        }

        public string GenerateGoal()
        {
            Random randomGenerator = new Random();
            string goal = "";

            for (int i = 0; i < 6; i++)
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
