using System;

namespace DataAccess.Models
{
    public class Round
    {
        public Course CourseInfo { get; set; }
        public List<ScoreData> ScoreData { get; set; }
    }
}
