using System;
using System.Collections.Generic;

namespace Rounds
{
    public class GamePlayers
    {
        // Creates list to store player objects
        public List<Player> PlayerList = new List<Player>();

        // Number of player(s) placeholder and player number variable
        public int NumberOfPlayers;
        public int InputNumber;

        // Constructor 
        public GamePlayers()
        {
            NumberOfPlayers = 0;
            InputNumber = 1;
        }

        // Function to take in how many players and verify player input was a int
        public void PlayerInput()
        {
            var playersEntered = false;
            while (playersEntered == false)
            {
                Console.WriteLine("Welcome to Rounds!");
                Console.WriteLine("");
                Console.WriteLine("How many players ?");
                var holder = Console.ReadLine();
                var players = 0;

                if(int.TryParse(holder, out players))
                {
                    NumberOfPlayers = players;
                    playersEntered = true;     
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1-4 only.");
                }
            }

            // Loop to assign Name and Number to each player 
            while (NumberOfPlayers > 0)
            {
                var newPlayer = new Player();
                Console.WriteLine(" ");
                Console.WriteLine("Player " + InputNumber + " enter your name: ");
                newPlayer.Name = Console.ReadLine();
                newPlayer.Number = InputNumber;
                PlayerList.Add(newPlayer);
                NumberOfPlayers -= 1;
                InputNumber += 1;
            }    
        }
    }
}
