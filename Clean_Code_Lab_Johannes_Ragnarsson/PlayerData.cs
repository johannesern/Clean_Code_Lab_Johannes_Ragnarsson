namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class PlayerData
    {
        public string Name { get; set; }
        public int NumberOfGames { get; set; }
        public int TotalGuesses { get; set; }


        public PlayerData(string name, int guesses)
        {
            this.Name = name;
            NumberOfGames = 1;
            TotalGuesses = guesses;
        }

        public PlayerData(string name, int numberOfGames, int totalGuesses)
        {
            this.Name = name;
            NumberOfGames = numberOfGames;
            TotalGuesses = totalGuesses;
        }

        //public PlayerData() { }


        public void UpdateUserData(int guesses)
        {
            TotalGuesses += guesses;
            NumberOfGames++;
        }

        public double AverageGuesses()
        {
            return (double)TotalGuesses / NumberOfGames;
        }
    }
}
