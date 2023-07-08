using System;

namespace discgolf_app_dataaccess.Models
{
    public class Round
    {
        public Course CourseInfo { get; set; }
        public List<ScoreData> ScoreData { get; set; }
    }
}
