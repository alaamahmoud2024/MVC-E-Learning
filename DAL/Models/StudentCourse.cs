﻿namespace DAL.Models
{
    public class StudentCourse
    {
        public int Id{ get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
