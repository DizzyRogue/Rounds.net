namespace Rounds
{
    public class Player
    {
        // Auto-implemented properties.
        public string Name { get; set; }
        public int Number { get; set; }
        public int Target { get; set; }
        public int CurrentRound { get; set; }
        public int Hits { get; set; }
        public int MultBonus { get; set; }
        public int RoundBonus { get; set; }
        public int TotalScore { get; set; }
        public bool GameOver { get; set; }
        public Scoreboard PlayerScoreboard { get; set; }

        public Player() 
        {
            Name = "";
            Number = 0;
            Target = 1;
            CurrentRound = 1;
            Hits = 0;
            MultBonus = 0;
            RoundBonus = 0;
            TotalScore = 0;
            GameOver = false;
            PlayerScoreboard = new Scoreboard();
        }
    }
}
