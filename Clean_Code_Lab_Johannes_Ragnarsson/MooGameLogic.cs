﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Code_Lab_Johannes_Ragnarsson
{
    public class MooGameLogic
    {
        public static void PlayGame(string playerName)
        {
            bool playOn = true;

            while (playOn)
            {
                string goal = GenerateGoal();

                Console.WriteLine("New game:");
                Console.WriteLine("For practice, number is: " + goal);

                int nGuess = 1;
                string guess = UserInterface.GetGuess();
                string bbcc = CheckBullsAndCows(goal, guess);
                Console.WriteLine(bbcc);

                while (bbcc != "BBBB,")
                {
                    nGuess++;
                    guess = UserInterface.GetGuess();
                    bbcc = CheckBullsAndCows(goal, guess);
                    Console.WriteLine(bbcc);
                }

                //save playerdata somehow

                playOn = UserInterface.AskToContinue();
            }
        }

        private static string GenerateGoal()
        {
            Random randomGenerator = new Random();
            string goal = "";

            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = random.ToString();

                while (goal.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = random.ToString();
                }

                goal += randomDigit;
            }

            return goal;
        }

        private static string CheckBullsAndCows(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }
    }
}