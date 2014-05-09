using System;

namespace Rounds
{
    public class Scoreboard
    {
        /// Public Properties on Scoreboard
        public string Name { get; set; }
        public int Bull { get; set; }
        public int MultBonusBull { get; set; }
        public int RoundBonusBull { get; set; }
        public int Number20 { get; set; }
        public int MultBonusNumber20 { get; set; }
        public int RoundBonusNumber20 { get; set; }
        public int Number19 { get; set; }
        public int MultBonusNumber19 { get; set; }
        public int RoundBonusNumber19 { get; set; }
        public int Number18 { get; set; }
        public int MultBonusNumber18 { get; set; }
        public int RoundBonusNumber18 { get; set; }
        public int Number17 { get; set; }
        public int MultBonusNumber17 { get; set; }
        public int RoundBonusNumber17 { get; set; }
        public int Number16 { get; set; }
        public int MultBonusNumber16 { get; set; }
        public int RoundBonusNumber16 { get; set; }
        public int Number15 { get; set; }
        public int MultBonusNumber15 { get; set; }
        public int RoundBonusNumber15 { get; set; }


        // Constructor
        public Scoreboard()
        {
            Bull = 0;
            MultBonusBull = 0;
            RoundBonusBull = 0;
            Number20 = 0;
            MultBonusNumber20 = 0;
            RoundBonusNumber20 = 0;
            Number19 = 0;
            MultBonusNumber19 = 0;
            RoundBonusNumber19 = 0;
            Number18 = 0;
            MultBonusNumber18 = 0;
            RoundBonusNumber18 = 0;
            Number17 = 0;
            MultBonusNumber17 = 0;
            RoundBonusNumber17 = 0;
            Number16 = 0;
            MultBonusNumber16 = 0;
            RoundBonusNumber16 = 0;
            Number15 = 0;
            MultBonusNumber15 = 0;
            RoundBonusNumber15 = 0;
        }

        public void MultBonusHelper(Player currentPlayer)
        {
            switch (currentPlayer.Target)
            {
                case 1:
                    currentPlayer.PlayerScoreboard.MultBonusBull = currentPlayer.MultBonus;
                    break;
                case 2:
                    currentPlayer.PlayerScoreboard.MultBonusNumber20 = currentPlayer.MultBonus;
                    break;
                case 3:
                    currentPlayer.PlayerScoreboard.MultBonusNumber19 = currentPlayer.MultBonus;
                    break;
                case 4:
                    currentPlayer.PlayerScoreboard.MultBonusNumber18 = currentPlayer.MultBonus;
                    break;
                case 5:
                    currentPlayer.PlayerScoreboard.MultBonusNumber17 = currentPlayer.MultBonus;
                    break;
                case 6:
                    currentPlayer.PlayerScoreboard.MultBonusNumber16 = currentPlayer.MultBonus;
                    break;
                case 7:
                    currentPlayer.PlayerScoreboard.MultBonusNumber15 = currentPlayer.MultBonus;
                    break;
                default:
                    Console.WriteLine(" Obviously you're not a golfer...");
                    break;
            }
        }

        public void RoundBonusHelper(Player currentPlayer)
        {
            switch (currentPlayer.Target)
            {
                case 1:
                    currentPlayer.PlayerScoreboard.RoundBonusBull = currentPlayer.RoundBonus;
                    break;
                case 2:
                    currentPlayer.PlayerScoreboard.RoundBonusNumber20 = currentPlayer.RoundBonus;
                    break;
                case 3:
                    currentPlayer.PlayerScoreboard.RoundBonusNumber19 = currentPlayer.RoundBonus;
                    break;
                case 4:
                    currentPlayer.PlayerScoreboard.RoundBonusNumber18 = currentPlayer.RoundBonus;
                    break;
                case 5:
                    currentPlayer.PlayerScoreboard.RoundBonusNumber17 = currentPlayer.RoundBonus;
                    break;
                case 6:
                    currentPlayer.PlayerScoreboard.RoundBonusNumber16 = currentPlayer.RoundBonus;
                    break;
                case 7:
                    currentPlayer.PlayerScoreboard.RoundBonusNumber15 = currentPlayer.RoundBonus;
                    break;
                default:
                    Console.WriteLine(" Obviously you're not a golfer...");
                    break;
            }
        }

        public void ScoreboardCalculator(Player currentPlayer)
        {
            var bullCalc = currentPlayer.PlayerScoreboard.RoundBonusBull + currentPlayer.PlayerScoreboard.MultBonusBull;
            currentPlayer.PlayerScoreboard.Bull = bullCalc;
            var twentyCalc = currentPlayer.PlayerScoreboard.RoundBonusNumber20 + currentPlayer.PlayerScoreboard.MultBonusNumber20;
            currentPlayer.PlayerScoreboard.Number20 = twentyCalc;
            var nineteenCalc = currentPlayer.PlayerScoreboard.RoundBonusNumber19 + currentPlayer.PlayerScoreboard.MultBonusNumber19;
            currentPlayer.PlayerScoreboard.Number19 = nineteenCalc;
            var eighteenCalc = currentPlayer.PlayerScoreboard.RoundBonusNumber18 + currentPlayer.PlayerScoreboard.MultBonusNumber18;
            currentPlayer.PlayerScoreboard.Number18 = eighteenCalc;
            var seventeenCalc = currentPlayer.PlayerScoreboard.RoundBonusNumber17 + currentPlayer.PlayerScoreboard.MultBonusNumber17;
            currentPlayer.PlayerScoreboard.Number17 = seventeenCalc;
            var sixteenCalc = currentPlayer.PlayerScoreboard.RoundBonusNumber16 + currentPlayer.PlayerScoreboard.MultBonusNumber16;
            currentPlayer.PlayerScoreboard.Number16 = sixteenCalc;
            var fifteenCalc = currentPlayer.PlayerScoreboard.RoundBonusNumber15 + currentPlayer.PlayerScoreboard.MultBonusNumber15;
            currentPlayer.PlayerScoreboard.Number15 = fifteenCalc;
            var totalCalc = currentPlayer.PlayerScoreboard.Bull + currentPlayer.PlayerScoreboard.Number20 + currentPlayer.PlayerScoreboard.Number19 + currentPlayer.PlayerScoreboard.Number18 +
                currentPlayer.PlayerScoreboard.Number17 + currentPlayer.PlayerScoreboard.Number16 + currentPlayer.PlayerScoreboard.Number15;
            currentPlayer.TotalScore = totalCalc;
        }
    }
}
