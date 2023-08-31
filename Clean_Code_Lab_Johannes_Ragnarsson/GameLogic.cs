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
            string ifCorrect = "C";
            string ifAlmost = "A";
            string correct = "";
            string almost = "";

            for (int i = 0; i < guess.Length; i++)
            {
                if (goal[i] == guess[i])
                {
                    correct += ifCorrect;
                }
                else if (goal.Contains(guess[i]))
                {
                    almost += ifAlmost;
                }
            }

            string complete = $"{correct},{almost}";

            return complete;
        }
    }
}
