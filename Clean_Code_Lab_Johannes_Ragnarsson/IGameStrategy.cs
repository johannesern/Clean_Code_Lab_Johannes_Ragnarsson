namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public interface IGameStrategy
    {
        string CheckGuess(string guess);

        string PracticeMessage();

        public string GetGoal();
    }
}
