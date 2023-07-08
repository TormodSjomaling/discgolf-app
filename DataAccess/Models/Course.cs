﻿namespace discgolf_app_dataaccess.Models
{
    public class Course
    {
        public string CourseName { get; set; }
        public string LayoutName { get; set; }
        public DateTime Date { get; set; }
        public int CoursePar { get; set; }
        public List<int> HolePars { get; set; }
    }
}
