namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class Statistics
    {
        private static List<PlayerData> _results = new List<PlayerData>();
        
        public static void SaveResult(PlayerData player, string filename)
        {
            _results = FileHandler.ReadPlayerDataFromFile(filename);
            if(_results.Count > 0 ) 
            {
                var foundPlayer = _results.Find(p => p.Name == player.Name);

                if (foundPlayer == null)
                {
                    _results.Add(new PlayerData(player.Name, player.TotalGuesses));
                }
                else
                {
                    int indexOfUser = _results.FindIndex(user => user.Name == player.Name);
                    foundPlayer.UpdateUserData(player.TotalGuesses);
                }
                string response = FileHandler.WritePlayerDataToFile(filename, _results);
                Console.WriteLine(response);
            }
        }

        public static void ShowTopList(string filename)
        {
            var results = FileHandler.ReadPlayerDataFromFile(filename);
            results.Sort((p1, p2) => p1.AverageGuesses().CompareTo(p2.AverageGuesses()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format(
                    "{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.AverageGuesses()));
            }
        }
    }

    public class PlayerData
    {
        public string Name { get;  set; }
        public int NumberOfGames { get;  set; }
        public int TotalGuesses { get;  set; }


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

        public PlayerData() { }


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
