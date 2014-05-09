using System;

namespace Rounds
{
    public class Throw
    {
        /// Public Properties on Throw
        public bool ValidDart { get; set; }
        public string LastDartInput { get; set; }

        // Constructor
        public Throw()
        {
            ValidDart = false;
            LastDartInput = "";
        }


        virtual public string GetDartInput()
        {
            Console.WriteLine("========================================");
            Console.WriteLine(" Use T, D, S, or X to enter thrown dart: ");
            return Console.ReadLine();
        }
        
        // Dart input function
        public void ThrowDart(Player currentPlayer)
        {
            while (ValidDart == false)
            {
                // Take user dart input and verify 
                var dartInput = GetDartInput();
                LastDartInput = dartInput.ToUpper();
                IsValid(LastDartInput);
                // Update player's hits on current target
                var playersHits = HitCalc(LastDartInput);
                currentPlayer.Hits += playersHits;
                // Update player's current multi bonus for round
                var roundMultScore = MultScore(LastDartInput);
                currentPlayer.MultBonus += roundMultScore;
                
            }
        }

        // Dart input validation function
        public void IsValid(string dartCheck)
        {
            if (dartCheck == "T" || dartCheck == "D" || dartCheck == "S" || dartCheck == "X")
            {
                ValidDart = true;
            }
            else
            {
                ValidDart = false;
                Console.WriteLine("Invalid dart input!");
                Console.WriteLine("T for a triple, D for a double, S for a single, and X for a miss.");
            }
        }

        // Throw # of hit(s) value 
        public int HitCalc(string x)
        {
            if (x == "T")
            {
                return 3;
            }
            if (x == "D")
            {
                return 2;
            }
            if (x == "S")
            {
                return 1;
            }
            if (x == "X")
            {
                return 0;
            }
                return 0;
        }

        // Throw Mult value 
        public int MultScore(string x)
        {
            if (x == "T")
            {
                return 100;
            }
            if (x == "D")
            {
                return 50;
            }
            if (x == "S")
            {
                return 10;
            }
            if (x == "X")
            {
                return 0;
            }
            return 0;
        }
    }
}
