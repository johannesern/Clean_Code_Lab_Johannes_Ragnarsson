namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class Statistics
    {
        private static List<PlayerData> _results = new List<PlayerData>();
        
        public static string SaveResult(PlayerData player, string filename)
        {
            // We get all players and we try to find an existing user
            _results = FileHandler.ReadPlayerDataFromFile(filename);
            var playerExists = _results.Find(existingPlayer => existingPlayer.Name == player.Name);

            if (playerExists == null)
            {
                _results.Add(player);
            }
            else
            {
                playerExists.UpdateUserData(player.TotalGuesses);
            }
            string successOrErrorMessage = FileHandler.WritePlayerDataToFile(filename, _results);
            return successOrErrorMessage;
        }

        public static void ShowTopList(string filename)
        {
            var playerDatas = FileHandler.ReadPlayerDataFromFile(filename);
            playerDatas.Sort((p1, p2) => p1.AverageGuesses().CompareTo(p2.AverageGuesses()));

            const string customFormat = "{0,-9}{1,5:D}{2,9:F2}";

            string scoreTableHeader = string.Format(customFormat, "Player", "Games", "Average");
            UI.Output(scoreTableHeader);

            foreach (PlayerData player in playerDatas)
            {
                string playerRow = string.Format(customFormat, player.Name, player.NumberOfGames, player.AverageGuesses());
                UI.Output(playerRow);
            }
        }
    }
}
