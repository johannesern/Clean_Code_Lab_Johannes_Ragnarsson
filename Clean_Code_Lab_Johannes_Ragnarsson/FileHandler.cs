namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class FileHandler
    {
        public static List<PlayerData> ReadPlayerDataFromFile(string filename)
        {
            try
            {
                List<string> allLines = FileReader(filename);

                string splitter = "#&#";
                var playerDatas = SplitStringAddData(allLines, splitter);

                return playerDatas;
            }
            catch (Exception error)
            {
                Console.WriteLine("Couldn't read from file due to error:" + error);
                return new List<PlayerData>();
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

        private static List<PlayerData> SplitStringAddData(List<string> lines, string splitter)
        {
            string name;
            int numberOfGames, totalGuesses;
            var results = new List<PlayerData>();

            foreach (string line in lines)
            {
                string[] nameAndScore = line.Split(new string[] { splitter }, StringSplitOptions.None);

                name = nameAndScore[0];
                numberOfGames = Convert.ToInt32(nameAndScore[1]);
                totalGuesses = Convert.ToInt32(nameAndScore[2]);

                PlayerData playerData = new PlayerData(name, numberOfGames, totalGuesses);

                results.Add(playerData);
            }
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
                return "Players updated!";
            }
            catch (Exception error)
            {
                Console.WriteLine("Couldn't write to file due to error:\n" + error);
                return "Error creating new player";
            }
        }
    }
}
