namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class GameLogic
    {
        public string GenerateGoal(int goalLength)
        {
            Random randomGenerator = new Random();
            string goal = "";

            for (int i = 0; i < goalLength; i++)
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

        public string CheckGuess(string goal, string guess)
        {
            string correctSymbols = GetRightAmountOfSymbols(goal);
            string almostSymbols = correctSymbols.Replace("C", "A");

            int correct = 0, almost = 0;

            for (int i = 0; i < goal.Length; i++)
            {
                for (int j = 0; j < guess.Length; j++)
                {
                    if (goal[i] == guess[j])
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

            return $"{correctSymbols.Substring(0, correct)},{almostSymbols.Substring(0, almost)}";
        }

        private string GetRightAmountOfSymbols(string goal)
        {
            string symbols = "";

            for (int i = 0; i < goal.Length; i++)
            {
                symbols += "C";
            }
            return symbols;
        }
    }
}
