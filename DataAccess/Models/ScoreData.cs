using System;

namespace DataAccess.Models
{
    public class ScoreData
    {
        public string PlayerName { get; set; }
        public int Total { get; set; }
        public int? PlusMinus { get; set; }
        public List<int> HoleScores { get; set; }
    }

}
