using System;
using System.Linq;

namespace Rounds
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Instance of GamePlayers to take in the number and names of players
            var gamePlayers = new GamePlayers();

            // Flag to take users from entering names & number of players to playing
            var gameStarted = 0;

            // While loop that takes a name in for the number of players assigned
            while (gameStarted == 0)
            {
                gamePlayers.PlayerInput();
                gameStarted += 1;
            }

            // Main game loop once all players have been entered
            if (gameStarted == 1)
            {
                //var isGameOver = false;
                while (gamePlayers.PlayerList.Any(m => !m.GameOver))
                {
                    foreach (var currentPlayer in gamePlayers.PlayerList.Where(m => !m.GameOver))
                    {
                        var newRound = new Round();
                        while (newRound.RoundThrows < 3)
                        {
                            newRound.PlayRound(currentPlayer);
                            // Check to see if player is finished with the game
                            newRound.GameOver(currentPlayer);
                        }
                    }
                }
            }
            // Final Score(s) Displayed
            var getFinalScores = new Info();
            getFinalScores.GameRecap(gamePlayers);

        }
    }
}
