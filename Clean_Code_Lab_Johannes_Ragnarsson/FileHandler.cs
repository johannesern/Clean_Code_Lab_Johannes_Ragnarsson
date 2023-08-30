namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public static class FileHandler
    {
        private static string splitter = "#&#";

        public static List<PlayerData> ReadPlayerDataFromFile(string filename)
        {
            CreateIfNotFound(filename);
            try
            {                
                List<string> allLinesFromFile = FileReader(filename);

                var playerDatas = SplitString(allLinesFromFile);

                return playerDatas;
            }
            catch(IOException ioerror)
            {
                UI.Output("Couldn't read from file.\n" + ioerror);
                return new List<PlayerData>();
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
                UI.Output("File not found, creating new file...\n");
                using (FileStream fs = File.Create(filename))
                {                 
                }
            }
        }

        private static List<string> FileReader(string filename)
        {
            var results = new List<string>();
            using (var input = new StreamReader(filename))
            {
                string line;

                while ((line = input.ReadLine()) != null)
                {
                    results.Add(line);
                }
            }
            return results;
        }

        private static List<PlayerData> SplitString(List<string> allLinesFromFile)
        {
            var results = new List<PlayerData>();            

            foreach (string line in allLinesFromFile)
            {
                string[] playerInfo = line.Split(new string[] { splitter }, StringSplitOptions.None);

                var name = playerInfo[0];
                var numberOfGames = Convert.ToInt32(playerInfo[1]);
                var totalGuesses = Convert.ToInt32(playerInfo[2]);

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
                        writer.WriteLine(player.Name + splitter + player.NumberOfGames + splitter + player.TotalGuesses);
                    }
                }
                return "Highscores updated!";
            }
            catch (IOException ioerror)
            {                
                return "Error writing to file.\n" + ioerror;
            }
            catch (Exception error)
            {
                return "Error creating new player.\n" + error;
            }
        }
    }
}
