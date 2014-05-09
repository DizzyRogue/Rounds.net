using System;

namespace Rounds
{
    public class Round
    {
        /// Public Properties on Round
        public int RoundThrows { get; set; }

        // Constructor
        public Round()
        {
            RoundThrows = 0;
        }

        // Round Function
        public void PlayRound(Player currentPlayer)
        {
            var newRound = new Throw();
            //Display various throw information to current player
            var playerInfo = new Info();
            playerInfo.PreThrowInfo(currentPlayer, this);
            //Throw dart
            newRound.ThrowDart(currentPlayer);
            RoundThrows += 1;
            // Status checks to see if the target or round needs to be advanced, or if the user needs to be taken through the hanger workflow
            var nextRoundCheck = NextRound(currentPlayer);
            var newHangerCheck = HangerCheck(currentPlayer);
            var newTargetCheck = NewTarget(currentPlayer);
            var finalRoundCheck = FinalRound(currentPlayer);

            // Advance Round but not Target (hits < 3 & remaining throws = 0)
            if (nextRoundCheck == true && newTargetCheck == false)
            {
                currentPlayer.CurrentRound += 1;
                // MaxRound Check, max of 5 Rounds per Target
                var maxRoundCheck = MaxRounds(currentPlayer);
                if (maxRoundCheck == true)
                {
                    currentPlayer.Target += 1;
                    currentPlayer.MultBonus = 0;
                    currentPlayer.CurrentRound = 1;
                    currentPlayer.Hits = 0;
                }
                else
                {
                    Console.WriteLine("========================================");
                    Console.WriteLine("Open round " + currentPlayer.Name + ", you will do better next time.");
                }
            }

            // Advance Target (hits >= 3) No Hanger (remaining throws > 0)
            else if (newTargetCheck == true && newHangerCheck == false)
            {
                // Assign MultBonus, RoundBonus & Total Score from previous Target then advance Target
                var getRoundBonus = RoundBonusCalc(currentPlayer.CurrentRound);
                currentPlayer.RoundBonus = getRoundBonus;
                currentPlayer.PlayerScoreboard.RoundBonusHelper(currentPlayer);
                currentPlayer.PlayerScoreboard.MultBonusHelper(currentPlayer);
                currentPlayer.PlayerScoreboard.ScoreboardCalculator(currentPlayer);
                currentPlayer.Target += 1;
                currentPlayer.Hits = 0;
                currentPlayer.CurrentRound = 1;
                currentPlayer.RoundBonus = 0;
                currentPlayer.MultBonus = 0;
            }

            // Hanger (hit >= 3 & remaining throws > 0)  
            else if (newHangerCheck == true)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("Hanger Time! Hanger Time! Hanger Time! If you haven't heard it's HANGER TIME!");
                var getRoundBonus = RoundBonusCalc(currentPlayer.CurrentRound);
                currentPlayer.RoundBonus = getRoundBonus;
                currentPlayer.PlayerScoreboard.RoundBonusHelper(currentPlayer);
                currentPlayer.PlayerScoreboard.MultBonusHelper(currentPlayer);
                currentPlayer.PlayerScoreboard.ScoreboardCalculator(currentPlayer);
                currentPlayer.Target += 1;
                currentPlayer.Hits = 0;
                currentPlayer.CurrentRound = 0; // Hanger round does not count toward max 5 rounds per target so it is set to 0
                currentPlayer.MultBonus = 0;
                currentPlayer.RoundBonus = 0;
            }

            // Special Final Round (target = 7 & hits >=3)
            else if (finalRoundCheck == true)
            {
                var getRoundBonus = RoundBonusCalc(currentPlayer.CurrentRound);
                currentPlayer.RoundBonus = getRoundBonus;
                currentPlayer.PlayerScoreboard.RoundBonusHelper(currentPlayer);
                currentPlayer.PlayerScoreboard.MultBonusHelper(currentPlayer);
                currentPlayer.PlayerScoreboard.ScoreboardCalculator(currentPlayer);
            }

            //Print post throw information & scoreboard to current player
            playerInfo.PostThrowInfo(currentPlayer);

        }

        // Static method to advance round on current target when (hits < 3 & remaining throws = 0)
        public bool NextRound(Player currentPlayer)
        {
            if (currentPlayer.Hits < 3 && RoundThrows == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Static method to advance target on current round. User got required 3 hits on target and is ready to move to next target
        public bool NewTarget(Player currentPlayer)
        {
            // First check to make sure player isn't on 15's and thus can't advance
            if (currentPlayer.Target < 7)
            {
                // Next check to verify user doesn't have required 3 hits on target and has reached max 5 rounds on current target
                if (currentPlayer.Hits == 3 || MaxRounds(currentPlayer) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Static method to determine if user has reached the max of 5 rounds on current target
        public bool MaxRounds(Player currentPlayer)
        {
            if (currentPlayer.CurrentRound == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Static method to determine if user has hit the special hanger condition (hits >=3, throws < 3)
        public bool HangerCheck(Player currentPlayer)
        {
            // First check to see if user's current target is 15s, thus there is no next target to advance to
            if (currentPlayer.Target < 7)
            {
                if (currentPlayer.Hits >= 3 && RoundThrows < 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Static method to determine if the user has finished the last round
        public bool FinalRound(Player currentPlayer)
        {
            if (currentPlayer.Hits >= 3 && currentPlayer.Target == 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method to calculate users Round Bonus
        public int RoundBonusCalc(int x)
        {
            if (x == 0)
            {
                return 250;
            }
            if (x == 1)
            {
                return 100;
            }
            if (x == 2)
            {
                return 50;
            }
            if (x == 3)
            {
                return 25;
            }
            if (x == 4)
            {
                return 15;
            }
            if (x == 5)
            {
                return 5;
            }
            return 0;
        }

        public void GameOver(Player currentPlayer)
        {
            if (currentPlayer.Hits >= 3 && currentPlayer.Target == 7)
            {
                currentPlayer.GameOver = true;
                this.RoundThrows = 3; //QUESTIONABLE CODE
            }
            else
            {
                currentPlayer.GameOver = false;
            }
        }
    }
 }
