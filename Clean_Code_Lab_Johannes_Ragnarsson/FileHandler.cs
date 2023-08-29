namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class FileHandler
    {
        public static List<PlayerData> ReadPlayerDataFromFile(string filename)
        {
            CreateIfNotFound(filename);
            try
            {                
                List<string> allLinesFromFile = FileReader(filename);

                var playerDatas = SplitString(allLinesFromFile);

                return playerDatas;
            }
            catch (Exception error)
            {
                UI.Output("\nCouldn't read from file due to error:" + error + "\n");
                return new List<PlayerData>();
            }
        }

        private static void CreateIfNotFound(string filename)
        {
            bool fileNotFound = !File.Exists(filename);
            if (fileNotFound)
            {
                using (FileStream fs = File.Create(filename))
                {                 
                }
            }
        }

        private static List<string> FileReader(string filename)
        {
            var input = new StreamReader(filename);
            var results = new List<string>();

            string line;

            while ((line = input.ReadLine()) != null)
            {
                results.Add(line);
            }
            input.Close();
            return results;
        }

        private static List<PlayerData> SplitString(List<string> allLinesFromFile)
        {
            var results = new List<PlayerData>();
            string splitter = "#&#";

            foreach (string line in allLinesFromFile)
            {
                string[] nameAndScore = line.Split(new string[] { splitter }, StringSplitOptions.None);
                results = AddPlayerDataToList(results, nameAndScore);
            }
            return results;
        }

        private static List<PlayerData> AddPlayerDataToList(List<PlayerData> results, string[] nameAndScore)
        {
            var name = nameAndScore[0];
            var numberOfGames = Convert.ToInt32(nameAndScore[1]);
            var totalGuesses = Convert.ToInt32(nameAndScore[2]);

            PlayerData playerData = new PlayerData(name, numberOfGames, totalGuesses);

            results.Add(playerData);

            return results;

        }

        public static string WritePlayerDataToFile(string filename, List<PlayerData> playerData)
        {
            try
            {
                using (var writer = new StreamWriter(filename, append: false))
                {
                    foreach (var player in playerData)
                    {
                        writer.WriteLine(
                            $"{player.Name}#&#{player.NumberOfGames}#&#{player.TotalGuesses}");
                    }
                }
                return "Highscores updated!";
            }
            catch (Exception error)
            {
                UI.Output("\nCouldn't write to file due to error:\n" + error + "\n");
                return "Error creating new player";
            }
        }
    }
}
