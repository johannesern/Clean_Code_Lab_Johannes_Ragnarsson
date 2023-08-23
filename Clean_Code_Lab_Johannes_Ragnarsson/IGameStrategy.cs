namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public interface IGameStrategy
    {
        void Initialize();
        string GenerateGoal();
        string CheckGuess(string guess);
    }
}
