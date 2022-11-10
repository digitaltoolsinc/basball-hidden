namespace BaseballAPI.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TeamId { get; set; }        
        public string TeamName { get; set; }
        public double BattingAverage { get; set; }
        public int HomeRuns { get; set; }
        public int Rbis { get; set; }
        public string Position { get; set; }
    }
}
