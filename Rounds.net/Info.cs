using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rounds
{
    public class Info
    {
        // Target switch statement to convert target number into text display
        public string TargetConverter(Player currentPlayer)
        {
            switch (currentPlayer.Target)
            {
                case 1:
                    return "Bullseye";
                    break;
                case 2:
                    return "20s";
                    break;
                case 3:
                    return "19s";
                    break;
                case 4:
                    return "18s";
                    break;
                case 5:
                    return "17s";
                    break;
                case 6:
                    return "16s";
                    break;
                case 7:
                    return "15s";
                    break;
                default:
                    return "Obviously you're not a golfer...";
                    break;
            }
        }

        // Pre-throw information for player
        public void PreThrowInfo(Player currentPlayer, Round currentRound)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Current Player: " + currentPlayer.Name);
            Console.WriteLine("Current Target: " + TargetConverter(currentPlayer));
            Console.WriteLine("Current Round: " + currentPlayer.CurrentRound);
            Console.WriteLine("Hits on current target: " + currentPlayer.Hits);
            Console.WriteLine("Throws remaining this round: " + (3 - currentRound.RoundThrows));
        }

        // Post-throw information for player
        public void PostThrowInfo(Player currentPlayer)
        {
            Console.WriteLine("========================================");
            Console.WriteLine(currentPlayer.Name + "'s" + " Scoreboard");
            Console.WriteLine("B : " + currentPlayer.PlayerScoreboard.Bull);
            Console.WriteLine("20: " + currentPlayer.PlayerScoreboard.Number20);
            Console.WriteLine("19: " + currentPlayer.PlayerScoreboard.Number19);
            Console.WriteLine("18: " + currentPlayer.PlayerScoreboard.Number18);
            Console.WriteLine("17: " + currentPlayer.PlayerScoreboard.Number17);
            Console.WriteLine("16: " + currentPlayer.PlayerScoreboard.Number16);
            Console.WriteLine("15: " + currentPlayer.PlayerScoreboard.Number15);
            Console.WriteLine("Total: " + currentPlayer.TotalScore);
            Console.WriteLine("========================================");
        }

        // Final Score(s) display
        public void GameRecap(GamePlayers playerList)
        {
            foreach (var gamePlayer in playerList.PlayerList)
            {
                Console.WriteLine(gamePlayer.Name + ": " + gamePlayer.TotalScore);
            }
            Console.WriteLine("========================================");
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();           
        }
                
    }
}
