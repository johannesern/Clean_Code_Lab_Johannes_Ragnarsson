using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clean_Code_Lab_Johannes_Ragnarsson;
using System.Diagnostics.Metrics;

namespace Clean_Code_Lab_Johannes_Ragnarsson.Tests
{
    [TestClass()]
    public class StatisticsTests
    {
        //Classname_MethodName_ExpectedResult

        [TestMethod()]
        public void Statistics_SplitString_ReturnsListOfPlayerData()
        {
            //Arrange - get variables, get classes and methods
            string splitter = "#&#";
            List<string> linesToSplit = new List<string>
            {
                "Johannes#&#1#&#2",
                "Kalle#&#10#&#200",
            };

            var correctData = new List<PlayerData>
            {
                new PlayerData {
                    Name = "Johannes",
                    NumberOfGames = 1,
                    TotalGuesses = 2
                },
                new PlayerData {
                    Name = "Kalle",
                    NumberOfGames = 10,
                    TotalGuesses = 200
                },                
            };

            //Act - execute this function
            List<PlayerData> results = Statistics.SplitStringAddData(linesToSplit, splitter);

            //Assert - What is returned is what is expected
            Assert.AreEqual(correctData[0].Name, results[0].Name);
            Assert.AreEqual(correctData[0].NumberOfGames, results[0].NumberOfGames);
            Assert.AreEqual(correctData[0].TotalGuesses, results[0].TotalGuesses);
            Assert.AreEqual(correctData[1].Name, results[1].Name);
            Assert.AreEqual(correctData[1].NumberOfGames, results[1].NumberOfGames);
            Assert.AreEqual(correctData[1].TotalGuesses, results[1].TotalGuesses);
        }

        [TestMethod]
        public void Statistics_WriteToFile_CreateFileWriteToItFileFound()
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
            Statistics.WriteToFile(filename, playerDatas);

            //Assert
            Assert.IsTrue(File.Exists(filename));
        }

        [TestMethod]
        public void Statistics_ReadFromFile_FileReadIsEqualToCorrectString()
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
            var response = Statistics.ReadFromFile(filename);

            //Assert
            for (int i = 0; i < playerDatas.Count; i++)
            {
                Assert.AreEqual(response[i].Name, playerDatas[i].Name);
                Assert.AreEqual(response[i].NumberOfGames, playerDatas[i].NumberOfGames);
                Assert.AreEqual(response[i].TotalGuesses, playerDatas[i].TotalGuesses);
            }
        }

        [TestMethod]
        public void Statistics_FileReader_LineReadEqualsCorrectLine()
        {
            //Arrange
            string filename = "TestWriting.txt";
            var fromFile = new List<string>();
            var correctListItems = new List<string>
            {
                "Johannes#&#1#&#6",
                "Pelle#&#5#&#30",
                "Kalle#&#4#&#12",
                "Lisa#&#6#&#18",
                "Ida#&#10#&#48",
            };


            //Act
            fromFile = Statistics.FileReader(filename);

            //Assert
            for (int i = 0; i < correctListItems.Count; i++)
            {
                Assert.AreEqual(fromFile[i], correctListItems[i]);
            }
        }

        [TestMethod]
        public void Statistics_
    }
}