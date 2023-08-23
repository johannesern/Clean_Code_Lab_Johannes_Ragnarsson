using Clean_Code_Lab_Johannes_Ragnarsson;

namespace GameTests
{
    public class FileHandlerTests
    {
        //Classname_MethodName_ExpectedResult

        [TestMethod]
        public void Statistics_WritePlayerDataToFile_CreateFileWriteToItFileFound()
        {
            //Arrange
            string filename = "TestWriting.txt";
            var playerDatas = new List<PlayerData>
            {
                new PlayerData {
                    Name = "Johannes",
                    NumberOfGames = 1,
                    TotalGuesses = 6
                },
                new PlayerData {
                    Name = "Pelle",
                    NumberOfGames = 5,
                    TotalGuesses = 30
                },
                new PlayerData {
                    Name = "Kalle",
                    NumberOfGames = 4,
                    TotalGuesses = 12
                },
                new PlayerData {
                    Name = "Lisa",
                    NumberOfGames = 6,
                    TotalGuesses = 18
                },
                new PlayerData {
                    Name = "Ida",
                    NumberOfGames = 10,
                    TotalGuesses = 48
                }
            };

            //Act
            FileHandler.WritePlayerDataToFile(filename, playerDatas);

            //Assert
            Assert.IsTrue(File.Exists(filename));
        }

        [TestMethod]
        public void Statistics_ReadPlayerDataFromFile_FileReadIsEqualToCorrectString()
        {
            //Arrange
            string filename = "TestWriting.txt";
            var playerDatas = new List<PlayerData>
            {
                new PlayerData {
                    Name = "Johannes",
                    NumberOfGames = 1,
                    TotalGuesses = 6
                },
                new PlayerData {
                    Name = "Pelle",
                    NumberOfGames = 5,
                    TotalGuesses = 30
                },
                new PlayerData {
                    Name = "Kalle",
                    NumberOfGames = 4,
                    TotalGuesses = 12
                },
                new PlayerData {
                    Name = "Lisa",
                    NumberOfGames = 6,
                    TotalGuesses = 18
                },
                new PlayerData {
                    Name = "Ida",
                    NumberOfGames = 10,
                    TotalGuesses = 48
                }
            };

            //Act
            var response = FileHandler.ReadPlayerDataFromFile(filename);

            //Assert
            for (int i = 0; i < playerDatas.Count; i++)
            {
                Assert.AreEqual(response[i].Name, playerDatas[i].Name);
                Assert.AreEqual(response[i].NumberOfGames, playerDatas[i].NumberOfGames);
                Assert.AreEqual(response[i].TotalGuesses, playerDatas[i].TotalGuesses);
            }
        }
    }
}
