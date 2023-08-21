using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class Statistics
    {
        private static List<PlayerData> _results = new List<PlayerData>();
        
        public static void SaveResult(PlayerData player, string filename)
        {
            _results = ReadFromFile(filename);
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
                string response = WriteToFile(filename, _results);
                Console.WriteLine(response);
            }
        }

        public static void ShowTopList(string filename)
        {
            var results = ReadFromFile(filename);
            results.Sort((p1, p2) => p1.AverageGuesses().CompareTo(p2.AverageGuesses()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format(
                    "{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.AverageGuesses()));
            }
        }

        private static List<PlayerData> ReadFromFile(string filename) 
        {
            try
            {
                var input = new StreamReader(filename);
                var results = new List<PlayerData>();
                string splitter = "#&#";
                string line;
                while ((line = input.ReadLine()) != null)
                {
                    string[] nameAndScore = line.Split(new string[] { splitter }, StringSplitOptions.None);
                    string name = nameAndScore[0];
                    int numberOfGames = Convert.ToInt32(nameAndScore[1]);
                    int totalGuesses = Convert.ToInt32(nameAndScore[2]);
                    PlayerData playerData = new PlayerData(name, numberOfGames, totalGuesses);
                    results.Add(playerData);
                }                
                input.Close();
                return results;
            }
            catch (Exception error)
            {
                Console.WriteLine("Couldn't read from file due to error:" + error);
                return new List<PlayerData>();
            }
        }

        private static string WriteToFile(string filename, List<PlayerData> playerData)
        {
            try
            {
                using(var writer = new StreamWriter(filename, append:false)) 
                {
                    foreach(var player in playerData)
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

    public class PlayerData
    {
        public string Name { get; private set; }
        public int NumberOfGames { get; private set; }
        public int TotalGuesses { get; private set; }


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
